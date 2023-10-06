using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Keystate
//{ 
//    Down,
//    On,
//    Up 
//}
public class ButtonInput : MonoBehaviour
{
    public bool isDown = false;
    public bool isButton = false;
    public bool isUp = false;

    [SerializeField]
    private KeyCode target;
    //public struct KeySet
    //{
    //    public KeyCode key;
    //    public KeyState state;
    //}
    //struct keySet[] actions;

    void Update()
    {
        isDown = Input.GetKeyDown(target);

        isButton = Input.GetKey(target);

        isUp = Input.GetKeyUp(target);
    }
}
