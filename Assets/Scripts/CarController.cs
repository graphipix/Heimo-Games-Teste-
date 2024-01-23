using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rgbd;
    [SerializeField] [Range(10, 100)] int Force = default;
    Vector3 IsMoving = default;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rgbd.velocity = new Vector3(Input.GetAxis("Horizontal") * Force, 0, Input.GetAxis("Vertical") * Force);
        WheelController();
    }
    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider FrontLeftWheelCollider, FrontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform FrontLeftWheel, FrontRightWheel = default;
    [SerializeField] private Transform BackLeftWheel, BackRightWheel = default;

    #region WheelController

    public int axis;
    private void WheelController()
    {
        FrontLeftWheel.rotation = Quaternion.Euler(axis, 30 * Input.GetAxis("Horizontal"), transform.rotation.z);
        FrontRightWheel.rotation = Quaternion.Euler(axis, 30 * Input.GetAxis("Horizontal"), transform.rotation.z);
        BackLeftWheel.rotation = Quaternion.Euler(axis *-1, 30 * Input.GetAxis("Horizontal"), transform.rotation.z);
        BackRightWheel.rotation = Quaternion.Euler(axis * -1, 30 * Input.GetAxis("Horizontal"), transform.rotation.z);

        transform.rotation = Quaternion.Euler(Input.GetAxis("Horizontal"),transform.rotation.y,transform.rotation.z);

        //Wheel Axis Rotation
        if (Input.GetAxis("Vertical") != 0)
        {
            axis += 45;
        }


    }
    #endregion
}