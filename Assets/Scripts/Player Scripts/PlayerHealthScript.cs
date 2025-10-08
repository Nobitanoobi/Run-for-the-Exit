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

    void Start()
    {
        GameplayControllerScript.instance.DisplayHealth(health);
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;


        if (health < 0)
        {
            health = 0;
        }

        GameplayControllerScript.instance.DisplayHealth(health);

        if (health == 0)
        {
            anim.Play(MyTags.DEAD_ANIMATION);
            GameplayControllerScript.instance.isPlayerAlive = false;
            GameplayControllerScript.instance.Gameover();
            playerScript.enabled = false;
        }

    }


    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "coin")
        {
            GameplayControllerScript.instance.CollectedCoins();
            SoundManagerScript.instance.PlayCollectCoinSound();
            target.gameObject.SetActive(false);
        }

        if (target.gameObject.tag == "Door")
        {
            target.GetComponent<Animator>().Play("DoorOpen");
        }
    }
    
     void OnTriggerExit(Collider target)
    {
        
        if (target.gameObject.tag == "Door")
        {
            target.GetComponent<Animator>().Play("DoorClose");
        }
    }
}
