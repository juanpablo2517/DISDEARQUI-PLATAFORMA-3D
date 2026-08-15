using UnityEngine;
using System.Collections;

public class DamagePowerUp : MonoBehaviour
{
    public int extraDamage = 10;
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();

        if (player != null)
        {
            player.StartCoroutine(player.IncreaseDamage(extraDamage, duration));
            Destroy(gameObject);
        }
    }
}