using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackByButton : MonoBehaviour
{

    [SerializeField]
    private Transform privotWeaponR;

    BoxCollider colliderWeapon;

    private GameObject objWeapon;

    private Animator anim;

    private void Start()
    {
        objWeapon = privotWeaponR.GetChild(0).gameObject;
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        colliderWeapon.enabled = false;
    }
    private void Update()
    {
        kickAttack();
        ComboAttack();
    }

    private void kickAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("OnKickAttack");
        }
    }

    private void ComboAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("OnComboAttack");
        }
    }
    public void AttackStart()
    {
        colliderWeapon.enabled = true;

    }
    public void AttackEnd()
    {
        colliderWeapon.enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<CharacterBase>().GetDamage(10);
        }
    }
}
