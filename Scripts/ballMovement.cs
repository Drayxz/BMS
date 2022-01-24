using System.Collections;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private GameObject ball_parent; //saves the parent as the spawner
    private Vector3 last_frame_cordinates; //last frame position vector
    private Vector3 this_frame_cordinates; //current position vector
    private float ball_speed; //speed in meters per second
    private bool ticking; //is true when inactivity timer is running

    [SerializeField]
    private float depsawn_distance = 15f; //distance in meters
    [SerializeField]
    private float despawn_sensitivity = .3f; //speed in meters per second
    [SerializeField]
    private float despawn_timer = 3f; //time in seconds

    void Start()
    {
        ball_parent = transform.parent.gameObject;
        last_frame_cordinates = transform.position; //sets the last position to be the spawned cordinates
    }

    void FixedUpdate()
    {
        MovePosition();
        InactivityCheck();
        CheckBoundries();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Game Phase Object")
        {
            ball_parent.GetComponent<ballSteps>().NextPhase();
            Destroy(collider.gameObject);
        }
    }

    void MovePosition()
    {
        //saves new cordinates in vector
        this_frame_cordinates = transform.position;

        //updates speed
        ball_speed = (this_frame_cordinates - last_frame_cordinates).magnitude / Time.deltaTime;

        //updates current position into old
        last_frame_cordinates = this_frame_cordinates;
    }

    private void InactivityCheck()
    {
        if (ball_speed < despawn_sensitivity)
        {
            if (!ticking) //if clock isnt running starts it
            {
                StartCoroutine("InactivityTimer");
            }
        }
        else //object is moving
        {
            StopCoroutine("InactivityTimer");
            ticking = false;
        }
    }
    
    IEnumerator InactivityTimer()
    {
        //starts timer
        ticking = true;
        yield return new WaitForSeconds(despawn_timer);
        
        //if timer reaches end, calls the parent to despawn
        ball_parent.GetComponent<ballControl>().Despawn();
        ticking = false;
    }
    
    private void CheckBoundries()
    {
        float dist = Vector3.Distance(transform.position, ball_parent.transform.position);
        if (dist > depsawn_distance)
        {
            ball_parent.GetComponent<ballControl>().Despawn();
        }
    }
}
