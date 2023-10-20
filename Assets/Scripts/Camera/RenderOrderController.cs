using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrderController : MonoBehaviour
{
    void Update()
    {
        // Set the sorting order based on the y-axis position of the object
        GetComponent<SpriteRenderer>().sortingOrder = (int)(transform.position.y * -100);
    }
}