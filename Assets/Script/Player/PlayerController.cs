using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    void Start()
    {
    }

    protected override void Update()
    {   
        GetInput();
        base.Update();
    }

    private void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;
    }

}
