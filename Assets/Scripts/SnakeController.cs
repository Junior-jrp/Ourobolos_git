using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 15;
    private Vector3 moveDirection;

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);    
    }
}
