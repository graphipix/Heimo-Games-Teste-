using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningCar : MonoBehaviour
{
    public WheelCollider frontleft = default;
    public WheelCollider frontright = default;
    public WheelCollider backleft = default;
    public WheelCollider backright = default;

    public float acceleration = default;
    public float breakingForce = default;

    public float currentacceleration = default;
    public float currentbreakingForce = default;

    public float MaxTurnAngle = 15;
    float CurrentTurnAngle = 0f;

    private void Start()
    {
        ComponentManager();
    }

    #region Car Components
    [Space]
    [Header("[ Car Data ] ")]
    [SerializeField] private CarsList CarData = default;

    [Space]
    public Material[] material = default;

    [Space]
    [Header("[ Components ] ")]
    [SerializeField] private Transform Airfoil = default;
    [SerializeField] private Transform Bumper = default;
    [SerializeField] private Transform Painting = default;
    [SerializeField] private Transform TireA = default;
    [SerializeField] private Transform TireDefault = default;

    #endregion

    private void FixedUpdate()
    {
        currentacceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space)) 
        {
            currentbreakingForce = breakingForce;
        }
        else
        {
            currentbreakingForce = 0f;
        }

        frontright.motorTorque = currentacceleration;
        frontleft.motorTorque = currentacceleration;

        frontleft.brakeTorque = currentbreakingForce;
        frontright.brakeTorque = currentbreakingForce;
        backleft.brakeTorque = currentbreakingForce;
        backright.brakeTorque = currentbreakingForce;

        CurrentTurnAngle = MaxTurnAngle * Input.GetAxis("Horizontal");
        frontleft.steerAngle = CurrentTurnAngle;
        frontright.steerAngle = CurrentTurnAngle;
    }

    private void ComponentManager()
    {
        #region Airfoil
        if (!Airfoil.gameObject.activeInHierarchy && CarData.Airfoil) { Airfoil.gameObject.SetActive(true); }
        #endregion

        #region Bumber
        if (!Bumper.gameObject.activeInHierarchy && CarData.Bumper) { Bumper.gameObject.SetActive(true); }
        #endregion

        #region TireA
        if (!TireA.gameObject.activeInHierarchy && CarData.TireA) { TireA.gameObject.SetActive(true); TireDefault.gameObject.SetActive(false); }
        #endregion

        #region NewColor
        if (CarData.Painting)
        {
            transform.GetChild(0).GetComponent<MeshRenderer>().material = material[1];
        }
        #endregion
    }
}
