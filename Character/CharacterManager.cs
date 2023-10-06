using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//이 친구를 사용하는 이유는 클래스 내에서 중첩으로 클래스 사용하기 위함이다!
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

    //이 부분 이해해보자구!!!!!!!!!!!!!!~!!!!!!!!!!!!!!!!!!!!!!

    //2차 배열은 유니티에서 안보여줌!
    [SerializeField]
    private ValuePackager[] values;

    [SerializeField]
    private ButtonPackager[] buttons;

    [SerializeField]
    public bool[] buttonAvailable;
    void Update()
    {
        //구성을 동시에 사용할수 있게 하는 역할 ex) MoveByValue와 FlipByValue를 동시에 컨트롤러로 사용하기 위함
        for(int i = 0; i < values.Length; i++)
        {
            for(int j = 0; j < values[i].components.Length; j++)
            {
                if(values[i].components[j] != null)
                {
                    //컴포넌트가 들어있을때에만 실행되게 만들기!
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
