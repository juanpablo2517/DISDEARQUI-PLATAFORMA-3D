using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Daño")]
    public int damage = 10;

    [Header("Escudo")]
    public bool hasShield = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Vida: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (hasShield)
        {
            Debug.Log("Escudo activo");
            return;
        }

        currentHealth -= amount;

        Debug.Log("Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public IEnumerator ActivateShield(float duration)
    {
        hasShield = true;

        Debug.Log("Escudo activado");

        yield return new WaitForSeconds(duration);

        hasShield = false;

        Debug.Log("Escudo terminado");
    }

    public IEnumerator IncreaseDamage(int extraDamage, float duration)
    {
        damage += extraDamage;

        Debug.Log("Daño aumentado");

        yield return new WaitForSeconds(duration);

        damage -= extraDamage;

        Debug.Log("Daño normal");
    }
}