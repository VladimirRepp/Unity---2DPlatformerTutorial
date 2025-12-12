using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Action OnPlayerDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
