using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _damage = 30f;
    [SerializeField]
    private float _fireRate = 1f;
    [SerializeField]
    private float _range = 15f;
    [SerializeField]
    private float _force = 155f;
    [SerializeField]
    private ParticleSystem _muzzleFlash;
    [SerializeField]
    private Transform _bulletSpawn;
    [SerializeField]
    private Camera _cam;
   
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Instantiate(_bulletSpawn.position, _bulletSpawn.rotation);
        _muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit,_range))
        {
            Debug.Log("Pif-paf" + hit.collider);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _force);
            }
        }
    }

    private void Instantiate(Vector3 position, Quaternion rotation)
    {
        throw new NotImplementedException();
    }
}
