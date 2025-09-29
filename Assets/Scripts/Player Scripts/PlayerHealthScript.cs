using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    private PlayerScript playerScript;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerScript = GetComponent<PlayerScript>();
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            health = 0;
            
        }
        if(health == 0)
        {
            playerScript.enabled = false;
            anim.Play(MyTags.DEAD_ANIMATION);
        }
    }
}
