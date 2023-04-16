using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    //Rigidbody2D flameRB;
    //public float flameSpeed;
    //GameObject target;
    public GameObject flame;
    public Transform flamePos;
    private float timer;

    public float onscreenDelay = 2f;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(flame, flamePos.position, Quaternion.identity);
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}