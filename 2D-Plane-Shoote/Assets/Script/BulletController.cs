using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(transform.position.y >= 5f)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {
            Destroy(gameObject);
        }
    }


}
