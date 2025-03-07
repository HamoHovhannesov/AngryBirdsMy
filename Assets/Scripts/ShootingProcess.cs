using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ShootingProcess : MonoBehaviour
{
    ObjectFollow objectFollow;
    [SerializeField] GameObject Bullet;
    GameObject BulletInstance = null;
    [SerializeField] Trajectory trajectory;
    [SerializeField] Transform ShootingPoint;
    [SerializeField] float Maxforce;
    [SerializeField] float Minforce;
    [SerializeField] float Increment;
    [SerializeField] Image Charge;
    [SerializeField] int Counter = 3;
    [SerializeField] float ScreenToWorldPointOffset; 
    Camera mainCamera;
    float force;
    float minXRotation = 250f;

    float x;
    

    private void Start()
    {
        objectFollow = FindObjectOfType<ObjectFollow>();
        mainCamera = Camera.main;
        force = 0;
        GameManager.bulletsLeft = Counter;
    }
    private void Update()
    {
        if (BulletInstance == null && Counter > 0 && GameManager.GameEnded == false)
        {
            BulletLaunch();
            CannonRatate();
        }
        Charge.fillAmount = force/Maxforce*5;
    }

    void BulletInstantiate()
    {
        Counter--;
        BulletInstance = Instantiate(Bullet, ShootingPoint.position, transform.rotation);

        objectFollow.GetTarget(BulletInstance.transform);
        BulletInstance.GetComponent<Bullet>().Shoot(force,Counter);
        force = 0;
        Charge.fillAmount = 0f;

    }

    public void BulletLaunch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            trajectory.Show();
        }
        if (Input.GetMouseButton(0))
        {
            force += Time.deltaTime * Increment;
            force = Mathf.Clamp(force, Minforce, Maxforce);
            if(force < Maxforce / 2)
            {
             trajectory.UpdateTrajectory(ShootingPoint.position, ShootingPoint.forward * force);
            }
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            trajectory.Hide();
            BulletInstantiate();
        }

    }
    void CannonRatate()
    {
        transform.LookAt(mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenToWorldPointOffset)));
    }
}


