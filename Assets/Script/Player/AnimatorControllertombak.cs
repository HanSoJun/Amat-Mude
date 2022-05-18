using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllertombak : MonoBehaviour
{
    private Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackSpeed = 5;
    public float attackRange = 0.5f;
    public int attackDamage = 20;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("isAttack", false);

    }

    public void toggleAttackAnimation()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isAttack", true);
        if (gameObject.activeSelf)
        {
            StartCoroutine(DelayAttack());
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Update()
    {

    }
}
