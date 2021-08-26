using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : Singleton<Hover>
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
        spriteRenderer.transform.localScale = new Vector3(spriteRenderer.transform.localScale.x, spriteRenderer.transform.localScale.y);
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;
        spriteRenderer.transform.localScale = Vector3.one;
    }
}
