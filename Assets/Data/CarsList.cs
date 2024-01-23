using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CarList")]
public class CarsList : ScriptableObject
{
    [SerializeField] internal bool Airfoil = default;
    [SerializeField] internal bool Bumper = default;
    [SerializeField] internal bool Painting = default;
    [SerializeField] internal bool TireA = default;
}
