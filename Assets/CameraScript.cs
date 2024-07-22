using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public Player player;
    private Vector2 offset_1;

    void Update()
    {
        if (player != null && player.IsAlive)
        {
            offset_1 = new Vector2(player.transform.position.x, player.transform.position.y);
            //get the players position and add it with offset, then store it to transform.position aka the cameras position
            transform.position = new Vector3(offset_1.x, offset_1.y, -10);
        }
        else
        {
            transform.position = new Vector3(0, 0, -10);
        }
    }
}
