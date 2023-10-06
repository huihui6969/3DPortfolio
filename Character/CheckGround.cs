using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : CheckComponent
{
    [SerializeField]
    private Rigidbody rigid;
    void Update()
    {
        if(Mathf.Abs(rigid.velocity.y) <= 0.0001f)
        {
            result = true;
        }
        else
        {
            result = false;

        }
    }
}
