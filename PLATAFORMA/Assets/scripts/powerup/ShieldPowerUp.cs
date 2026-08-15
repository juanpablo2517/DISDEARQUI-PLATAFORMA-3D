using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
using System.Collections;

public class ShieldPowerUp : MonoBehaviour
{
    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();

        if (player != null)
        {
            player.StartCoroutine(player.ActivateShield(duration));
            Destroy(gameObject);
        }
    }
}