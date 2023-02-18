using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource sfxSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            sfxSource.Play();
            Debug.Log("play");
        }
    }
}
