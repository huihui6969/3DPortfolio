using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByButton : ButtonComponent
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private string target;

    void Update()
    {
        if(value)
        {
            rigid.AddForce(Vector3.up * jumpForce);
            value = false;
            anim.SetTrigger(target);
        }
    }
}
