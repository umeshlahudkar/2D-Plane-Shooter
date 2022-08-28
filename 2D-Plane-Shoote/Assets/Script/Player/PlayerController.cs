using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject bulletPos1;
    [SerializeField] private GameObject bulletPos2;

    private float verticalInput, horrizontalInput;
    [SerializeField] private float speed;
    private float playerHealth = 100;
    private float timeElapced;
    private float bulletSpwanInterval = 0.3f;
    private float bulletDamage = 20;

    public static event Action OnPlayerDied;
   
    private void Start()
    {
        healthBar.maxValue = playerHealth;
        healthBar.value = playerHealth;
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horrizontalInput = Input.GetAxis("Horizontal");

        timeElapced += Time.deltaTime; 
        if(timeElapced >= bulletSpwanInterval)
        {
            timeElapced = 0;
            FireBullet();
        }

        Move();
        PlayerClamp();
    }

    private void Move()
    {
        Vector2 playerPos = gameObject.transform.position;

        playerPos.x += speed * horrizontalInput * Time.deltaTime;
        playerPos.y += speed * verticalInput * Time.deltaTime;

        gameObject.transform.position = playerPos;
    }

    private void PlayerClamp()
    {
        Vector2 playerPos = gameObject.transform.position;
        if (playerPos.x >= 2.0f) { playerPos.x = 2.0f; gameObject.transform.position=playerPos; }
        if (playerPos.x <= -2.0f) { playerPos.x = -2.0f; gameObject.transform.position = playerPos; }
        if (playerPos.y >= 4.4f) { playerPos.y = 4.4f; gameObject.transform.position = playerPos; }
        if (playerPos.y <= -4.4f) { playerPos.y = -4.4f; gameObject.transform.position = playerPos; }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            this.enabled = false;
            OnPlayerDied?.Invoke();
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = playerHealth;
    }

    private void FireBullet()
    {
        BulletController bullet = Instantiate<BulletController>(bulletPrefab, bulletPos1.transform.position, Quaternion.identity);
        bullet.SetReference(Vector2.up, bulletDamage);

        bullet = Instantiate<BulletController>(bulletPrefab, bulletPos2.transform.position, Quaternion.identity);
        bullet.SetReference(Vector2.up, bulletDamage);
    }
}
