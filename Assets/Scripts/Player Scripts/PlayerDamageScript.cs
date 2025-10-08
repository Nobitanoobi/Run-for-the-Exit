using UnityEngine;

public class PlayerDamageScript : MonoBehaviour
{
    public LayerMask enemyLayer;
    private int Damage = 35;

    private bool isAttack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, .8f, enemyLayer);

        if (hit.Length > 0)
        {
            if (hit[0].gameObject.tag == "Enemy" && isAttack)
            {
                hit[0].gameObject.GetComponent<EnemyHealthScript>().DealDamage(Damage);
                isAttack = false;
            }
        }
    }

    void OnEnable()
    {
        isAttack = true;
    }

}
