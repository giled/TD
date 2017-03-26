
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed ;

    public float StartHealth = 100;
    private float health;
    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image HealtBar;


    private void Start()
    {
        speed = startSpeed;
        health = StartHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        HealtBar.fillAmount = health / StartHealth;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    void Die()
    {

        PlayerStats.Money += worth;

        GameObject effect=(GameObject) Instantiate(deathEffect,transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);
    }
   
}
