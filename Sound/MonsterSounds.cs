using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip idleSound = default;

    [SerializeField]
    AudioClip[] footstepSounds = default;

    [SerializeField]
    AudioClip[] attackSounds = default;

    [SerializeField]
    AudioClip skill3Sound = default;

    [SerializeField]
    AudioClip skill4Sound1 = default;

    [SerializeField]
    AudioClip skill4Sound2 = default;

    [SerializeField]
    AudioClip skill5Sound1 = default;

    [SerializeField]
    AudioClip skill5Sound2 = default;

    [SerializeField]
    AudioClip born1Sound = default;

    [SerializeField]
    AudioClip born2Sound = default;

    [SerializeField]
    AudioClip deadSound = default;

    void BreathSound()
    {
        AudioManager.instance.source.PlayOneShot(idleSound);

    }
    void footStep()
    {
        AudioManager.instance.source.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }

    void AttackSound()
    {
        AudioManager.instance.source.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
    }

    void Skill3Sound()
    {
        AudioManager.instance.source.PlayOneShot(skill3Sound);
    }

    void Skill4Sound1()
    {
        AudioManager.instance.source.PlayOneShot(skill4Sound1);
    }
    void Skill4Sound2()
    {
        AudioManager.instance.source.PlayOneShot(skill4Sound2);
    }
    void Skill5Sound1()
    {
        AudioManager.instance.source.PlayOneShot(skill5Sound1);
    }
    void Skill5Sound2()
    {
        AudioManager.instance.source.PlayOneShot(skill5Sound2);
    }
    void Born1Sound()
    {
        AudioManager.instance.source.PlayOneShot(born1Sound);
    }
    void Born2Sound()
    {
        AudioManager.instance.source.PlayOneShot(born2Sound);
    }
    void DeadSound()
    {
        AudioManager.instance.source.PlayOneShot(deadSound);
    }
}
