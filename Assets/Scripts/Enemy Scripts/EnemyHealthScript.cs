using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public int health = 100;
    private Animator anim;
    private EnemyScript enemyScript;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyScript>();
    }

    public void DealDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
        {
            health = 0;

        }
        if (health == 0)
        {
            enemyScript.enabled = false;
            anim.Play(MyTags.DEAD_ANIMATION);
            Invoke("DisableEnemy", 3f);
        }
    }

    void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
