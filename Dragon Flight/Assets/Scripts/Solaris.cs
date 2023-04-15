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
    [SerializeField] GameObject _healthBars;
    public int maxBossHealth = 20;
    public int currentBossHealth;
    public HealthBar healthBar;
    public AnimationCurve Curve;

    bool _hasDied;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Start()
    {
        currentBossHealth = maxBossHealth;
        healthBar.SetMaxHealth(maxBossHealth);
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
            currentBossHealth -= 2;
            healthBar.SetHealth(currentBossHealth);
            _particleSystem.Play();
        }
            if (currentBossHealth == 0)
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
        transform.position = new Vector3(transform.position.x, Curve.Evaluate((Time.time % Curve.length)), transform.position.z);
        if (currentBossHealth == 0)
        {
            _completeLevelUI.SetActive(true);
            _healthBars.SetActive(false);
        }
    }
}