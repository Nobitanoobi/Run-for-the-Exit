using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = .8f;
    private float rotationSpeed = 5f;
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
}
