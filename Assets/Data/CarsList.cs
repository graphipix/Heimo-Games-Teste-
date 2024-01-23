using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CarList")]
public class CarsList : ScriptableObject
{
    [SerializeField] private bool Airfoil = default;
    [SerializeField] private bool Bumper = default;
    [SerializeField] private bool Painting = default;
    [SerializeField] private bool TireA = default;
}
