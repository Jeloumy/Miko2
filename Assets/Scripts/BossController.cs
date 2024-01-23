using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject meteoritePrefab; 
    private float fireballDelay = 7f;
    public GameObject darknessSquare; 
    public GameObject playerSquare; 
    private float darknessDelay = 13f;
    private float darknessDuration = 5f;
    private float meteoriteDelay = 30f; 

    private void Start()
    {
        Invoke("LaunchFireball", fireballDelay);
        InvokeRepeating("ToggleDarkness", darknessDelay, darknessDelay);
        InvokeRepeating("LaunchMeteorites", meteoriteDelay, meteoriteDelay);
    }

    void LaunchFireball()
    {
    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

    // Pas besoin de code supplémentaire pour démarrer l'animation si elle est configurée pour démarrer automatiquement

    Invoke("LaunchFireball", fireballDelay);
    }

    void ToggleDarkness()
    {
        bool isDark = darknessSquare.activeSelf;

        if (!isDark)
        {
            darknessSquare.SetActive(true);
            darknessSquare.transform.position = playerSquare.transform.position;
            Invoke("HideDarkness", darknessDuration); 

        }
    }

    void HideDarkness()
    {
        darknessSquare.SetActive(false);

    }

void LaunchMeteorites()
{
    int meteoriteCount = Random.Range(2, 4); // Lance 2 ou 3 météorites
    for (int i = 0; i < meteoriteCount; i++)
    {
        // Position aléatoire en haut
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 10f, 0f);

        GameObject meteorite = Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);
        
        // Ajoutez ici un Rigidbody2D à votre préfabriqué de météorite pour gérer la physique
        Rigidbody2D rb = meteorite.GetComponent<Rigidbody2D>();

        // Vitesse aléatoire vers le bas et sur les côtés
        float horizontalSpeed = Random.Range(-3f, 3f); // Vitesse horizontale aléatoire
        float verticalSpeed = -Random.Range(1f, 5f); // Vitesse verticale aléatoire (toujours vers le bas)
        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}

}
