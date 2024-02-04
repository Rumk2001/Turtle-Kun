using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Inventory inventory;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public int maxInventorySpace = 5;
    public bool isShelfShowing = false;
    public float maxHealth = 1;
    private float currentHealth = 1 ;
    private int currentTrash;
    Timer mytimer = new Timer(2000);

    private void Awake()
    {
        inventory = new Inventory();
        Debug.Log("Awaken");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        InventoryShelf.instance.hide();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentTrash= 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // when I is pressed the turtle Opens their inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isShelfShowing)
            {
                InventoryShelf.instance.hide();
                isShelfShowing = false;
            }
            else
            {
                InventoryShelf.instance.show();
                isShelfShowing = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    public void consumeFood()
    {
        changeHealth(45f);
    }
    public void consumeTrash()
    {
        changeHealth(-0.15f);
    }
    // Needed? 
    public void incrementTrash()
    {
        currentTrash++;
    }

    public void addToInventory(Item item)
    {
        inventory.add(item);
    }

    public void changeHealth(float change)
    {
        currentHealth = currentHealth + change; //Mathf.Clamp(currentHealth + change, 0, maxHealth);

        HealthBar.instance.SetValue(currentHealth);
    }

}

