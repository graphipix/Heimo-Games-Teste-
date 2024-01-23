using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rgbd;
    [SerializeField] [Range(10, 100)] int Force = default;

    public Material[] material = default;
    public bool newcolor;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        if (newcolor)
        {
            GetComponent<MeshRenderer>().material = material[1];
        }
        ComponentManager();
    }
    private void FixedUpdate()
    {
        rgbd.velocity = new Vector3(Input.GetAxis("Horizontal") * Force, 0, Input.GetAxis("Vertical") * Force);
        WheelController();
    }

    [Header("[ Car Wheels ]")]
    [SerializeField] private Transform FrontLeftWheel, FrontRightWheel = default;
    [SerializeField] private Transform BackLeftWheel, BackRightWheel = default;

    [Space]
    [Header("[ Car Data ] ")]
    [SerializeField] private CarsList CarData = default;

    [Space]
    [Header("[ Components ] ")]
    [SerializeField] private Transform Airfoil = default;
    [SerializeField] private Transform Bumper = default;
    [SerializeField] private Transform Painting = default;
    [SerializeField] private Transform TireA = default;
    [SerializeField] private Transform TireDefault = default;

    #region WheelController

    private int axis;
    private void WheelController()
    {
        FrontLeftWheel.rotation = Quaternion.Euler(axis, 45 * Input.GetAxis("Horizontal"), transform.rotation.z);
        FrontRightWheel.rotation = Quaternion.Euler(axis, 45 * Input.GetAxis("Horizontal"), transform.rotation.z);
        BackLeftWheel.rotation = Quaternion.Euler(axis *-1, 45 * Input.GetAxis("Horizontal"), transform.rotation.z);
        BackRightWheel.rotation = Quaternion.Euler(axis * -1, 45 * Input.GetAxis("Horizontal"), transform.rotation.z);

        transform.rotation = Quaternion.Euler(transform.rotation.x, Input.GetAxis("Horizontal") *30, transform.rotation.z);

        //Wheel Axis Rotation
        if (Input.GetAxis("Vertical") != 0)
        {
            axis += 45;
        }
    }
    #endregion

    #region Components

    private void ComponentManager() 
    {



    }
    #endregion
}