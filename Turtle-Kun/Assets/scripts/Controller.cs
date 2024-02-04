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

    bool restState; //Used to check if the turtle is in its resting state for animation
    float eatingTimer; //Used to keep track of the time in the eating animation to check when to change states
    float eatingFirstFrame; //The time limit before transitioning to the second frame
    float eatingSecondFrame; //The time limit before transitioning to the third frame
    float eatingThirdFrame; //The time limit before transitioning to the resting frame
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        //InventoryShelf.instance.hide();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentTrash= 0;
        restState = true;
        eatingTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        this.UpdateAnimation();
        // when I is pressed the turtle Opens their inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isShelfShowing)
            {
                //InventoryShelf.instance.hide();
                isShelfShowing = false;
            }
            else
            {
                //InventoryShelf.instance.show(inventory);
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
    
    public void UpdateAnimation()
    {
        Sprite newSprite;
        string path = "Turtle/";
        // Eating animation overrides movement
        if (eatingTimer > 0.0001) {


        // Movement focuses left and right if both horizontal and vertical have movement
        } else if (horizontal != 0)
        {
            if (restState)
            {
                if (horizontal > 0)
                {
                    path += "right";
                } else
                {
                    path += "left";
                }
            } else
            {
                if (horizontal > 0)
                {
                    path += "right_flap";
                }
                else
                {
                    path += "left_flap";
                }
            }

        } else if (vertical != 0)
        {
            if (restState)
            {
                if (vertical > 0)
                {
                    path += "up";
                }
                else
                {
                    path += "down";
                }
            }
            else
            {
                if (vertical > 0)
                {
                    path += "up_flap";
                }
                else
                {
                    path += "down_flap";
                }
            }
        }
        newSprite = Resources.Load<Sprite>(path);
        this.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

}

