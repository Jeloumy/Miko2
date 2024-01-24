using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMouvement : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector2 direction; // Déclaration de la direction

    void Start()
    {
        // Angle aléatoire pour la direction initiale
        float angle = Random.Range(-30f, 30f);
        direction = Quaternion.Euler(0, 0, angle) * Vector2.left;
    }

    void Update()
    {
        // Appliquer le mouvement
        transform.Translate(direction * speed * Time.deltaTime);
    }
}


