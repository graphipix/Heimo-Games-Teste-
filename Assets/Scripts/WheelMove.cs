using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    private void FixedUpdate()
    {
        WheelController();
    }

    private int axis;
    private void WheelController()
    {
        gameObject.transform.rotation = Quaternion.Euler(axis, 45 * Input.GetAxis("Horizontal"), transform.rotation.z);

        //transform.rotation = Quaternion.Euler(transform.rotation.x, Input.GetAxis("Horizontal") * 30, transform.rotation.z);

        //Wheel Axis Rotation
        if (Input.GetAxis("Vertical") != 0)
        {
            axis += 30;
        }
    }
}
