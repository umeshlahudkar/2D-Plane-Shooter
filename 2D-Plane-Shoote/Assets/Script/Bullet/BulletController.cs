using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float bulletDamage;
    private Vector2 direction;

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
        transform.Translate(direction * Time.deltaTime * speed);

        if(transform.position.y >= 5 || transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if(enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    public void SetReference(Vector2 direction, float bulletDamage)
    {
        this.direction = direction;
        this.bulletDamage = bulletDamage;
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
