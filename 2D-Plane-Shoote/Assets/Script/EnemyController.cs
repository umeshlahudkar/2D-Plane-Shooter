using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;
    private void Start()
    {
        InvokeRepeating("InstantiateEnemy1", 2f, 4f);
        InvokeRepeating("InstantiateEnemy2", 2f, 2.5f);
    }

    private void Update()
    {
        if (PlayerController.isGameOver)
        {
            this.enabled = false;
            CancelInvoke("InstantiateEnemy1");
            CancelInvoke("InstantiateEnemy2");
        }
    }


    void InstantiateEnemy1()
    {
        float xPos = Random.Range(-2, 2);
        float yPos = 5f;
        Vector2 Pos = new Vector2(xPos, yPos);

        Instantiate(Enemy1, Pos,Quaternion.identity);

    }

    void InstantiateEnemy2()
    {
        float xPos = Random.Range(-2, 2);
        float yPos = 5f;
        Vector2 Pos = new Vector2(xPos, yPos);

        Instantiate(Enemy2, Pos, Quaternion.identity);

    }
}
