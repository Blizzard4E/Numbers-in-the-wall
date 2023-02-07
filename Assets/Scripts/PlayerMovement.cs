using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 20.0f;
    public float rotationSpeed = 720;
    public bool canRun = true;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Transform playerModel;

    private Vector3 moveDirection = Vector3.zero;
    Rigidbody rb;
    public bool hasLost = false;
    bool freezePlayer = true;
    public bool hasWon = false;
    [SerializeField]
    AudioClip[] footsteps;
    AudioSource audio;

    IEnumerator stopFreeze(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        freezePlayer = false;
    }

    public void playFootstep()
    {
        audio.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(stopFreeze(5f));
    }
    void Update()
    {
        // Get input from the user
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(hasWon)
        {
            animator.SetBool("hasWon", true);
        }
        if(canRun)
        {
            // Set the move direction based on user input
            moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        }

        // Rotate the character to face the direction of movement
        if ((moveDirection.x != 0 || moveDirection.z != 0) && !hasLost && !freezePlayer && !hasWon)
        {
            Vector3 rotateDir = new Vector3(moveDirection.x, 0, moveDirection.z);
            Quaternion toRotation = Quaternion.LookRotation(rotateDir, Vector3.up);

            playerModel.rotation = Quaternion.RotateTowards(playerModel.rotation, toRotation, rotationSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("StopRun"))
        {
            canRun = false;
        }
        else
        {
            canRun = true;
        }
        //transform.Translate(moveDirection * speed * Time.deltaTime);
        if(hasLost)
        {
            animator.SetBool("isFall", true);
        }
    }

    private void FixedUpdate()
    {
        if(!hasLost && !freezePlayer && !hasWon)
        {
            rb.velocity = moveDirection * speed;
        }
    }
}

