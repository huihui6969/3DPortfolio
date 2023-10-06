using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    AudioClip[] footstepSounds = default;

    [SerializeField]
    AudioClip[] runningstepSounds = default;

    [SerializeField]
    AudioClip[] attackSounds = default;

    [SerializeField]
    AudioClip rollingSound = default;
    void footStep()
    {
        AudioManager.instance.source.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
    void RunStep()
    {
        AudioManager.instance.source.PlayOneShot(runningstepSounds[Random.Range(0, runningstepSounds.Length)]);
    }
    void AttackSounds()
    {
        AudioManager.instance.source.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length)]);
    }
    void RollingSound()
    {
        AudioManager.instance.source.PlayOneShot(rollingSound);
    }
}
