using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            Debug.Log("Collision was too slow to play a sound " + collision.relativeVelocity.magnitude);
        }
    }
}
