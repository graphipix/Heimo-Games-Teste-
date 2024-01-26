using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TurningCar : MonoBehaviour
{
    internal float velocity;

    [SerializeField] internal WheelCollider frontleft = default;
    [SerializeField] internal WheelCollider frontright = default;
    [SerializeField] internal WheelCollider backleft = default;
    [SerializeField] internal WheelCollider backright = default;

    [SerializeField] internal float acceleration = default;
    [SerializeField] internal float breakingForce = default;

    [SerializeField] internal float currentacceleration = default;
    internal float currentbreakingForce = default;

    internal float MaxTurnAngle = 15;
    float CurrentTurnAngle = 0f;

    [SerializeField] private Transform Car = default;

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

        //Back Wheel
        backright.motorTorque = currentacceleration;
        backleft.motorTorque = currentacceleration;

        frontleft.brakeTorque = currentbreakingForce;
        frontright.brakeTorque = currentbreakingForce;
        backleft.brakeTorque = currentbreakingForce;
        backright.brakeTorque = currentbreakingForce;

        CurrentTurnAngle = MaxTurnAngle * Input.GetAxis("Horizontal");
        
        frontleft.steerAngle = CurrentTurnAngle;
        frontright.steerAngle = CurrentTurnAngle;

        //Back Wheel
        backleft.steerAngle = -CurrentTurnAngle;
        backright.steerAngle = -CurrentTurnAngle;

        velocity = frontright.rpm;
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
            Car.GetComponent<MeshRenderer>().material = material[1];
        }
        #endregion
    }

    private void Update()
    {
        if (transform.rotation.eulerAngles.z > 10 || transform.rotation.eulerAngles.z < -10)
        {
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }

        print(transform.rotation.eulerAngles.z);
    }

    public void GoToStore()
    {
        SceneManager.LoadScene("Store");
    }
}
