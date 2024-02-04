using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGeneration : MonoBehaviour
{
    // public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {   
        // Odds for a specific type of plastic to spawn
        const float oddsSpawn = 0.25f;
        System.Random rnd = new System.Random();

        Vector3 screenVector, realWorldVector;
        float xMin, yMin, xMax, yMax;
        int x, y;

        // Calculates the real world max x y values at the limit of the screen
        screenVector = new Vector3(Screen.width, Screen.height, 0);
        realWorldVector = Camera.main.ScreenToWorldPoint(screenVector);

        xMin = -realWorldVector.x;
        xMax =  realWorldVector.x;
        yMin = -realWorldVector.y/2;
        yMax =  realWorldVector.y/2;


        Debug.Log(string.Format("{0:N2}", realWorldVector.x) + string.Format("{0:N2}", realWorldVector.y) + string.Format("{0:N2}", realWorldVector.z));

        int nbItemType = 1; // To remove later

        for (int i = 0; i < nbItemType; i++)
        {   
            // If it passes the odds of spawning
            if (rnd.NextDouble() < oddsSpawn)
            {
                // Creates a clone of a prefab
                GameObject newThing = (GameObject)Instantiate(Resources.Load("ItemPrefab" + i.ToString()));

                // Random the position
                x = rnd.Next((int) xMin + (int) newThing.GetComponent<Renderer>().bounds.size.x / 2, (int) xMax - (int) newThing.GetComponent<Renderer>().bounds.size.x / 2);
                y = rnd.Next((int) yMin + (int) newThing.GetComponent<Renderer>().bounds.size.y / 2, (int) yMax - (int) newThing.GetComponent<Renderer>().bounds.size.y / 2);

                Vector2 p;
                p.x = x;
                p.y = y;

                // Updates profile
                newThing.transform.position = p;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
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
