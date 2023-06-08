using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraController : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] float horizontalSensitivity = 1;
    [SerializeField] float verticalSensitivity = 1;
    [SerializeField] bool invertMouseVertical = false;
    [SerializeField] bool disableCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        //if(disableCursor)
        //    Cursor.visible = false;
        Cursor.visible = !disableCursor;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseMovementX = Input.GetAxis("Mouse X"); // mennyit mozdul el a mouse 2 FPS óta
        float mouseMovementY = Input.GetAxis("Mouse Y");
        cameraController.horizontalAngle += mouseMovementX * horizontalSensitivity;
        float verticalM = invertMouseVertical ? -1 : 1; // felfelé húzod a botkormányt felfelé megy vagy lefelé a gép
        cameraController.verticalAngle -= mouseMovementY * verticalSensitivity *verticalM;
        // mathf.move toward dal lehet simítani Vagy lerp-pel, ahogy nekem van a camera follower -ben
    }
}
