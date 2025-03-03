using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool TheBulletOnTheGround = false;
    [SerializeField] float DestroyTime = 3000f;
    Rigidbody rb ;
   
    void Start()
    {
        
    }
    
    void Update()
    {
        if (TheBulletOnTheGround)
        {

            Destroy(gameObject, DestroyTime);
        }

    }

    public void Shoot(float force, Vector3 offset)
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(force);
        rb.AddForce(offset*force, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            TheBulletOnTheGround = true;

        }
    }
}
