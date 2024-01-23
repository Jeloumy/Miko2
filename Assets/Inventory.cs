using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance");
            return;
        }
        instance = this;
    }

    public void AddCoin(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
        if (coinsCount >= 5)
        {
            // Le joueur gagne
            WinGame();
        }


    }
    private void WinGame()
    {
        // Code pour gérer la victoire
        Debug.Log("Victoire! Tu as collecté 5 pièces!");

        // Par exemple, tu pourrais charger une scène de victoire ou afficher un écran de victoire
        // SceneManager.LoadScene("NomDeLaSceneDeVictoire");
    }
}
