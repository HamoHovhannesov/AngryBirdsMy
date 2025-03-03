using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float offsetx;
    float offsety;
    [SerializeField] Transform buul;
    void Start()
    {
        offsetx=UnityEngine.Camera.main.transform.position.x-buul.transform.position.x;
        offsety = UnityEngine.Camera.main.transform.position.y- buul.transform.position.y;


    }

    // Update is called once per frame
    void Update()
    { 
       UnityEngine.Camera.main.transform.position = new Vector3(buul.position.x+offsetx,buul.position.y+offsety,buul.position.z);
    }
}
