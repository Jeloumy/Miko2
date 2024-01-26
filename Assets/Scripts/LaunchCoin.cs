using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCoin : MonoBehaviour
{
public GameObject coinPrefab; // Le prefab de la pièce à lancer
    public float launchForce = 10f; // La force avec laquelle la pièce est lancée

    void Update()
    {
        // Lancer une pièce quand le joueur appuie sur une touche (par exemple, espace)
        if (Input.GetKeyDown(KeyCode.E) && Inventory.instance.coinsCount > 0)
        {
            Launch();
            Inventory.instance.AddCoin(-1); // Décrémenter le nombre de pièces
        }
    }

void Launch()
{
    GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
    Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();

    if (rb != null)
    {
        // Lancer la pièce horizontalement vers la droite
        rb.velocity = new Vector2(launchForce, 0);
    }
    else
    {
        Debug.LogError("Rigidbody2D manquant sur le prefab de la pièce.");
    }
}


}
