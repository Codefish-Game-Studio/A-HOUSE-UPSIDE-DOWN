using System;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float panSpeed;
    public float minX, maxX;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        float borderThreshold = Screen.width / 8f;

        if (mousePosition.x < borderThreshold)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        else if (mousePosition.x > Screen.width - borderThreshold)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}
