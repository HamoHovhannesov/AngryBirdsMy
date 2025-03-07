using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip deathClip;
    void Start()
    {

    }

    void Update()
    {

    }
    public void OnEmenyDeath()
    {
        audioSource.PlayOneShot(deathClip);
    }

}
