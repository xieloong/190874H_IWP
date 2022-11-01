using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshRenderer;
    public float scrollSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0, scrollSpeed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
