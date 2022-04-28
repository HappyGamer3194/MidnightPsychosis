using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    float xRotation = 0f;

    float sneakOffset;

    public GameObject player;
    Vector3 offset;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.transform.Rotate(Vector3.up * mouseX);

        //transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y + sneakOffset, player.transform.position.z + offset.z);

        //offset.y = player.transform.localScale.y;

        if (player.GetComponent<PlayerController>().sneaking == true)
        {
            sneakOffset = offset.y / -2f;
        } else
        {
            sneakOffset = 0f;
        }
    }
}