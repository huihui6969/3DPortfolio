using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurtainUpDown : MonoBehaviour
{
    /// <summary> true는 내리고, false는 올립니다! </summary>
    public bool value = true;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Image curtain;

    // Update is called once per frame
    void Update()
    {
        //내리기
        if (value)
        {
            if (curtain.fillAmount <= 1.0f)
            {
                curtain.fillAmount += Time.deltaTime * speed;
            };
        }
        //올리기
        else
        {
            if (curtain.fillAmount > 0.0f)
            {
                curtain.fillAmount -= Time.deltaTime * speed;
            };
        };
    }
}
