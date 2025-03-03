using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingProcess : MonoBehaviour
{

    [SerializeField] GameObject Bullet;
    GameObject BulletInstance = null;
    [SerializeField] Transform ShootingPoint;
    [SerializeField] float Maxforce;
    [SerializeField] float Minforce;
    [SerializeField] float inkremet;
    [SerializeField] LayerMask mask;
    float force;
    float minXRotation = 250f;

    Camera mainCamer;
    Ray ray;
    RaycastHit hit;

    
    private void Start()
    {
        force = 0;
    }
    private void Update()
    {
        if (BulletInstance == null)
        {
            BulletLaunch();
        }

        CannonRatate();
    }
    
    void BulletInstantiate()
    {
        Debug.Log("mta");
        force = Mathf.Clamp(force, Minforce, Maxforce);

        BulletInstance = Instantiate(Bullet, ShootingPoint.position,Quaternion.identity);

        CameraController.GetBullet(BulletInstance.transform);
        BulletInstance.GetComponent<Bullet>().Shoot(force,transform.up);
    }

    void BulletLaunch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            force = 0;
        }
        if (Input.GetMouseButton(0))
        {
            force += Time.deltaTime * inkremet;

        }
        if (Input.GetMouseButtonUp(0))
        {
            BulletInstantiate();

        }


    }
    void CannonRatate()
    {

        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float zRotation = -Quaternion.LookRotation(pos - transform.position, Vector3.up).eulerAngles.z;
        //float yRotation = -Quaternion.LookRotation(pos = transform.position, Vector3.up).eulerAngles.y;
        //transform.rotation = Quaternion.Euler(0, yRotation, zRotation);
       
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            Debug.Log("aasassas");
            Vector3 point = hit.point;
            Debug.Log(hit.point);

            var xrotation =  Quaternion.LookRotation(point - transform.position, Vector3.forward).eulerAngles.x;
            //xrotation = Mathf.Min(xrotation-100, minXRotation);
            //point.z = transform.position.z;
            var yrotation = Quaternion.LookRotation(point - transform.position,Vector3.forward).eulerAngles.y;
            var zrotation = Quaternion.LookRotation(point - transform.position,Vector3.forward).eulerAngles.z;
            Debug.Log(xrotation);
            if (xrotation >= 365)
            {
                xrotation = 365;
            }
            transform.rotation = Quaternion.Euler(xrotation-100, yrotation,zrotation-90);
        }


    }


}


