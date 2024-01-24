using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestLevel3 : MonoBehaviour
{
    public LevelManager levelManager; // Start is called before the first frame update    public LevelManager levelManager; // Assurez-vous d'assigner cela dans l'inspecteur
void Start()
{
    levelManager = LevelManager.Instance; // Obtenez la référence au singleton
    CompleteLevelAndReturn();
}

void CompleteLevelAndReturn()
{
    // L'index 0 représente le Niveau 1 dans votre tableau
    levelManager.CompleteLevel(2);

    // Retour à la scène "MondeScene"
    SceneManager.LoadScene("MondeScene");
}
}
