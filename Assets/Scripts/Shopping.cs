using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    [Header("Shopping")]
    [SerializeField] private bool Airfoil = default;
    [SerializeField] private bool Bumper = default;
    [SerializeField] private bool Painting = default;
    [SerializeField] private bool TireA = default;

    [SerializeField] [Range(1, 2)] private int SelectedCar = default;

    private void Update()
    {
        CustomCar(SelectedCar);
    }

    private void CustomCar(int Car) 
    {

    }
}
