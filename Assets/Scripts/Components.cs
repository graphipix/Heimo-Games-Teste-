using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Components : MonoBehaviour
{
    [Header("[ Components ] ")]
    [SerializeField] internal Transform Airfoil = default;
    [SerializeField] internal Transform Bumper = default;
    [SerializeField] internal Transform Painting = default;
    [SerializeField] internal Transform TireA = default;
    [SerializeField] internal Transform TireDefault = default;

    [Header("Car Data")]
    [SerializeField] private CarsList CarData = default;

    public Material[] material = default;
    public bool newcolor;

    private void ChangeComponents()
    {
        #region Airfoil
        if (!Airfoil.gameObject.activeInHierarchy && CarData.Airfoil) { Airfoil.gameObject.SetActive(true); }
        if (!CarData.Airfoil)
        {
            Airfoil.gameObject.SetActive(false);
        }

        #endregion

        #region Bumber
        if (!Bumper.gameObject.activeInHierarchy && CarData.Bumper) { Bumper.gameObject.SetActive(true); }
        if (!CarData.Bumper)
        {
            Bumper.gameObject.SetActive(false);
        }
        #endregion

        #region TireA
        if (!TireA.gameObject.activeInHierarchy && CarData.TireA) { TireA.gameObject.SetActive(true); TireDefault.gameObject.SetActive(false); }
        if (!CarData.TireA)
        {
            TireA.gameObject.SetActive(false);
            TireDefault.gameObject.SetActive(true);
        }
        #endregion

        #region NewColor
        if (CarData.Painting)
        {
            GetComponent<MeshRenderer>().material = material[1];
        }
        else
        {
            GetComponent<MeshRenderer>().material = material[0];
        }
        #endregion
    }

    #region Obsever Settings
    private void OnEnable()
    {
        Shopping.OnUpdateComponents += ChangeComponents;
    }
    private void OnDisable()
    {
        Shopping.OnUpdateComponents -= ChangeComponents;

    }
    #endregion
}
