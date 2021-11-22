using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D playerRb;
    //public Animator animator;
    Vector2 movement;
    public Shooter shooterScript;
    public float speed;
    public int health;
    public int Maxhealth;
    public string ammoType = "Basic";
    


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

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Interactable" && Input.GetKeyDown(KeyCode.E))
            {
                if(other.gameObject.name == "Basic")
                {
                    shooterScript.Basic = true;
                }
                else if(other.gameObject.name == "Bouncy")
                {
                    shooterScript.Bouncy = true;
                }
                else if(other.gameObject.name == "Piercing")
                {
                    shooterScript.Piercing = true;
                }
                else if(other.gameObject.name == "Shotgun")
                {
                    shooterScript.Shotgun = true;
                }
                else if(other.gameObject.name == "Sniper")
                {
                    shooterScript.Sniper = true;
                }
                    Destroy(other);
                }
    }

}
