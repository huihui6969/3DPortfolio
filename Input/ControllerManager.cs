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
    //��� ��Ʈ�ѷ��� ����Ʈ�� ����
    private static List<ControllerManager> Controllers = new List<ControllerManager>();  //��� �����!

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
    //index(���°)�� �ش��ϴ� ��Ʈ�ѷ� �Ŵ����� �޾ƿ�
    public static ControllerManager GetController(int index)
    {
        if(index < 0 || index >= Controllers.Count)
        {
            return null;
        }
        return Controllers[index];
    }
}
