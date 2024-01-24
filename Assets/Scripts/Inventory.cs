using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    public int specialItemsCount;
    public Text specialItemsCountText;

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
        
    }

    public void AddSpecialItem(int count)
    {
        specialItemsCount += count;
        specialItemsCountText.text = specialItemsCount.ToString();
     }


    private void WinGame()
    {
        // Code pour gérer la victoire
        Debug.Log("Victoire! Tu as collecté 5 pièces!");
        
        SceneManager.LoadScene("Level2");
        Inventory.instance.AddSpecialItem(1);
    }
}
