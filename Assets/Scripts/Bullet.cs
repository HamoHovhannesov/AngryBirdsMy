using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float DestroyTime = 5f;
    Rigidbody rb ;

    int BulletsLeft;
    
    void Update()
    {
            DestroyTime -= Time.deltaTime;
            if(DestroyTime <= 0)
            {
                GameManager.manager.UpdateBulletCount(BulletsLeft);
                Destroy(gameObject);
            }
    }

    public void Shoot(float force,int bulletsLeft)
    {
        BulletsLeft = bulletsLeft;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
    
}
