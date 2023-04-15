using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            int index = UnityEngine.Random.Range(0, _clips.Length);
            //AudioClip clip = _clips[index];
            //GetComponent<AudioSource>().PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Collision was too slow to play a sound " + collision.relativeVelocity.magnitude);
        }
    }
}
