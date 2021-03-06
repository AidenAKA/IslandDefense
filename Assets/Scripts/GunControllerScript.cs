﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControllerScript : MonoBehaviour
{
    public float sensitivity = 1000;

    private Quaternion defaultRotation;
    private Vector3 screenCentrePoint;

    private void SetScreenCentrePoint()
    {
        // determine the centre of the screen halving its dimensions
        screenCentrePoint.x = Screen.width / 2;
        screenCentrePoint.y = Screen.height / 2;
    }

    public void ProcessInput()
    {
        // get mouse position
        Vector3 mousePos = Input.mousePosition;

        // get the direction from the mouse position to the centre of the screen
        Vector3 mouseDir = mousePos - screenCentrePoint;

        // calculate the angle between the mouse direction and the up direction
        float angle = Vector3.SignedAngle(Vector3.up, mouseDir, Vector3.back);

        // calculate the new rotation based on the angle and its original rotation
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(0, angle, 0) + defaultRotation.eulerAngles;

        // apply the new rotation to the object
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, newRotation, sensitivity * Time.deltaTime);
    }

    private void Start()
    {
        SetScreenCentrePoint();

        defaultRotation = this.transform.rotation;
    }

    private void Update()
    {
        ProcessInput();
    }
}
