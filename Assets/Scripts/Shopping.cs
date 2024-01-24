using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public static event Action OnUpdateComponents; 

    [Header("Shopping")]
    [SerializeField] private bool Airfoil = default;
    [SerializeField] private bool Bumper = default;
    [SerializeField] private bool Painting = default;
    [SerializeField] private bool TireA = default;

    [SerializeField] [Range(1, 2)] private int SelectedCar = default;


    [SerializeField] private CarsList[] CarsData = default;
    [Header("Car List")]
    [SerializeField] private Transform[] Cars = default;

    private void Start()
    {
        ReadCurrentSettings();
    }
    private void Update()
    {
        CustomCar(SelectedCar);
    }

    private void ReadCurrentSettings()
    {
        Airfoil = CarsData[0].Airfoil;
        Bumper = CarsData[0].Bumper;
        Painting = CarsData[0].Painting;
        TireA = CarsData[0].TireA;

        UpdateComponent();
    }

    private void CustomCar(int Car)
    {
        switch (Car)
        {
            case 1:
                if (CarsData[0].Airfoil != Airfoil) { CarsData[0].Airfoil = Airfoil; print("check 1"); UpdateComponent(); }
                if (CarsData[0].Bumper != Bumper) { CarsData[0].Bumper = Bumper; print("check 2"); UpdateComponent(); }
                if (CarsData[0].TireA != TireA) { CarsData[0].TireA = TireA; print("check 3"); UpdateComponent(); }
                if (CarsData[0].Painting != Painting) { CarsData[0].Painting = Painting; print("check 4"); UpdateComponent(); }
                break;
        }
    }
    private void UpdateComponent()
    {
        OnUpdateComponents?.Invoke();
    }
  
    #region Button Controller
    public void AddAirFoil()
    {
        if (Airfoil) { Airfoil = false; } else { Airfoil = true; }
    }
    public void AddABumbper()
    {
        if (Bumper) { Bumper = false; } else { Bumper = true; }
    }
    public void AddPainting()
    {
        if (Painting) { Painting = false; } else { Painting = true; }
    }
    public void AddWheel()
    {
        if (TireA) { TireA = false; } else { TireA = true; }
    }
    public void Exit() 
    {
        SceneManager.LoadScene("Racing Track");
    }
    #endregion
}
