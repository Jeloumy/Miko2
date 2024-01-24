using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMouvement : MonoBehaviour
{

    public float speed = 2.0f;
     private Vector2 direction = Vector2.left; 
    // Start is called before the first frame update
    void Start()
    {
                direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(direction * speed * Time.deltaTime);
    }
}
