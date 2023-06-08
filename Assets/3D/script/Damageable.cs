using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] TMP_Text healthText;
    [SerializeField] float invincibilityFrames = 1;
    [SerializeField] float flickTime = 0.1f;
    [SerializeField] RectTransform healthBar;
    [SerializeField] Gradient healthColor;
    [SerializeField] GameObject isDeadObject;

    int health;
    bool isInvincible = false;

    public int HealthLost
    {
        get => maxHP - health;
        set => health = maxHP - value;
    }

    void Start()
    {
        health = maxHP;
        UpdateUI();

        int lost = HealthLost;

        Vector3 pos = transform.position;
    }

    public int GetHealth() => health;

    public bool IsAlive => health > 0;

    public void Damage(int n)
    {
        if (isInvincible)
            return;

        health -= n;
        health = Mathf.Max(health, 0);

        UpdateUI();
        StartCoroutine(InvincibilityCoroutine());
    }

    IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        // yield return new WaitForSeconds(invincibilityFrames);

        float time = 0;
        bool visible = true;
        while (time < invincibilityFrames)
        {
            visible = !visible;

            EnableAllRenderer(visible);
            yield return new WaitForSeconds(flickTime);
            time += flickTime;
        }

        EnableAllRenderer(true);
        isInvincible = false;
    }

    void EnableAllRenderer(bool enabled)
    {
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = enabled;
        }
    }

    void UpdateUI()
    {
        float t = (float)health / maxHP;
        // Color c = Color.Lerp(minHPColor, maxHPColor, t);
        Color c = healthColor.Evaluate(t);

        healthText.color = c;
        healthText.text = health.ToString();
        Vector2 anchorMax = healthBar.anchorMax;
        anchorMax.x = t;
        healthBar.anchorMax = anchorMax;
        Image image = healthBar.GetComponent<Image>();
        image.color = c; 
        isDeadObject.SetActive(!IsAlive);
    }
}
