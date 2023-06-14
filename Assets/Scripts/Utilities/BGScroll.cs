using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{

    public float scrollSpeed;
    public float verticalScrollSpeed;
    private Renderer myRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();  
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1f);
        float y = Mathf.Repeat(Time.time * verticalScrollSpeed, 1f);
        Vector2 offset = new Vector2(x, y);
        myRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
