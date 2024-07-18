using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Char_Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidBody2D;
    public float MovementSpeed = 0;
    public int Health;
    public int Damage;
    public int Def;
    public int Crit;
    public int AttackSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x, myRigidBody2D.position.y + MovementSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x, myRigidBody2D.position.y - MovementSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x - MovementSpeed, myRigidBody2D.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x + MovementSpeed, myRigidBody2D.position.y);
        }
    }
}

