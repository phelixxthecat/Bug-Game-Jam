using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    //public Animator animator;
    Vector2 movement;
    public float speed;
    public int health;
    public int Maxhealth;
    public GameObject currentInteractObj;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            currentInteractObj = other.gameObject;
            Debug.Log("Item registered");
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Picked up");
            Destroy(currentInteractObj);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Interactable" )
        {
            currentInteractObj = null;
            Debug.Log("Item deregistered");
            
        }
    }
}
