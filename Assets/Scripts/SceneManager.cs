using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int levelIndex; // L'index de ce niveau
    public LevelManager levelManager; // Référence au LevelManager
    public SpriteRenderer spriteRenderer; // Référence au SpriteRenderer du bouton
    public Sprite unlockedSprite; // Sprite pour un niveau débloqué
    public Sprite completedSprite; // Sprite pour un niveau complété
    public Sprite lockedSprite; // Sprite pour un niveau verrouillé

void OnEnable()
{
    if (LevelManager.Instance == null)
    {
        levelManager = FindObjectOfType<LevelManager>(); // Recherche de secours
    }
    else
    {
        levelManager = LevelManager.Instance;
    }

    if (levelManager == null)
    {
        Debug.LogError("LevelManager is still null in SceneChanger");
        return; // Empêche l'exécution ultérieure de la méthode si levelManager est null
    }

    spriteRenderer = GetComponent<SpriteRenderer>();
    UpdateButtonSprite();
}


    void Start()
    {
        
    levelManager = LevelManager.Instance; // Obtenez la référence au singleton
    spriteRenderer = GetComponent<SpriteRenderer>();
    UpdateButtonSprite();
    }

    void UpdateButtonSprite()
    {
        if (levelManager.IsLevelCompleted(levelIndex))
        {
            spriteRenderer.sprite = completedSprite; // Le niveau est complété
        }
        else if (levelManager.IsLevelCompleted(levelIndex - 1))
        {
            spriteRenderer.sprite = unlockedSprite; // Le niveau est débloqué mais pas encore complété
        }
        else
        {
            spriteRenderer.sprite = lockedSprite; // Le niveau est verrouillé
        }
    }

    private void OnMouseDown()
    {
        if (levelManager.IsLevelCompleted(levelIndex - 1)) // Le niveau précédent doit être complété pour accéder à celui-ci
        {
            SceneManager.LoadScene("Niveau" + levelIndex + "Scene");
        }
    }
}
