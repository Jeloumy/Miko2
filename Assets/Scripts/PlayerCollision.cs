using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject redOverlay; // Référence au calque rouge

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ennemi"))
        {
            Die();
        }
    }

    void Die()
    {
        // Afficher le calque rouge
        if (redOverlay != null)
        {
            redOverlay.SetActive(true);
        }

        // Mettre le jeu en pause
        Time.timeScale = 0;

        // Afficher le panneau Game Over
        gameOverPanel.SetActive(true);
    }

    public void RetryLevel()
    {
        // Réinitialiser le temps avant de recharger la scène
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToWorld()
    {
        // Réinitialiser le temps avant de changer de scène
        Time.timeScale = 1;
        SceneManager.LoadScene("MondeScene");
    }
}
