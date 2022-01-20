using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    public Mouse mouse;
    public float sensitivity;

    Vector2 lookDirection = Vector2.zero;

    private void Awake()
    {
        mouse = new Mouse();
    }


    void Update()
    {
        lookDirection = mouse.Player.MouseLook.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        float lookX = lookDirection.x * sensitivity * Time.deltaTime;
        float lookY = lookDirection.y * sensitivity * Time.deltaTime;
        transform.eulerAngles = new Vector3(lookY, lookX, 0);

        //lookX = Mathf.Clamp(lookX, -90f, 90f);
    }

    void OnEnable()
    {
        mouse.Player.Enable();
    }

    void OnDisable()
    {
        mouse.Player.Disable();
    }

}
