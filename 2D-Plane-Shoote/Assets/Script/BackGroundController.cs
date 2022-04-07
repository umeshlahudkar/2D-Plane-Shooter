using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float speed;

    private void Update()
    {
       Vector2 offset = meshRenderer.material.mainTextureOffset;
       offset.y += speed * Time.deltaTime;
       meshRenderer.material.mainTextureOffset = offset;
    }
}
