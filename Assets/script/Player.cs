using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 3f;
    public Rigidbody2D rigidbody;
    public GameManager gameManager;
    public bool isDead = false;
    public bool scouceUp = false;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 2.4f;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        gameManager.GameOver();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        scouceUp = true;
    }
}
