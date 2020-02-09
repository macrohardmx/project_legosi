﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        KeyboardMovement();
        MouseRotation();
    }


    void KeyboardMovement() {
        var move = new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), transform.position.z);
        transform.position += move * speed * Time.deltaTime;
    }

    void MouseRotation() {
        var mouse = ProjectedMousePoint();
        var direction = mouse - transform.position;

        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, new Vector3(0, 0, 1));
    }

    Vector3 ProjectedMousePoint() {
        var cam = Camera.main;
        var mouse_viewport = cam.ScreenToViewportPoint(Input.mousePosition);
        var z = cam.nearClipPlane + (transform.position.z - cam.transform.position.z);
        return cam.ViewportToWorldPoint(new Vector3(mouse_viewport.x, mouse_viewport.y, z));
    }
}
