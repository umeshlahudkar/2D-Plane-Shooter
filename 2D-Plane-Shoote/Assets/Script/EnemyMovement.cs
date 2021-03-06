using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed = 3f;
    [SerializeField] GameObject bullets;
    [SerializeField] Transform bulletsPos;

    [SerializeField] GameObject coin;

    [SerializeField] EnemyHealthController enemyHealthController;
    float damage = 0.3f;

    float enemyHealth = 1f;

    private void Start()
    {
        InvokeRepeating("InstantiateBullet", 0.3f, 0.3f);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (gameObject.transform.position.y <= -5.0f)
        {
            Destroy(gameObject);
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletController>() != null)
        {
            Vector3 Pos = gameObject.transform.position;
            enemyHealth -= damage;
            enemyHealthController.setEnemyHealth(damage);
            if(enemyHealth <= 0)
            {
                Instantiate(coin, Pos, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }

    }

    void InstantiateBullet()
    {
        Instantiate(bullets, bulletsPos);
    }
}
