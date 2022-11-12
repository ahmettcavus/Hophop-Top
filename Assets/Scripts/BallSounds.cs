using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Transparent")
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
        }
    }
}
