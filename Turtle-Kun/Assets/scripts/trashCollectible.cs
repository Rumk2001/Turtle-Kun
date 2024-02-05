using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCollectible : MonoBehaviour
{

    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when E key is pressed the turtle eats the trash
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (controller != null)
            {
                controller.consumeTrash();
                Debug.Log(gameObject);
                Destroy(gameObject);
            }

        }
        // when F is pressed the turtle stores the trash in their inventory
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (controller != null)
            {
                controller.incrementTrash();
                controller.addToInventory(new Item(0, "glass bottle", -5f, "unrecyclable glass",2));
                Destroy(gameObject);
            }
        }
    
    }
    void OnTriggerEnter2D(Collider2D collided)
    {
        controller = collided.GetComponent<Controller>();
    }
    void OnTriggerExit2D(Collider2D collided)
    {
        controller = null;
    }

}



