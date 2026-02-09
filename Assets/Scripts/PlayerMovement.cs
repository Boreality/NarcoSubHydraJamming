using UnityEngine;
using Yarn.Unity;

public class PlayerMovement : MonoBehaviour
{
    public int walkspd;
    public int runspd;
    private int speed;
    public Rigidbody bodyrb;

    public CharacterController controller;
    //at around 700 shit starts to get wobbly, and only gets worse from there
    Vector3 velocity;

    public float gravity = -9.18f;
    public float jumpForce = 10;
    public bool activeControls = true;

    private float x, z;

    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool landedCheck = true;

    void Start()
    {
        speed = walkspd;
    }


    [YarnCommand("set_controls")]
    public void SetActiveControls(bool newval)
    {
        activeControls = newval;
    }




    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            if (landedCheck)
            {
                //Landed
                landedCheck = false;
            }
            velocity.y = -2f;
        }
        //sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspd;
        }
        else
        {
            speed = walkspd;
        }

        //set movement
        x = 0.0f;
        z = 0.0f;
        
        if (activeControls)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //jumping
        if (activeControls&&Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
            landedCheck = true;
        }

        //velOcity is constantly growing stronger. 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        


    }
}