using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByValue : ValueComponent
{
    [SerializeField]
    public Transform cameraArm;

    [SerializeField]
    private Transform charactorBody;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float RunSpeed;

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private string target;

    [SerializeField]
    public Vector3 moveDirection;

    [SerializeField]
    private CharacterBase character;

    public Vector2 moveInput;


    private void Start()
    {
    }
    void Update()
    {
        move();
    }

    public void move()
    {
        //Vector3 moveDirection = new Vector3(Mathf.Sin(value * Mathf.PI), 0, Mathf.Cos(value * Mathf.PI));
         moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Debug.Log(moveDirection);

        OnMovement(moveInput.x, moveInput.y);

        bool isMove = moveInput.magnitude != 0;

        if (isMove) //&& character.walkDisableTime <= 0.01f) // 이건 왜 null로 인식 하는거야 ㅠㅠㅠㅠ
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            moveDirection = lookForward * moveInput.y + lookRight * moveInput.x;

            charactorBody.forward = lookForward;

            void Walk()
            {
                anim.SetBool(target, false);
                //rigid.AddForce(moveDirection * moveSpeed);
                transform.position += moveDirection * Time.deltaTime * moveSpeed;
            }

            void Run()
            {
                anim.SetBool(target,true);
                //rigid.AddForce(moveDirection * RunSpeed);
                transform.position += moveDirection * Time.deltaTime * RunSpeed;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else
            {
                Walk();
            }
        }
    }

    private void OnMovement(float horizontal, float vertical)
    {
        anim.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
        anim.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
    }
}
