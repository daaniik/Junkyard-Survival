using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Enemy
{
    public float Health { get; set; } = 100f;
    public float Speed { get; set; } = 5f;
    public bool IsBurning { get; set; } = false;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        Console.WriteLine($"Enemy takes {amount} damage. Health now: {Health}");
    }

    public void ApplySlowness(float slowAmount, float duration)
    {
        float originalSpeed = Speed;
        Speed *= (1f - slowAmount);
        Console.WriteLine($"Enemy slowed! Speed: {Speed}");

        // Simulate delay (in a real game, you'd use coroutines or timers)
        System.Threading.Tasks.Task.Delay((int)(duration * 1000)).ContinueWith(_ =>
        {
            Speed = originalSpeed;
            Console.WriteLine("Slowness worn off. Speed back to: " + Speed);
        });
    }

    public void ApplyBurn(float damagePerSecond, float duration)
    {
        if (IsBurning) return;

        IsBurning = true;
        int ticks = (int)duration;
        System.Threading.Tasks.Task.Run(async () =>
        {
            for (int i = 0; i < ticks; i++)
            {
                TakeDamage(damagePerSecond);
                await System.Threading.Tasks.Task.Delay(1000);
            }
            IsBurning = false;
            Console.WriteLine("Burning effect ended.");
        });
    }
}

