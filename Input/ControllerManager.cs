using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyState
{
    Down,
    On,
    Up,
    Not
}

public class ControllerManager : MonoBehaviour
{
    //모든 컨트롤러를 리스트에 저장
    private static List<ControllerManager> Controllers = new List<ControllerManager>();  //목록 만들기!

    [SerializeField]
    private string name;

    [SerializeField]
    private LinearInput[] Linears;

    [SerializeField]
    private ButtonInput[] Buttons;

    void Start()
    {
        Controllers.Add(this);
    }

    public KeyState GetButton(int index)
    {
        if (index < 0 || index >= Buttons.Length)
        {
            return KeyState.Not;
        }
        if (Buttons[index].isDown)
        {
            return KeyState.Down;
        }
        if (Buttons[index].isButton)
        {
            return KeyState.On;
        }
        if (Buttons[index].isUp)
        {
            return KeyState.Up;
        }
        else
        {
            return KeyState.Not;
        }
    }
    public float GetLinear(int index)
    {
        if (index < 0 || index >= Linears.Length)
        {
            return 0;
        }
        return Linears[index].value;
    }
    //index(몇번째)에 해당하는 컨트롤러 매니저를 받아옴
    public static ControllerManager GetController(int index)
    {
        if(index < 0 || index >= Controllers.Count)
        {
            return null;
        }
        return Controllers[index];
    }
}
