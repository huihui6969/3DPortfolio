using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIBase : MonoBehaviour
{
    [SerializeField]
    public Transform noticedTarget;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float AttackCoolDown;

    [SerializeField]
    private float AttackCoolDownCurrent;

    [SerializeField]
    private float MonsterSpeed;

    [SerializeField]
    private Transform privotWeaponR;
    private int limit;

    [SerializeField]
    private Transform effectLocation;

    [SerializeField]
    private CharacterBase monster;

    public bool enableAct1;
    public bool enableAct2;

    BoxCollider colliderWeapon;

    private GameObject objWeapon;

    [SerializeField]
    private Transform characterLocation;

    [SerializeField]
    private Transform effectLocation2;
    [SerializeField]
    private Transform effectLocation3;

    void Start()
    {
        enableAct1 = false;
        enableAct2 = true;
        objWeapon = privotWeaponR.GetChild(0).gameObject;
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();
        colliderWeapon.enabled = false;
        limit = 0;
    }

    void Awake()
    {
        anim.SetTrigger("TriggerIn");
        Invoke("UnFreezeMonster", 10f);
    }

    void Update()
    {
        if (enableAct1 == true && enableAct2 == true)
        {
            LookAtPlayer();
            MonsterMove();
            MonsterAttack();
        }
    }

    private void LookAtPlayer()
    {
        Vector3 direction = noticedTarget.position - transform.position;

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
                Quaternion.LookRotation(direction), 5 * Time.deltaTime);
    }

    private void MonsterMove()
    {
        if ((noticedTarget.position - transform.position).magnitude >= 8)
        {
            anim.SetBool("isRun", true);
            //transform.position = Vector3.forward * MonsterSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * MonsterSpeed * Time.deltaTime);
        }

        if ((noticedTarget.position - transform.position).magnitude < 8)
        {
            anim.SetBool("isRun", false);
        }
    }

    public void MonsterAttack()
    {
        if ((noticedTarget.position - transform.position).magnitude < 8)
        {
            if (AttackCoolDownCurrent <= Time.realtimeSinceStartup)
            {
                AttackCoolDownCurrent = Time.realtimeSinceStartup + AttackCoolDown;

                if (monster.stageStep == 0)
                {
                    limit = 6;
                }

                if (monster.stageStep == 1)
                {
                    limit = 10;
                }

                if (monster.stageStep == 2)
                {
                    limit = 11;
                }

                int randomAction = Random.Range(0, limit);

                Debug.Log(randomAction);
                switch (randomAction)
                {
                    case 0:
                    case 1:
                    case 2:
                        anim.SetTrigger("TriggerAttack1");
                        Invoke("UnFreezeMonster", 1.2f);
                        Invoke("FreezeMonster", 1.5f);
                        Invoke("UnFreezeMonster", 2.0f);
                        break;
                    //SwordAttack1 È®·ü
                    case 3:
                    case 4:
                    case 5:
                        anim.SetTrigger("TriggerAttack2");
                        Invoke("UnFreezeMonster", 0.1f);
                        Invoke("FreezeMonster", 1.2f);
                        Invoke("UnFreezeMonster", 1.8f);
                        break;
                    case 6:
                    case 7:
                        anim.SetTrigger("TriggerAttack3");
                        Invoke("UnFreezeMonster", 2.0f);
                        break;
                    case 8:
                    case 9:
                        anim.SetTrigger("TriggerAttack4");
                        Invoke("UnFreezeMonster", 2.0f);
                        break;
                    case 10:
                        anim.SetTrigger("TriggerAttack5");
                        Invoke("UnFreezeMonster", 2.0f);
                        break;
                }
            }
        }
    }
    public void FreezeMonster()
    {
        enableAct1 = false;
    }
    public void UnFreezeMonster()
    {
        enableAct1 = true;
    }

    public void MonsterAttackStart()
    {
        colliderWeapon.enabled = true;

    }
    public void MonsteAttackEnd()
    {
        colliderWeapon.enabled = false;
    }

    public void CreateEffect(GameObject skillEffect)
    {
        GameObject currentEffect = Instantiate(skillEffect);

        if (effectLocation != null)
        {
            currentEffect.transform.position = effectLocation.position;
        }

        else
        {
            currentEffect.transform.position = effectLocation2.transform.position;
        }
    }

    public void CreateEffect2(GameObject skillEffect)
    {
        GameObject currentEffect = Instantiate(skillEffect);

        if (characterLocation != null)
        {
            currentEffect.transform.position = characterLocation.position;
        }

        else
        {
            currentEffect.transform.position = transform.position;
        }
    }
    public void CreateEffect3(GameObject skillEffect)
    {
        GameObject currentEffect = Instantiate(skillEffect);

        if (effectLocation3 != null)
        {
            currentEffect.transform.position = effectLocation3.position;
        }

        else
        {
            currentEffect.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterBase>().GetDamage(10);
        }
    }

    
}




//Á¤ÂûÇÔ¼ö
//private void Patrol()
//{
//    if ((transform.position - noticedTarget.position).magnitude > distance)
//    {
//        agent.speed = 3;

//        if (patrolLeftTime <= 0)
//        {
//            Vector3 GoalLocation = patrolCenter;

//            GoalLocation.x += Random.Range(-patrolRange, patrolRange);
//            GoalLocation.z += Random.Range(-patrolRange, patrolRange);
//            GoalLocation.y = 0;

//            agent.SetDestination(GoalLocation);

//            patrolLeftTime = patrolTime;
//        }
//        else
//        {
//            patrolLeftTime -= Time.deltaTime;
//        }
//    }
//    else
//    {
//        agent.speed = 3;
//        agent.SetDestination(noticedTarget.position);
//    }
//}

