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
    protected bool isAttacking = false;
    public float attackSpeed = 1.0f;
    public Rigidbody2D myRigid2D;

    public bool isMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    public enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2,
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("attackSpeed", attackSpeed);

        myRigid2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (isAttacking) {
            myRigid2D.velocity = direction.normalized * 0;
            return;
        }

        if (direction.x > 0) spriteRenderer.flipX = false;
        else if (direction.x < 0) spriteRenderer.flipX = true;

        //transform.Translate(direction * speed * Time.deltaTime);
        myRigid2D.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        if (isAttacking)
        {
            ActivateLayer(LayerName.AttackLayer);
        } else if (isMoving)
        {
            ActivateLayer(LayerName.WalkLayer);
        }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }
    }

    public void ActivateLayer(LayerName layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight((int)layerName, 1);
    }


    public void StartAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    public void StopAttack()
    {
        Debug.Log("StopAttack");
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

}


