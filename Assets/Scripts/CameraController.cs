using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float offsetx;
    float offsety;
    static Transform Bullet = null;
    [SerializeField] Transform Cannon;
    [SerializeField] Transform CameraMainPosition;
    void Start()
    {

        offsetx = transform.position.x - Cannon.position.x;
        offsety = transform.position.y - Cannon.position.y;


    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet != null)
        {
            transform.position = new Vector3(Bullet.position.x + 1.7f, Bullet.position.y + 0.4f, Bullet.position.z);
        }
        else
        {
            transform.position = CameraMainPosition.position;
        }
        
    }
    public static void GetBullet(Transform bullet)
    {
        Bullet = bullet;
    }
}
