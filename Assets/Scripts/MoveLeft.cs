using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private float leftBound = -10;

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!GameManager.instance.isGameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
