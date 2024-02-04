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
    public int intitialTrash = 0;
    public float maxHealth = 1;
    private float currentHealth = 1 ;
    int currentTrash;
    Timer mytimer = new Timer(2000);


    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentTrash= intitialTrash;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void incrementTrash()
    {
        currentTrash++;
        changeHealth(-0.15f);
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

