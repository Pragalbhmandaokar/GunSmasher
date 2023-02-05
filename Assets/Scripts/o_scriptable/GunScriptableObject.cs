using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScriptableObject : ScriptableObject
{
    public string name;
    public GameObject ModelPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;

    public ShootConfiguration shootConfiguration;

    private MonoBehaviour ActiveMonoBehaviour;
    private GameObject Model;
    private float LastShootTime;
    private ParticleSystem ShootSystem;

    public void Shoot()
    {
        if (Time.time > shootConfiguration.FireRate + LastShootTime)
        {
            LastShootTime = Time.time;
            ShootSystem.Play();
            Vector3 shootDirection = ShootSystem.transform.forward +
                new Vector3(
                    Random.Range(
                        -shootConfiguration.spread.x,
                    shootConfiguration.spread.x), Random.Range(
                        -shootConfiguration.spread.y,
                    shootConfiguration.spread.y), Random.Range(
                        -shootConfiguration.spread.z,
                    shootConfiguration.spread.z));
            shootDirection.Normalize();

            
        }
    }
    public void Spawn(Transform Parent, MonoBehaviour ActiveMonoBehaviour)
    {
        this.ActiveMonoBehaviour =  ActiveMonoBehaviour;
        LastShootTime = 0;
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.localPosition = SpawnPoint;
        Model.transform.localRotation = Quaternion.identity;

        ShootSystem= Model.GetComponent<ParticleSystem>();
    }
}
