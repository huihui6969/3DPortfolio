using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToBlockButton : MonoBehaviour
{
    [SerializeField]
    private CheckComponent Checker;

    [SerializeField]
    private CharacterManager manager;

    [SerializeField]
    private int buttonNumber;
    void Update()
    {
        manager.buttonAvailable[buttonNumber] = Checker.result;
    }
}
