using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    public GameObject interactionButton;
    public GameObject shopInterface;
    private bool isPlayerNearby = false;
    private void Update()
    {
        // Vérifier si le joueur est à proximité et appuie sur "E"
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (shopInterface != null) // Vérifiez que shopInterface n'est pas null
            {
                shopInterface.SetActive(!shopInterface.activeSelf);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionButton != null) // Vérifiez que interactionButton n'est pas null
            {
                interactionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionButton != null) // Vérifiez que interactionButton n'est pas null
            {
                interactionButton.SetActive(false);
            }
            if (shopInterface != null) // Vérifiez que shopInterface n'est pas null
            {
                shopInterface.SetActive(false);
            }
        }
    }
}
