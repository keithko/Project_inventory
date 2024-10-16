using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    //GameObject m_Player;
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    float moveX, moveY;

    private Vector2 moveDirection;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ProcessIputs();
    }

    void ProcessIputs()
    {
       moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
       moveY = Input.GetAxisRaw("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveX, moveY);

    }
}
