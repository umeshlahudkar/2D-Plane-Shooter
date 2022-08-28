using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float speed;
    private bool isplayerDied = false;

    private void Start()
    {
        PlayerController.OnPlayerDied += SetPlayerDied;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDied -= SetPlayerDied;
    }

    private void Update()
    {
        if (isplayerDied) return;

        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset.y += speed * Time.deltaTime;
        meshRenderer.material.mainTextureOffset = offset;      
    }

    private void SetPlayerDied()
    {
        isplayerDied = true;
    }
}
