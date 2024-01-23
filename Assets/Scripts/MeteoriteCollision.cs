using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollision : MonoBehaviour
{
        public GameObject flamePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("SolTag"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Instantiate(flamePrefab, contactPoint, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
