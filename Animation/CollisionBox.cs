using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    public void OnAttackCollsion()
    {
        attackCollision.SetActive(true);
    }
}
