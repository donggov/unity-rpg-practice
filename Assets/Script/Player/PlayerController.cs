using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    #region Singleton
    public static PlayerController instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
        DontDestroyOnLoad(instance);
    }
    #endregion

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
