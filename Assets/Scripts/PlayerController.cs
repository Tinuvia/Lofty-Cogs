using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float floatForce;

    [Header("Effects")]
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    [HideInInspector] public int cogs;
    [HideInInspector] public int playerHealth;

    private float maxHeight;
    private float minHeight;
    private float gravityModifier = 1.5f;
    private Rigidbody2D playerRb;
    private bool isLowEnough = true;
    private AudioSource playerAudio;



    // Start is called before the first frame update
    void Start()
    {
        // Get components and initialize variable values
        playerRb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
        maxHeight = 10;// background.GetComponent<BoxCollider>().size.y;

        Physics.gravity *= gravityModifier;
        minHeight = 0.0f;

        playerHealth = 50;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Check that the player is within borders
        if (transform.position.y > maxHeight)
        {
            isLowEnough = false;
        }
        else
        {
            isLowEnough = true;
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !GameManager.instance.isGameOver && isLowEnough)
        {
            playerRb.AddForce(Vector2.up * floatForce);
        }                                 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (collision.gameObject.CompareTag("Hazard"))
        {
            /*
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            */
            TakeDamage(10);
            collision.gameObject.SetActive(false);
        }

        // if player collides with money, fireworks
        else if (collision.gameObject.CompareTag("Pickup"))
        {
            /*
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            */
            cogs += 10;
            Debug.Log("Cogs: " + cogs);
            collision.gameObject.SetActive(false);
        }

        // if player collides with ground, epush the player up again
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        Debug.Log("The airship has taken damage!");

        if (playerHealth <= 0)
        {
            Debug.Log("The airship is completely broken!");
        }
    }

    // REFACTORING:
    // set damage from hazards as the value from the SO or script on gameobject
}
