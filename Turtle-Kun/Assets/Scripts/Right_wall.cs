using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SceneGeneration : MonoBehaviour
{
    // public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        // Initializes its position depending on the screen size
        Vector2 p = new Vector2(Screen.width + 1, transform.position.y);
        transform.position = p;

        FillZone();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This is triggered if Turtle-Kun walks towards the edge
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
    }

    void FillZone()
    {
        // Odds for a specific type of plastic to spawn
        const float oddsSpawn = 1.25f;
        System.Random rnd = new System.Random();

        Vector3 screenVector, realWorldVector;
        float xMin, yMin, xMax, yMax;
        int x, y, variant;

        // Calculates the real world max x y values at the limit of the screen
        screenVector = new Vector3(Screen.width, Screen.height, 0);
        realWorldVector = Camera.main.ScreenToWorldPoint(screenVector);

        xMin = -realWorldVector.x;
        xMax = realWorldVector.x;
        yMin = -realWorldVector.y / 2;
        yMax = realWorldVector.y / 2;


        Debug.Log(string.Format("{0:N2}", realWorldVector.x) + string.Format("{0:N2}", realWorldVector.y) + string.Format("{0:N2}", realWorldVector.z));

        int nbItemType = 7; // To remove later

        for (int i = 0; i < nbItemType; i++)
        {
            Debug.Log("New Thing!");
            // If it passes the odds of spawning
            if (rnd.NextDouble() < oddsSpawn)
            {
                Debug.Log("New Thing!");
                GameObject newThing;
                // Creates a clone of a prefab
                if (i == 1 || i == 4 || i == 7)
                {
                    variant = rnd.Next(1, 5);
                    newThing = (GameObject) Instantiate(Resources.Load("ItemPrefab" + i.ToString() + variant.ToString()));
                }
                else
                {
                    variant = 0;
                    Debug.Log(i.ToString());
                    newThing = (GameObject) Instantiate(Resources.Load("ItemPrefab" + i.ToString()));
                }


                // Random the position
                x = rnd.Next((int)xMin + (int)newThing.GetComponent<Renderer>().bounds.size.x / 2, (int)xMax - (int)newThing.GetComponent<Renderer>().bounds.size.x / 2);
                y = rnd.Next((int)yMin + (int)newThing.GetComponent<Renderer>().bounds.size.y / 2, (int)yMax - (int)newThing.GetComponent<Renderer>().bounds.size.y / 2);

                Vector2 p;
                p.x = x;
                p.y = y;

                // Updates profile
                newThing.transform.position = p;
            }
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
