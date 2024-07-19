using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public int Health;
    public int Damage;
    public int Def;
    public int Crit;
    public int AttackSpeed;
    public int AttackRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveChar(Rigidbody2D myRigidBody2D)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x, myRigidBody2D.position.y + MovementSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x, myRigidBody2D.position.y - MovementSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x - MovementSpeed, myRigidBody2D.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            myRigidBody2D.position = new Vector3(myRigidBody2D.position.x + MovementSpeed, myRigidBody2D.position.y);
        }
    }
}
