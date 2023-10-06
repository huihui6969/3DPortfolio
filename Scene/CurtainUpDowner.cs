using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainUpDown : MonoBehaviour
{
    /// <summary> true�� ������, false�� �ø��ϴ�! </summary>
    public bool value = true;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Image curtain;

    // Update is called once per frame
    void Update()
    {
        //������
        if (value)
        {
            if (curtain.fillAmount <= 1.0f)
            {
                curtain.fillAmount += Time.deltaTime * speed;
            };
        }
        //�ø���
        else
        {
            if (curtain.fillAmount > 0.0f)
            {
                curtain.fillAmount -= Time.deltaTime * speed;
            };
        };
    }
}
