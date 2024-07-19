using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTree : MonoBehaviour
{
    public GameObject objectsToSpawn;
    public BoxCollider2D Background;
    public int numberOfObjects;
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            GenarateTree();
        }
    }

    // Update is called once per frame
    void GenarateTree()
    {
        Bounds size = Background.bounds;

        float x = Random.Range(size.min.x, size.max.x);
        float y = Random.Range(size.min.y, size.max.y);

        Vector3 newSpawn = new Vector3(x, y, 0);
        Instantiate(objectsToSpawn, newSpawn, transform.rotation);
    }
}
