using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float verticalInput, horrizontalInput;
    int playerDamage = 5;
    public static bool isGameOver = false;
    [SerializeField]float speed;

    [SerializeField] GameObject bulletPos1;
    [SerializeField] GameObject bulletPos2;

    [SerializeField] GameObject bullet;

    [SerializeField] HealthBarController healthBarController;
    [SerializeField] GameObject gameOverScreen;

   
    private void Start()
    {
         InvokeRepeating("instantiateBullet", 2, 0.3f);
         isGameOver = false;
    }
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horrizontalInput = Input.GetAxis("Horizontal");

        Vector2 playerPos = gameObject.transform.position;

        playerPos.x += speed * horrizontalInput * Time.deltaTime;
        playerPos.y += speed * verticalInput * Time.deltaTime;

        gameObject.transform.position = playerPos;

        PlayerClamp();

        if(healthBarController.PlayerHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            isGameOver = true;
            this.enabled = false;
            CancelInvoke("instantiateBullet");
        }



    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBulletMovement>() != null)
        {
            healthBarController.HealthDecrement(playerDamage);
        }
    }

    void PlayerClamp()
    {
        Vector2 playerPos = gameObject.transform.position;
        if (playerPos.x >= 2.0f) { playerPos.x = 2.0f; gameObject.transform.position=playerPos; }
        if (playerPos.x <= -2.0f) { playerPos.x = -2.0f; gameObject.transform.position = playerPos; }
        if (playerPos.y >= 4.4f) { playerPos.y = 4.4f; gameObject.transform.position = playerPos; }
        if (playerPos.y <= -4.4f) { playerPos.y = -4.4f; gameObject.transform.position = playerPos; }
    }

    void instantiateBullet()
    {
        Instantiate(bullet, bulletPos1.transform.position, Quaternion.identity);
        Instantiate(bullet, bulletPos2.transform.position, Quaternion.identity);
    }
}
