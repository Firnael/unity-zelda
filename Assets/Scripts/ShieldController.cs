using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector2 frontAndBackBoxColliderSize = new Vector2(0.5f, 0.3f);
    private Vector2 leftAndRightBoxColliderSize = new Vector2(0.3f, 0.5f);

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	void Update ()
    {
        // Change sprite and hitbox depending on direction
        Vector2 diff = new Vector2(transform.position.x - transform.parent.position.x, transform.position.y - transform.parent.position.y).normalized;

        if(diff.y >= 0.7)
        {
            spriteRenderer.sprite = back;
            boxCollider.size = frontAndBackBoxColliderSize;
        }
        else if(diff.y <= -0.7)
        {
            spriteRenderer.sprite = front;
            boxCollider.size = frontAndBackBoxColliderSize;
        }
        else
        {
            if(diff.x > 0)
            {
                spriteRenderer.sprite = right;
            } else
            {
                spriteRenderer.sprite = left;
            }
            boxCollider.size = leftAndRightBoxColliderSize;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
