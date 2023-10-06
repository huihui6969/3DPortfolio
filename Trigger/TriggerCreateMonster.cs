using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCreateMonster : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AIBase monster;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("TriggerIn");
        }
        Invoke("UnFreezeMonster3", 10f);
    }

    public void UnFreezeMonster3()
    {
        monster.enableAct1 = true;
    }


}
