using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    
    const float rotSpeed = 180f;
    const float autoRotateValue = 15f;

    bool Dragging;
    public bool canRotate = true;

    void OnMouseDrag()
    {
        Dragging = true;
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotX);
    }

    private void OnMouseUp()
    {
        Dragging = false;
    }

    private void Update()
    {
        if(!Dragging && canRotate)
        {
            transform.Rotate(Vector3.up * (autoRotateValue * Time.deltaTime));
        }
    }

}
