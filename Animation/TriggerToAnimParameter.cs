using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToAnimParameter : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private string targetTag;

    [SerializeField]
    private string parameter;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == targetTag)
        {
            anim.SetTrigger(parameter);
        }
    }
}
