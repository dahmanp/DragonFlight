using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class Solaris : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] GameObject _completeLevelUI;
    public int bossHealth = 20;

    bool _hasDied;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Start()
    {
        while (_hasDied == false)
        {
            float delay = UnityEngine.Random.Range(5, 30);
            yield return new WaitForSeconds(delay);
            if (_hasDied == false)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ebhi")
        {
            bossHealth -= 2;
            _particleSystem.Play();
        }
            if (bossHealth == 0)
            {
                StartCoroutine(Die());
            }
    }

    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (bossHealth == 0)
        {
            _completeLevelUI.SetActive(true);
        }
    }
}