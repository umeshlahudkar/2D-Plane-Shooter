using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    float speed = 10f;

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
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Destroy(gameObject);
        }

    }
}
