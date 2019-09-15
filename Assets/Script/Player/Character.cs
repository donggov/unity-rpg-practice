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
    public float attackSpeed = 0.8f;

    public bool IsMoving
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
        if (isAttacking) return;

        if (direction.x > 0) spriteRenderer.flipX = false;
        else if (direction.x < 0) spriteRenderer.flipX = true;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void HandleLayers()
    {
        PlayerController.instance.animator.SetBool("isMoving", IsMoving);

        /*
        if (isAttacking)
        {
            ActivateLayer(LayerName.AttackLayer);
        } else if (IsMoving)
        {
            ActivateLayer(LayerName.WalkLayer);
        }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }
        */
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
        if(!isAttacking)
        {
            StartCoroutine("AttackCoroutine");
        }
    }

    private IEnumerator AttackCoroutine()
    {
        isAttacking = true;
        PlayerController.instance.animator.SetTrigger("trigerAttack");
        yield return new WaitForSeconds(attackSpeed);
        StopAttack();
    }

    public void StopAttack()
    {
        isAttacking = false;
        PlayerController.instance.animator.SetTrigger("trigerAttack");
        StopCoroutine("AttackCoroutine");
    }

}


