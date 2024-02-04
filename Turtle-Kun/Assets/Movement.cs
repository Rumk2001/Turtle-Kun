using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = transform.position;
        p.x = p.x + 3f * Input.GetAxis("Horizontal") * Time.deltaTime;
        p.y = p.y + 3f * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position = p;
    }
}
