using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Inventory inventory;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public int maxInventorySpace = 5;
    public int intitialTrash = 0;
    public float maxHealth = 5;
    float currentHealth;
    int currentTrash;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentTrash= intitialTrash;
        currentHealth = maxHealth;
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
        Debug.Log(currentTrash);
        changeHealth(-1);
    }

    public void addToInventory(Item item)
    {

        Debug.Log(currentTrash);
        Debug.Log(item);
        inventory.add(item);
        Debug.Log(inventory);
    }

    public void changeHealth(float change)
    {
        currentHealth = Mathf.Clamp(currentHealth + change, 0, maxHealth);
        Debug.Log(change);
        Debug.Log(currentHealth);
    }

}

