using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;

    private float enemy1spwanInterval = 4f;
    private float enemy2spwanInterval = 2.5f;
    private float enemy1spwantimeElapced;
    private float enemy2spwantimeElapced;

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
        enemy1spwantimeElapced += Time.deltaTime;
        enemy2spwantimeElapced += Time.deltaTime;

        if(enemy1spwantimeElapced >= enemy1spwanInterval)
        {
            enemy1spwantimeElapced = 0;
            InstantiateEnemy1();
        }

        if (enemy2spwantimeElapced >= enemy2spwanInterval)
        {
            enemy2spwantimeElapced = 0;
            InstantiateEnemy2();
        }
    }

    private void InstantiateEnemy1()
    {
        float xPos = Random.Range(-2, 2);
        float yPos = 5f;
        Vector2 Pos = new Vector2(xPos, yPos);

        Instantiate(Enemy1, Pos, Quaternion.identity);

    }

    private void InstantiateEnemy2()
    {
        float xPos = Random.Range(-2, 2);
        float yPos = 5f;
        Vector2 Pos = new Vector2(xPos, yPos);

        Instantiate(Enemy2, Pos, Quaternion.identity);

    }

    private void Disable()
    {
        this.enabled = false;
    }
}
