using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Camera controlledCamera;
    [SerializeField] Transform target;
    [SerializeField] float verticalAngle = 60;
    [SerializeField] float targetSize = 1;    // A célpont mérete
    [SerializeField] float fieldOfView = 30f;  // Kamera távolsága a célponttól
    [SerializeField] float cameraRectX = 0;
    [SerializeField] float cameraRectY = 0;
    [SerializeField] float cameraRectW = 1;
    [SerializeField] float cameraRectH = 1;
    // Start is called before the first frame update
    void LateUpdate()
    {
        FreshCamera();
    }
    void FreshCamera()
    {
        controlledCamera.fieldOfView = fieldOfView;
        float fieldOfViewRad = fieldOfView * Mathf.Deg2Rad;
        float targetDistance = targetSize / (2 * Mathf.Tan(fieldOfViewRad / 2f));
        float verticalDistance = targetDistance * Mathf.Sin(verticalAngle * Mathf.Deg2Rad);
        float horizontalDistance = targetDistance * Mathf.Cos(verticalAngle * Mathf.Deg2Rad);
        Vector3 distanceVector = new Vector3(0, verticalDistance, -horizontalDistance);
        transform.position = target.position + distanceVector;
        transform.LookAt(target);
        controlledCamera.rect = new Rect(cameraRectX, cameraRectX, cameraRectW, cameraRectH);
        }
}
