using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjet : MonoBehaviour
{

    public GameObject objectToDrop; // Référence au prefab de l'objet à lâcher
    public Vector3 spawnPosition; // Position de départ pour l'objet qui tombe

    private void Start()
    {
        // Commence à lâcher des objets toutes les 10 secondes
        InvokeRepeating("Drop", 0f, 10f); // Commence immédiatement et répète toutes les 10 secondes
    }

    void Drop()
    {
        // Instancier l'objet à la position définie
        Instantiate(objectToDrop, spawnPosition, Quaternion.identity);
    }
}
