using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot config", menuName = "Gun configuration" ,order =2)]
public class ShootConfiguration : ScriptableObject
{

    public Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);
    public float FireRate = 0.25f;

   
}
