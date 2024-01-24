using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PrisonInteraction : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject square;
    private bool isPlayerNearby = false;

    void Start()
    {
        levelManager = LevelManager.Instance;
    }

    void Update()
    {
        // Activez ou désactivez le carré en fonction de la proximité du joueur
        if (square != null)
        {
            square.SetActive(isPlayerNearby);
        }

        // Vérifiez si le joueur est à proximité, a au moins 5 pièces et appuie sur "E"
        if (isPlayerNearby && Inventory.instance.coinsCount >= 5 && Input.GetKeyDown(KeyCode.E))
        {
            CompleteLevelAndReturn();
        }
    }

    private void CompleteLevelAndReturn()
    {
        // Vérifiez si le joueur a au moins 5 pièces
        if (Inventory.instance.coinsCount >= 5)
        {
            // L'index 0 représente le Niveau 1 dans votre tableau
            levelManager.CompleteLevel(0);

            // Retour à la scène "MondeScene"
            SceneManager.LoadScene("MondeScene");
        }
        else
        {
            // Peut-être afficher un message indiquant que le joueur n'a pas assez de pièces
            Debug.Log("Vous n'avez pas assez de pièces pour terminer ce niveau.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
