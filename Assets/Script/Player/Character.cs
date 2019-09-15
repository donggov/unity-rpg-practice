using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    protected Vector2 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Move();
        AnimateMovement();
    }

    public void Move()
    {
        if (direction.x > 0) spriteRenderer.flipX = false;
        else if (direction.x < 0) spriteRenderer.flipX = true;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void AnimateMovement()
    {
        animator.SetBool("isWalk", (direction.x > 0 || direction.x < 0 || direction.y > 0 || direction.y < 0));
    }

}
