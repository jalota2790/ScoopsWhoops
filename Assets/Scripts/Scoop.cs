using UnityEngine;

public class Scoop : MonoBehaviour
{
    public float speed;

    public bool isFalling;

    private void Update()
    {
        if (isFalling)
            transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFalling) return;

        if (collision.gameObject.CompareTag("Floor"))
        {
            GameController.instance.EndGame();
        }
    }
}