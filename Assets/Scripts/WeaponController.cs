using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Shovel, Shield, Pusher;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool IsAttacking = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                ShovelAttack();
            }
        }
    }

    public void ShovelAttack()
    {
        IsAttacking = true;
        CanAttack= false;
        Animator anim = Shovel.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack= true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking= false;
    }

}
