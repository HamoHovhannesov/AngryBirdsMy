using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject cube;
    [SerializeField] int count;
    [SerializeField] float spaceBetween;

    Transform[] cubes;
    Vector3 position;
    float timeStamp;

    void Start()
    {
        Hide();
        cubes = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            cubes[i] = Instantiate(cube).transform;
            cubes[i].parent = parent.transform;
        }
    }

    public void Show()
    {
        parent.SetActive(true);
    }

    public void Hide()
    {
        parent.SetActive(false);
    }

    public void UpdateTrajectory(Vector3 startPoint, Vector3 force)
    {
        timeStamp = spaceBetween;
        for (int i = 0; i < count; i++)
        {
            position.x = (startPoint.x + force.x * timeStamp);
            position.z = (startPoint.z + force.z * timeStamp);
            position.y = (startPoint.y + force.y * timeStamp) - (Physics.gravity.magnitude * timeStamp * timeStamp) * 0.5f;

            cubes[i].position = position;
            //cubes[i].rotation = Quaternion.identity;
            timeStamp += spaceBetween;
        }
    }
}
