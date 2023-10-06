using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove2AnimationBool : MonoBehaviour
{
    [SerializeField]    
    private AIBase from;

    [SerializeField]
    private Animator to;

    [SerializeField]
    private new string name;

    void Update()
    {
        //to.SetBool(name, from.IsRunning);
    }
}
