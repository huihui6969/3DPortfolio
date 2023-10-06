using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollByButton : ButtonComponent
{
    [SerializeField]
    private MoveByValue moveScript;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float rollForce;

    [SerializeField]
    private float rollCoolDownCurrent;

    [SerializeField]
    private float rollCoolDown;

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private string target;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (rollCoolDownCurrent < Time.realtimeSinceStartup)
            {
                Roll();
                anim.SetTrigger(target);
                rollCoolDownCurrent = Time.realtimeSinceStartup + rollCoolDown;

            }
        }
    }
    private void Roll()
    {
        rigid.AddForce(moveScript.moveDirection * rollForce);
    }
}
