using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody rgbd;
    [SerializeField] [Range(10,100)] int Force = default;
    Vector3 IsMoving = default;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        rgbd.velocity = new Vector3(Input.GetAxis("Horizontal") * Force, 0, Input.GetAxis("Vertical")* Force);
    }
}
