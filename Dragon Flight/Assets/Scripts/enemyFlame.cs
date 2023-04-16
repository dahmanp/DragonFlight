using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlame : MonoBehaviour
{
    private GameObject ebhi;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ebhi = GameObject.FindGameObjectWithTag("Ebhi");

        Vector3 direction = ebhi.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ebhi"))
        {
            other.gameObject.GetComponent<Ebhi>().currentHealth -= 1;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("SafeZone"))
        {
            Destroy(gameObject);
        }
    }
}
