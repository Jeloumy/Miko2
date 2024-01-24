using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance; // Singleton instance
    public bool[] levelsCompleted;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        int levelCount = SceneManager.sceneCountInBuildSettings;
        levelsCompleted = new bool[levelCount];
        levelsCompleted[0] = true; // Le premier niveau est débloqué par défaut
    }

    public void CompleteLevel(int levelIndex)
    {
        if (levelIndex < levelsCompleted.Length - 1)
        {
            levelsCompleted[levelIndex] = true; // Marquez le niveau actuel comme complété
            levelsCompleted[levelIndex + 1] = true; // Débloquez le prochain niveau
        }

        // Optionnel : Sauvegarder la progression
        PlayerPrefs.SetInt("Level" + levelIndex + "Completed", 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelCompleted(int levelIndex)
    {
        return levelIndex < levelsCompleted.Length && levelsCompleted[levelIndex];
    }
}
