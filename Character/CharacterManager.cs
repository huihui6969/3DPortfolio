using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//�� ģ���� ����ϴ� ������ Ŭ���� ������ ��ø���� Ŭ���� ����ϱ� �����̴�!
public class ValuePackager
{
    public ValueComponent[] components;
}

[System.Serializable]
public class ButtonPackager
{
    public ButtonComponent[] components;
}
public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private ControllerManager controller;

    //�� �κ� �����غ��ڱ�!!!!!!!!!!!!!!~!!!!!!!!!!!!!!!!!!!!!!

    //2�� �迭�� ����Ƽ���� �Ⱥ�����!
    [SerializeField]
    private ValuePackager[] values;

    [SerializeField]
    private ButtonPackager[] buttons;

    [SerializeField]
    public bool[] buttonAvailable;
    void Update()
    {
        //������ ���ÿ� ����Ҽ� �ְ� �ϴ� ���� ex) MoveByValue�� FlipByValue�� ���ÿ� ��Ʈ�ѷ��� ����ϱ� ����
        for(int i = 0; i < values.Length; i++)
        {
            for(int j = 0; j < values[i].components.Length; j++)
            {
                if(values[i].components[j] != null)
                {
                    //������Ʈ�� ������������� ����ǰ� �����!
                    values[i].components[j].value = controller.GetLinear(i);
                }
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            for (int j = 0; j < buttons[i].components.Length; j++)
            {
                if (buttons[i].components[j] != null && buttonAvailable[i])
                {
                    buttons[i].components[j].SetButton(controller.GetButton(i));
                }
            }
        }
    }
}
