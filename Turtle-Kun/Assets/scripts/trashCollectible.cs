using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collided)
    {
        Controller controller = collided.GetComponent<Controller>();
                if (controller != null)
        {
            controller.incrementTrash();
            Destroy(gameObject);
        }
    }
}
