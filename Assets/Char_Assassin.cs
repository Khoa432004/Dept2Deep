using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
public class Char_Assassin : Player
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidBody2D;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.MoveChar(myRigidBody2D);
    }
}

