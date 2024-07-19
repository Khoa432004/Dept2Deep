using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public Player player;
    private Vector2 offset;

    void Update()
    {
        offset = new Vector2(player.transform.position.x, player.transform.position.y);
        //get the players position and add it with offset, then store it to transform.position aka the cameras position
        transform.position = new Vector3(offset.x, offset.y, -10);
    }
}
