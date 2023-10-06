using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillStun : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Collider other;
    private void OnTriggerEnter()
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("TriggerStun");
        }
    }
}
