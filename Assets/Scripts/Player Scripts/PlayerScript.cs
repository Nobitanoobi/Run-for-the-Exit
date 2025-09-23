using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = .5f;
    private float rotationSpeed = 4f;
    private float jumpForce = 3f;
    private bool canJump = false;
    private bool isPlayerMove = false;
    [SerializeField]
    private float verticalMove = 0 ;
    [SerializeField]
    private float horizontalMove = 0;
    private float rotY = 0;

    private Animator anim;
    private Rigidbody rb;

    public LayerMask groundLayer;
    public Transform groundCheck;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotY = transform.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        PlayerAnimate();
        Attack();
        Jump();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
    }

    void PlayerMove()
    {
        if(verticalMove != 0)
        {
            rb.MovePosition(transform.position + transform.forward * (moveSpeed * verticalMove));
        }
        rotY += horizontalMove * rotationSpeed;
        rb.rotation = Quaternion.Euler(0f, rotY, 0);

    }

    void PlayerAnimate() 
    {
        if (verticalMove != 0)
        {
            if (!isPlayerMove)
            {
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMove = true;
                    anim.SetTrigger(MyTags.RUN_TRIGGER);
                }
            }
        }
        else
        {
            if (isPlayerMove)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMove = false;
                    anim.SetTrigger(MyTags.STOP_TRIGGER);
                }
            }
        }
    }
    
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION)|| 
            !anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.ATTACK_TRIGGER);
            }
        }
    }
    void Jump()
    {
        canJump = Physics.Raycast(groundCheck.position, Vector3.down, .1f, groundLayer);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                canJump = false;
                rb.AddForce(Vector3.up * moveSpeed * jumpForce, ForceMode.Impulse);
                anim.SetTrigger(MyTags.JUMP_TRIGGER);
            }
        }
       
    }
}



















