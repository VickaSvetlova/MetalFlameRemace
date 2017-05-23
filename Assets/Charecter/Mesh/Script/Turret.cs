using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    #region Enums
    #endregion

    #region Delegates
    #endregion

    #region Structures
    #endregion

    #region Classes
    #endregion

    #region Fields
    public Robot _robot;
    #endregion

    #region Events
    #endregion

    #region Properties
    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;
    public float speedT = 5;

    private float timeToFire = 0;
    private Transform firePoint;
    public Vector3 MousePos;
    private float rotationOffset;
    
    #endregion
    #region Methods
    private void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
          //  Debug.LogError("not fire point");
        }
    }
    private void Update()
    {
        MouseAming();
        if (fireRate == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }

        }
      
    }
    private void MouseAming()
    {
        //var mousePos = Input.mousePosition;
        //mousePos.z = 1;
        //var pos = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.Log(pos);
        //Quaternion rot = Quaternion.LookRotation(transform.position-pos, Vector3.forward);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.time * speedT);
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * speedT);



    }

    private void Shoot()
    {

    }
    #endregion

    #region Event Handlers
    #endregion
}
