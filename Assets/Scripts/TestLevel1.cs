using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel1 : MonoBehaviour
{
    public LevelManager levelManager; // Assurez-vous d'assigner cela dans l'inspecteur
void Start()
{
    levelManager = LevelManager.Instance; // Obtenez la référence au singleton
    CompleteLevelAndReturn();
}

void CompleteLevelAndReturn()
{
    // L'index 0 représente le Niveau 1 dans votre tableau
    levelManager.CompleteLevel(0);

    // Retour à la scène "MondeScene"
    SceneManager.LoadScene("MondeScene");
}

}
