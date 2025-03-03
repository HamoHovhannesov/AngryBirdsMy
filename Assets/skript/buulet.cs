using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buulet : MonoBehaviour
{
    Rigidbody rb;
    float fors;
    [SerializeField] float Maxfors;
    [SerializeField] float Minfors;
    [SerializeField] float inkrmet;
    private void Start()
    {
        fors = 0;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
          fors += Time.deltaTime*inkrmet;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            launch();

        }
    }
    void displeingbord()
    {
       
    }
    void launch()
    {
        fors = Mathf.Min(fors,Maxfors);
        fors = Mathf.Max(fors, Minfors);
        rb.AddForce(transform.forward*fors,ForceMode.Impulse);

    }
}


