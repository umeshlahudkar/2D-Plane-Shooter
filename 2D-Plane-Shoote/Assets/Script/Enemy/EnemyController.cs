using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform bulletsPos;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Slider healthBar;

    private float enemyHealth = 100;
    private float moveSpeed = 3f;
    private float bulletFireInterval = 0.3f;
    private float timeElapced = 3f;
    private float bulletDamage = 5;

    private void Start()
    {
        PlayerController.OnPlayerDied += Disable;

        healthBar.maxValue = enemyHealth;
        healthBar.value = enemyHealth;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= Disable;
    }

    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        timeElapced += Time.deltaTime;
        if (timeElapced >= bulletFireInterval)
        {
            timeElapced = 0;
            FireBullet();
        }

        if (gameObject.transform.position.y <= -5.0f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = enemyHealth;
    }

    private void FireBullet()
    {
        BulletController bullet = Instantiate<BulletController>(bulletPrefab, bulletsPos);
        bullet.SetReference(Vector2.down, bulletDamage);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}
