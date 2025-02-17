using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f;  // Vitesse de déplacement
    public float jumpForce = 10f;  // Force de saut
    private Rigidbody rb;
    private bool isGrounded;  // Vérifie si la balle est au sol

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Récupère le Rigidbody de la balle
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0, Input.acceleration.y) * speed;
        rb.AddForce(movement, ForceMode.Acceleration);


        if (Input.touchCount > 0 && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Assurez-vous que le sol a le tag "Ground"
        {
            isGrounded = true;
        }
    }
}
