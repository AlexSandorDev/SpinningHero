using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAhead : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxDistance;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        target.position =  rb.position + Vector2.ClampMagnitude(rb.velocity,maxDistance);
    }
}
