using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] GameObject objectThatNeedToBeDestroyed;
    [SerializeField] ParticleSystem Enamy_partiicle;
    [SerializeField] float objectHelthBar;
    float helth;
      


    void Start()
    {
        helth = objectHelthBar;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        helth -= collision.relativeVelocity.magnitude;
        if (helth <= 0)
        {
            GameManager.enemy--;
            Destroy(gameObject);
            Instantiate(Enamy_partiicle, transform.position, new Quaternion());

        }
    } 
}
