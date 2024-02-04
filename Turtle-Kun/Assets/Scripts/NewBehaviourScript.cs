using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NewBehaviourScript : MonoBehaviour
{
    // public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        const float oddsSpawn = 0.25f;
        System.Random rnd = new System.Random();

        Vector3 screenVector, realWorldVector;
        float x, y, xMin, yMin, xMax, yMax;

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
            if (rnd.NextDouble() < oddsSpawn)
            {
                GameObject newThing = (GameObject) Instantiate(Resources.Load("ItemPrefab" + i.ToString()))

                Debug.Log(x.ToString() + y.ToString());

                x = rnd.Next(xMin + newThing.GetComponent<Renderer>().bounds.size.x / 2, xMax - newThing.GetComponent<Renderer>().bounds.size.x / 2);
                y = rnd.Next(yMin + newThing.GetComponent<Renderer>().bounds.size.y / 2, yMax - newThing.GetComponent<Renderer>().bounds.size.y / 2);

                Vector2 p;
                p.x = x;
                p.y = y;

                newThing.transform.position = p;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
