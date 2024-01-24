using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int health = 5; // La santé initiale du boss

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            TakeDamage(1); // Inflige des dégâts pour chaque pièce qui touche le boss
            Destroy(collision.gameObject); // Détruit la pièce
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // Méthode à appeler lorsque la santé du boss est épuisée
        }
    }

    void Die()
    {
        // Implémentez la logique de mort du boss ici
        SceneManager.LoadScene("MondeScene");
    }
}
