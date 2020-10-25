using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float triggerNpcDist = 0.58f;

    //int animationIndex = 0;
    int waypointIndex = 0;
    float moveSpeed = 3f;

    Animator NPCanim;
    NPCTrigger trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = FindObjectOfType<NPCTrigger>();
        NPCanim = GetComponent<Animator>();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(waypointIndex < waypoints.Count)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementPerFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);
            walkAnimation(transform.position, targetPosition);
            triggerMove(transform.position, targetPosition);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
    
    }

    private void walkAnimation(Vector2 InitialPosition, Vector2 finalPosition)
    {
        if(finalPosition.x > InitialPosition.x)
        {
            NPCanim.SetBool("isRight", true);
        }
        else if(finalPosition.x < InitialPosition.x)
        {
            NPCanim.SetBool("isLeft", true);
        }
        else if(finalPosition.y > InitialPosition.y)
        {
            NPCanim.SetBool("isUp", true);
        }
        else if (finalPosition.y < InitialPosition.y)
        {
            NPCanim.SetBool("isDown", true);
        }
        else
        {
            NPCanim.SetBool("isRight", false);
            NPCanim.SetBool("isLeft", false);
            NPCanim.SetBool("isUp", false);
            NPCanim.SetBool("isDown", false);
            NPCanim.SetBool("isIdle", true);

        }
    }

    private void triggerMove(Vector2 InitialPosition, Vector2 finalPosition)
    {
        if (finalPosition.x > InitialPosition.x)
        {
            trigger.transform.position = new Vector2(transform.position.x + triggerNpcDist, transform.position.y);
        }
        else if (finalPosition.x < InitialPosition.x)
        {
            trigger.transform.position = new Vector2(transform.position.x - triggerNpcDist, transform.position.y);
        }
        else if (finalPosition.y > InitialPosition.y)
        {
            trigger.transform.position = new Vector2(transform.position.x , transform.position.y + triggerNpcDist);
        }
        else if (finalPosition.y < InitialPosition.y)
        {
            trigger.transform.position = new Vector2(transform.position.x, transform.position.y - triggerNpcDist);
        }
        else
        {
            trigger.transform.position = new Vector2(transform.position.x, transform.position.y + triggerNpcDist);
        }
    }
}
