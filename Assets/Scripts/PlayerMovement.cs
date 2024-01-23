using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Animator animator; // Référence à l'Animator

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool standBy = true; // Mode standBy actif par défaut
    private float inactivityTimer = 0f; // Timer pour l'inactivité

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Réinitialiser le standBy et le timer si le joueur bouge
        if (horizontalInput != 0)
        {
            transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);
            transform.localScale = horizontalInput > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

            animator.SetBool("IsMoving", true);
            standBy = false;
            inactivityTimer = 0f;
        }
        else
        {
            animator.SetBool("IsMoving", false);
            if (!standBy)
            {
                inactivityTimer += Time.deltaTime;
                if (inactivityTimer > 5f)
                {
                    animator.SetTrigger("Idle");
                    standBy = true; // Retour en mode standBy après le déclenchement de l'animation Idle
                }
            }
        }

        // Gestion du saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolTag"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SolTag"))
        {
            isGrounded = false;
        }
    }

    // Appelée à la fin de l'animation Idle
    public void ResetStandBy()
    {
        standBy = false;
        inactivityTimer = 0f;
    }
}
