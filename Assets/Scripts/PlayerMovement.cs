using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform checkGround;
    [SerializeField] private bool isGround;

    [SerializeField] private LayerMask groundLayer;
    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapBox(checkGround.position, new Vector2(1, 1), 0, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
