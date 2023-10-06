using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInput : MonoBehaviour
{
    [SerializeField]
    private float acceleration;

    [SerializeField]
    public float value { get; private set; }

    Vector2 inputDirection = Vector2.zero;

    void Update()
    {
        bool isLeft = Input.GetKey(KeyCode.A);
        bool isRight = Input.GetKey(KeyCode.D);
        bool isForward = Input.GetKey(KeyCode.W);
        bool isBackward = Input.GetKey(KeyCode.S);
        

        if(!(isLeft ^ isRight))
        {
            inputDirection.x /= 2.0f;
        }
        else if(isLeft)
        {
            inputDirection.x -= Time.deltaTime * acceleration;
        }
        else if(isRight)
        {
            inputDirection.x += Time.deltaTime * acceleration;
        }

        if (!(isForward ^ isBackward))
        {
            inputDirection.y /= 2.0f;
        }
        else if (isForward)
        {
            inputDirection.y -= Time.deltaTime * acceleration;
        }
        else if (isBackward)
        {
            inputDirection.y += Time.deltaTime * acceleration;
        }

        inputDirection.x = Mathf.Clamp(inputDirection.x, -1.0f, 1.0f);
        inputDirection.y = Mathf.Clamp(inputDirection.y, -1.0f, 1.0f);

        value = Mathf.Atan2(inputDirection.x, inputDirection.y);
        //Debug.Log(Mathf.Sin(value * Mathf.Rad2Deg));
        //Debug.Log(Mathf.Cos(value * Mathf.Rad2Deg));
        //Debug.Log(Mathf.Cos(Mathf.PI /2));
        //Debug.Log(Mathf.Cos((Mathf.PI) /2));
        //Debug.Log(Mathf.Cos(90));

    }
}
