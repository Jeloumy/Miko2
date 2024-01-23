using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMouvement : MonoBehaviour
{

    public float speed = 2.0f;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
                direction = Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(direction * speed * Time.deltaTime);
    }
}
