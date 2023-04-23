using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*moveSpeed * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
