using UnityEngine;

public class CoinController : MonoBehaviour
{
    float speed = 5f;

    private void Start()
    {
        PlayerController.OnPlayerDied += Disable;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= Disable;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y <= -5.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}