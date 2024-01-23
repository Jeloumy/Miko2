using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ennemi"))
        {
            Die();
        }
    }

    void Die()
    {

        gameOverPanel.SetActive(true);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToWorld()
    {
        SceneManager.LoadScene("MondeScene");
    }
}
