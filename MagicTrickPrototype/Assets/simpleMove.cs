using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class simpleMove : MonoBehaviour
{
    CharacterController controller;
    public GameObject skateboard;
    public GameObject playerModel;
    private Animation kickflip;
    private Animation backflip;
    ParticleSystem magicParticles;
    AudioSource skateSound;
    AudioSource magicSFX;

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public bool inNPCRange = false;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
         controller = GetComponent<CharacterController>();
        kickflip = skateboard.GetComponent<Animation>();
        backflip = playerModel.GetComponent<Animation>();
        magicParticles = GetComponent<ParticleSystem>();
        magicSFX = GetComponent<AudioSource>();
        skateSound = skateboard.GetComponent<AudioSource>();

    }

    void Update()
    {


        // Rotate around y - axis
        /*transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        if(Input.GetKey("space"))
        { 
            curSpeed *= 3;
        }
        forward *= curSpeed;
        

        controller.SimpleMove(forward); //* Time.deltaTime);
        */
       
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes


            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
            moveDirection = transform.TransformDirection(Vector3.forward);
            //moveDirection *= speed * Input.GetAxis("Vertical");

            if (Input.GetKey("space"))
            {
                moveDirection *= speed * Input.GetAxis("Vertical") * 3.0F;
                if(skateSound.isPlaying)
                {
                    skateSound.volume = 0.7f;
                }
            }
            else
            {
                moveDirection *= speed * Input.GetAxis("Vertical");
                if (skateSound.isPlaying)
                {
                    skateSound.volume = 0.4f;
                }
            }

            if(Input.GetAxis("Vertical") != 0 && !skateSound.isPlaying)
            {
                skateSound.Play();
            }
            else if(Input.GetAxis("Vertical") == 0 && skateSound.isPlaying)
            {
                skateSound.Stop();

            }
            
            if (Input.GetKeyUp("space"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * 2, 0);
            if (Input.GetKeyDown("e") && kickflip.isPlaying != true)
            {
                kickflip.Play("kickFlip");
                magicParticles.Play();
                //if (!magicSFX.isPlaying)
               // {
                    magicSFX.Play();
               // }
            }
            if (Input.GetKeyDown("r") && kickflip.isPlaying != true)
            {
                backflip.Play("backflip");
                magicParticles.Play();
               // if (!magicSFX.isPlaying)
               // {
                    magicSFX.Play();
                //}
            }
            if (skateSound.isPlaying)
            {
                skateSound.Stop();

            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);


        if (inNPCRange && Input.GetKey("x"))
        {
            Debug.Log("HI!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            inNPCRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            inNPCRange = false;
        }
    }
   /* private void kickflip()
    {
        Debug.Log("kickflip");
        for (var fliploop = 0; fliploop < 3600000; fliploop++)
        {
            skateboard.transform.Rotate(Vector3.up / 10000);
        }

    }*/

}
