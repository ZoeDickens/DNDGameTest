using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameObject PlayerProgetilePF;
    [SerializeField] float projectileSpeed = 10f;
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingright = true;

    private bool isgrounded;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatisground;

    private int exstrajumps;
    public int exstrajumpvaule;


    // Start is called before the first frame update
    void Start()
    {

        exstrajumps = exstrajumpvaule;
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisground);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingright == false && moveInput > 0)
        {
            flip();
        } else if(facingright == true && moveInput < 0)
        {
            flip();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Fire();

        if(isgrounded == true)
        {
            exstrajumps = 2;
        }

        if (Input.GetKeyDown(KeyCode.Space) && exstrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            exstrajumps--;
        } else if(Input.GetKeyDown(KeyCode.Space) && exstrajumps == 0 && isgrounded == true)
        {

        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject progetile = Instantiate(PlayerProgetilePF, transform.position, Quaternion.identity) as GameObject;
            progetile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        }

    }


    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }




}

