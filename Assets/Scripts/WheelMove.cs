using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMove : MonoBehaviour
{
    [SerializeField] private WheelCollider ColRelated = default;

    private void FixedUpdate()
    {
        RotateWheel(ColRelated);
    }

    private void RotateWheel(WheelCollider col) 
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
