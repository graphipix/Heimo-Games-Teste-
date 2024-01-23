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

        #endregion

        #region Bumber
        if (!Bumper.gameObject.activeInHierarchy && CarData.Bumper) { Bumper.gameObject.SetActive(true); }

        #endregion

        #region TireA
        if (!TireA.gameObject.activeInHierarchy && CarData.TireA) { TireA.gameObject.SetActive(true); TireDefault.gameObject.SetActive(false); }

        #endregion

        #region NewColor
        if (newcolor)
        {
            GetComponent<MeshRenderer>().material = material[1];
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
