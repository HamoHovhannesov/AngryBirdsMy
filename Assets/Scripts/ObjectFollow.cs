using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    
    Transform Target = null;
    [SerializeField] Transform CameraMainPosition;
    [SerializeField] Vector3 offset;
    void Update()
    {
        if (Target != null)
        {
            transform.position = new Vector3(Target.position.x + offset.x, Target.position.y + offset.y, Target.position.z);
        }
        else
        {
            transform.position = CameraMainPosition.position;
        }
        
    }
    public void GetTarget(Transform target)
    {
        Target = target;
    }
}
