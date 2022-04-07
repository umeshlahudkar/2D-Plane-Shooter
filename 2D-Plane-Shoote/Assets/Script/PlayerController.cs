using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float verticalInput, horrizontalInput;
    [SerializeField]float speed;

    [SerializeField] GameObject bulletPos1;
    [SerializeField] GameObject bulletPos2;

    [SerializeField] GameObject bullet;

    private void Start()
    {
         InvokeRepeating("instantiateBullet", 2, 0.3f);
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



    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBulletMovement>() != null)
        {
            Debug.Log(" Player Died");
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
