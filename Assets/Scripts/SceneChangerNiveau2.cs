using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangerNiveau2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
        private void OnMouseDown()
    {
        // Réinitialiser le temps avant de recharger la scène
        Time.timeScale = 1;
        SceneManager.LoadScene("Niveau1Scene");
    }
}
