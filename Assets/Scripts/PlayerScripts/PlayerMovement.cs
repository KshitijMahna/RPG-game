using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public HealthBar healthbar;
    public int maxHealth = 100;
    public int currentHealth;
    public float speed;
    [SerializeField] float triggerDist = 0.58f;
    [SerializeField] Canvas invCanvas;

    PlayerTrigger trigger;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;
    public bool isInvOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        invCanvas.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        trigger = FindObjectOfType<PlayerTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            damage(20);
        }
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Move Input related with the left-right and Up-Down arrow
        moveVelocity = moveInput.normalized * speed; //normalized prevents the diagonal multiplication

        if (Input.GetKey(KeyCode.LeftArrow))
        {
           // rb.transform.eulerAngles = new Vector3(0, -180, 0);
            anim.SetBool("isLeft", true);
        }
        else
        {
            anim.SetBool("isLeft", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.transform.eulerAngles = new Vector3(0, 180, 0);
            anim.SetBool("isRight", true);
        }
        else
        {
            anim.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isUp", true);
        }
        else
        {
            anim.SetBool("isUp", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isDown", true);
        }
        else
        {
            anim.SetBool("isDown", false);
        }

        openInv();
    }

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        triggerMove(rb.position, rb.position + moveVelocity);
    }


    private void triggerMove(Vector2 InitialPosition, Vector2 finalPosition)
    {
        if (finalPosition.x > InitialPosition.x)
        {
            trigger.transform.position = new Vector2(transform.position.x + triggerDist, transform.position.y);
        }
        else if (finalPosition.x < InitialPosition.x)
        {
            trigger.transform.position = new Vector2(transform.position.x - triggerDist, transform.position.y);
        }
        else if (finalPosition.y > InitialPosition.y)
        {
            trigger.transform.position = new Vector2(transform.position.x, transform.position.y + triggerDist);
        }
        else if (finalPosition.y < InitialPosition.y)
        {
            trigger.transform.position = new Vector2(transform.position.x, transform.position.y - triggerDist);
        }
        else
        {
            trigger.transform.position = new Vector2(transform.position.x, transform.position.y + triggerDist);
        }
    }

    private void openInv()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!isInvOpen)
            {

                invCanvas.gameObject.SetActive(true);
                isInvOpen = true;
            }
            else
            {
               invCanvas.gameObject.SetActive(false);
                isInvOpen = false;
            }
        }
    }
    void damage(int dmg)
    {
        currentHealth -= dmg;
        healthbar.setHealth(currentHealth);
    }
    public void increaseHP(int health) // Increment of Health by 10 everytime a user picks a HP.
    {
        currentHealth += health;
        healthbar.setHealth(currentHealth);
    }
}
