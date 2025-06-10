using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 3f;
    public float distanceTraveled = 0f; // Tracks how far enemy has moved
    Transform target;
    public int coinValue = 10;


    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * move);
        distanceTraveled += move;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            CoinManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }

}


