using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject fireballPrefab;
    public GameObject meteoritePrefab; 
    private float fireballDelay = 2f;
    public GameObject darknessSquare; 
    public GameObject playerSquare; 
    private float darknessDelay = 10f;
    private float darknessDuration = 5f;
    private float meteoriteDelay = 10f; 

    private void Start()
    {
        Invoke("LaunchFireball", fireballDelay);
        InvokeRepeating("ToggleDarkness", darknessDelay, darknessDelay);
        InvokeRepeating("LaunchMeteorites", meteoriteDelay, meteoriteDelay);
    }

    void LaunchFireball()
    {
    GameObject fireballInstance = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

    // Assurez-vous que l'Animator est bien réveillé et prêt à jouer l'animation
    Animator fireballAnimator = fireballInstance.GetComponent<Animator>();
    if (fireballAnimator != null)
    {
        fireballAnimator.Rebind();
    }

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
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 10f, 0f);
        GameObject meteorite = Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = meteorite.GetComponent<Rigidbody2D>();
        float horizontalSpeed = Random.Range(-3f, 3f); // Vitesse horizontale aléatoire
        float verticalSpeed = -Random.Range(3f, 7f); // Augmenter la vitesse verticale
        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}


}
