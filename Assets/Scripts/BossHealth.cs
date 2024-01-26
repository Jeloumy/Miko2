using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public LevelManager levelManager;
    public int health = 5; // La santé initiale du boss

void Start()
{
    levelManager = LevelManager.Instance; // Obtenez la référence au singleton
}
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

void CompleteLevelAndReturn()
{
    // L'index 0 représente le Niveau 1 dans votre tableau
    levelManager.CompleteLevel(3);

    // Retour à la scène "MondeScene"
    SceneManager.LoadScene("MondeScene");
}
    void Die()
    {
        // Implémentez la logique de mort du boss ici
        CompleteLevelAndReturn();
        SceneManager.LoadScene("MondeScene");
    }
}
