using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au transform du personnage principal
    public Vector3 offset; // Offset pour la position de la caméra par rapport au joueur

    void Update()
    {
        // Mettez à jour la position de la caméra pour qu'elle suive le joueur
        transform.position = target.position + offset;
    }
}
