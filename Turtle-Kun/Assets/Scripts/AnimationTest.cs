using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    bool restState;
    float flapTimer;
    float flapInterval;
    float eatingTimer;
    // Start is called before the first frame update
    void Start()
    {
        restState = true;
        flapTimer = 0f;
        flapInterval = 0.1f;
        eatingTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 p = transform.position;

        p.x += horizontal * 3f * Time.deltaTime;
        p.y += vertical * 3f * Time.deltaTime;

        transform.position = p;

        UpdateAnimation();
    }

    public void UpdateAnimation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Sprite newSprite;
        string path = "Turtle/";
        // Eating animation overrides movement
        if (eatingTimer > 0.0001)
        {


            // Movement focuses left and right if both horizontal and vertical have movement
        }
        else if (horizontal != 0)
        {
            if (restState)
            {
                if (horizontal > 0)
                {
                    path += "right";
                }
                else
                {
                    path += "left";
                }
            }
            else
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
            flapTimer += Time.deltaTime;
            if (flapTimer > flapInterval)
            {
                flapTimer = 0;
                restState = !restState;

            }

        }
        else if (vertical != 0)
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
            flapTimer += Time.deltaTime;
            if (flapTimer > flapInterval)
            {
                flapTimer = 0;
                restState = !restState;

            }
        }

        if (path != "Turtle/")
        {
            newSprite = Resources.Load<Sprite>(path);
            this.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
