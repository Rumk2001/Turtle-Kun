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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed");
            if (controller != null)
            {
                controller.incrementTrash();
                Destroy(gameObject);
            }

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key was pressed");
            if (controller != null)
            {

            }

        }
    }
    void OnTriggerEnter2D(Collider2D collided)
    {
        controller = collided.GetComponent<Controller>();
                if (controller != null)
        {
            Debug.Log("collision");


            }

        }
    void OnTriggerExit2D(Collider2D collided)
    {
        controller = null;
  
        
            Debug.Log("exit");


        

    }

}



