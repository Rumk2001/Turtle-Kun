using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will hold in memory the zones/areas generated and their respective loot/garbage
public class MapClass : MonoBehaviour
{
    private Zone[] mapZones;
    private int size;
    private int curIndex;

    public MapClass()
    {
        this.mapZones = new Zone[4];
        this.size = 0;
        this.curIndex = -1;
    }

    public Zone getZone()
    {
        return this.mapZones[this.curIndex];
    }

    public bool prevZone()
    {
        //Move to the previous zone, unless it goes back to the start
        if (curIndex > 0)
        {
            this.hideItems();
            curIndex--;
            this.showItems();
            return true;
        }
        return false;
    }

    public void nextZone()
    { // Moves to the next zone, creates a new zone if it there is no other zone after the current one
        this.hideItems();
        if (++this.curIndex == this.size)
        {
            if (this.size == this.mapZones.Length)
            {
                resize();
            }
            Zone newZone = new Zone();
            fillZone(newZone);
            this.mapZones[this.curIndex] = newZone;
            size++;
        }
        this.showItems();
    }

    private void hideItems()
    {
        if (this.curIndex > -1)
        {
            // Hides the items that are in the current zone
            for (int i = 0; i < this.getZone().getSize(); i++)
            {
                this.getZone().getItem(i).GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void showItems()
    {
        if (this.curIndex > -1)
        {
            // Reveals the items that are in the current zone
            for (int i = 0; i < this.getZone().getSize(); i++)
            {
                this.getZone().getItem(i).GetComponent<Renderer>().enabled = true;
            }        
        }
    }

    private void fillZone(Zone newZone)
    {
        // Odds for a specific type of plastic to spawn
        const float oddsSpawn = 0.25f;
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

        for (int i = 1; i <= itemCreator.nbItemType; i++)
        {
            // If it passes the odds of spawning
            if (rnd.NextDouble() < oddsSpawn)
            {
                GameObject newThing;
                // Creates a clone of a prefab
                if (i == 1 || i == 4 || i == 7)
                {
                    variant = rnd.Next(1, 5);
                    newThing = (GameObject)Instantiate(Resources.Load("ItemPrefab" + i.ToString() + variant.ToString()));
                }
                else
                {
                    variant = 0;
                    newThing = (GameObject)Instantiate(Resources.Load("ItemPrefab" + i.ToString()));
                }


                // Random the position
                x = rnd.Next((int)xMin + (int)newThing.GetComponent<Renderer>().bounds.size.x / 2, (int)xMax - (int)newThing.GetComponent<Renderer>().bounds.size.x / 2);
                y = rnd.Next((int)yMin + (int)newThing.GetComponent<Renderer>().bounds.size.y / 2, (int)yMax - (int)newThing.GetComponent<Renderer>().bounds.size.y / 2);

                Vector2 p;
                p.x = x;
                p.y = y;

                // Updates profile
                newThing.transform.position = p;

                newZone.addItem(newThing);
            }
        }
    }

    private void resize()
    {
        Zone[] temp = new Zone[size * 2];
           
        for (int i = 0; i < size; i++)
        {
            temp[i] = this.mapZones[i];
        }
        this.mapZones = temp;
    }

    public class Zone
    {
        private GameObject[] items;
        private int size;

        public Zone()
        {
            items = new GameObject[7];
            size = 0;
        }

        public void addItem(GameObject newItem)
        {
            items[size++] = newItem;
        }

        public bool removeItem(GameObject item)
        {
            for (int i = 0; i < this.size; i++)
            {
                if (this.items[i] == item)
                {
                    shiftUp(i);
                    size--;
                    return true;
                }
            }
            return false;
        }

        public GameObject getItem(int i)
        {
            return items[i];
        }

        public int getSize()
        {
            return this.size;
        }

        private void shiftUp(int voidSpace)
        {
            for (int i = voidSpace; i < this.size - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
