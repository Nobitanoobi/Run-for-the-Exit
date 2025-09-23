using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private GameObject player;

    private float speed = 10f;
    private float attackThreshold = 6f;
    private float watchThreshold = 70;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = GameObject.FindAnyObjectByType<PlayerScript>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Enemy();
    }

    private void Enemy()
    {
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();
        Vector3 velocity = direction * speed;


        if(distance<watchThreshold && distance > attackThreshold)
        {
            rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
            anim.SetTrigger(MyTags.RUN_TRIGGER);

            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
        else if(distance < attackThreshold)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
            {
                anim.SetTrigger(MyTags.ATTACK_TRIGGER);
            }
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION)|| 
            anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION))
            {
                anim.SetTrigger(MyTags.STOP_TRIGGER);
            }
               
        }
    }
}
