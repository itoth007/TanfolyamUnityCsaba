using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Demageble : MonoBehaviour
{
    [SerializeField]  int maxHP = 10;
    [SerializeField] TMP_Text healtText;
    [SerializeField] Color minHPColor = Color.red;
    [SerializeField] Color maxHPColor = Color.green;
    [SerializeField] Gradient healthColor;
    [SerializeField] GameObject isDeadObject;
    int health;
    public void Damage(int n)
    {
        health -=n;
        health = Mathf.Max(health, 0); // ez csinálja, hogy ne legyen 0-nál kisebb.
        UpdateUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHP;
        UpdateUI();
    }
    public int Health => health;
    public bool IsAlive => health > 0;
    // Update is called once per frame
    void UpdateUI()
    {
        float t = (float) health / maxHP;
   //     Color c = Color.Lerp(minHPColor, maxHPColor, t);
   Color c = healthColor.Evaluate(t);
        healtText.text = health.ToString();
        isDeadObject.SetActive(!IsAlive);
    }
}
