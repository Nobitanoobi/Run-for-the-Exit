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
            playerScript.enabled = false;
        }

    }


    void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.tag == "Coin")
        {
            GameplayControllerScript.instance.CollectedCoins();
            SoundManagerScript.instance.PlayCollectCoinSound();
            target.gameObject.SetActive(false);
        }
    }
}
