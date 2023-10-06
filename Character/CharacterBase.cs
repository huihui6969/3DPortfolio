using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private ResourceContainer health;

    [SerializeField]
    private ResourceContainerST stamina;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private Transform boneTransform;

    [SerializeField]
    private AIBase monster;

    [SerializeField]
    private int regeneration;

    public int stageStep;

    private bool isMax;
    ResourceContainer GetHealthContainer()
    {
        return health;
    }
    ResourceContainerST GetStaminaContainer()
    {
        return stamina;
    }

    public bool IsDIe()
    {
        if (health != null && health.currentValue <= 0)
        {
            return true;
        }

        return false;
    }
    void Start()
    {
        stageStep = 0;
        isMax = false;
    }

    void Update()
    {
        if(stageStep == 1 && health.currentValue <= 200 && isMax == false)
        {
            health.currentValue += regeneration * Time.deltaTime * 20;

            if(health.currentValue >= 200)
            {
                isMax = true;
            }
        }

        if (stageStep == 2 && health.currentValue <= 200 && isMax == false)
        {
            health.currentValue += regeneration * Time.deltaTime * 20;

            if (health.currentValue >= 200)
            {
                isMax = true;
            }
        }

        //if (stamina.currentValue < 100)
        //{
        //    stamina.currentValue += regeneration * Time.deltaTime * 5;
        //}

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    stamina.currentValue -= regeneration * Time.deltaTime * 10;
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && stamina.currentValue >= 50)
        //{
        //    stamina.currentValue -= 50;
        //}
        //Debug.Log(stamina.currentValue);
    }

    public void GetDamage(int amount)
    {
        if (health != null)
        {
            if (health.currentValue <= 0)
            {
                return;
            }
            health.currentValue -= amount;


            if (anim != null && amount > 0)
            {
                if (health.currentValue <= 0)
                {
                    Stage();
                    stageStep += 1;
                }
                else
                {
                    anim.SetTrigger("TriggerHit");

                    Debug.Log(amount + "의 데미지를 입었습니다!");

                    if (hitEffect != null)
                    {
                        GameObject currentEffect = Instantiate(hitEffect);

                        if (boneTransform != null)
                        {
                            currentEffect.transform.position = boneTransform.position;
                        }

                        else
                        {
                            currentEffect.transform.position = transform.position;
                        }
                    }
                }
            }
        }
    }

    private void Stage()
    {
        if (stageStep == 0)
        {
            anim.SetTrigger("TriggerStage1");
            monster.enableAct2 = false;
            Invoke("UnFreezeMonster2", 9.0f);
        }

        if (stageStep == 1)
        {
            isMax = false;
            anim.SetTrigger("TriggerStage2");
            monster.enableAct2 = false;
            Invoke("UnFreezeMonster2", 8.5f);

        }

        if (stageStep == 2)
        {
            anim.SetTrigger("TriggerDie");
            monster.enableAct2 = false;
            Invoke("UnFreezeMonster2", 15.0f);

            Rigidbody rigid = GetComponent<Rigidbody>();
            if (rigid != null) { Destroy(rigid); };

            Collider col = GetComponent<Collider>();
            if (col != null) { Destroy(col); };

            UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (nav != null)
            {
                nav.enabled = false;
            }

            AIBase ai = GetComponent<AIBase>();
            if (ai != null)
            {
                ai.enabled = false;
            }

            //Destroy(gameObject); 몇초뒤에 사라지게 만들기!
        }

        if (hitEffect != null)
        {
            GameObject currentEffect = Instantiate(hitEffect);

            if (boneTransform != null)
            {
                currentEffect.transform.position = boneTransform.position;
            }

            else
            {
                currentEffect.transform.position = transform.position;
            }
        }
    }
    public void FreezeMonster2()
    {
        monster.enableAct2 = false;
    }
    public void UnFreezeMonster2()
    {
        monster.enableAct2 = true;
    }
}

//walkDisableTime = Mathf.Max(0.5f, walkDisableTime);

//if (health.currentValue <= 0)
//{
//    //walkDisableTime = 1.0f;

//    Rigidbody rigid = GetComponent<Rigidbody>();
//    if (rigid != null) { Destroy(rigid); };

//    Collider col = GetComponent<Collider>();
//    if (col != null) { Destroy(col); };

//    UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
//    if (nav != null)
//    {
//        nav.enabled = false;
//    }

//    AIBase ai = GetComponent<AIBase>();
//    if (ai != null)
//    {
//        ai.enabled = false;
//    }
//}