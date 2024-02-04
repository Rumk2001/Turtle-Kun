using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGeneration : MonoBehaviour
{
    public MapClass map;
    // public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        // Initializes its position depending on the screen size
        Vector3 p = new Vector3(Screen.width + transform.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
        p = Camera.main.ScreenToWorldPoint(p);
        p.x = p.x + 4;
        p.y = transform.position.y;
        transform.position = p;

        map = FindObjectOfType<MapClass>();
        map.nextZone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is triggered if Turtle-Kun walks towards the edge
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        

        // Checks if the turtle has walked to the right side, if yes, send him to the next zone
        if (other.name == "turtle-kun")
        {
            map.nextZone();
            Vector3 p = new Vector3(0, 0, 0);
            p = Camera.main.ScreenToWorldPoint(p);
            p.y = 0;
            p.z = 0;

            other.transform.position = p;
        }
    }

    
    /*
    Item rndItem()
    {
        // UPDATE
        int id = rnd.Next(nbItemType);
        return itemList[id];

    }
    */
}
