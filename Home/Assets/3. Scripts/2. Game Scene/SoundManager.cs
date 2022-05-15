using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Tooltip("움직임")]
    [SerializeField] private AudioClip audioWalk;

    [Tooltip("첫 번째 데미지 입음")]
    [SerializeField] private AudioClip audioHit1;
    [Tooltip("두 번째 데미지 입음")]
    [SerializeField] private AudioClip audioHit2;
    [Tooltip("플레이어 죽음")]
    [SerializeField] private AudioClip audioDie;

    [Tooltip("아이템 획득")]
    [SerializeField] private AudioClip audioItem;

    [Tooltip("타임 오버")]
    [SerializeField] private AudioClip audioTimeOver;
    [Tooltip("소녀 실종")]
    [SerializeField] private AudioClip audioGirlMissing;

    [Tooltip("엔터")]
    [SerializeField] private AudioClip audioEnter;

    AudioSource audioSource;
    void Awake()
    {
        audioSource=GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        switch(action)
        {
            case "Walk":
                audioSource.clip = audioWalk;
                audioSource.Play();
                break;
            case "HIT1":
                audioSource.clip = audioHit1;
                audioSource.PlayOneShot(audioHit1);
                break;
            case "HIT2":
                audioSource.clip = audioHit2;
                audioSource.PlayOneShot(audioHit2);
                break;
            case "DIE":
                audioSource.clip = audioDie;
                audioSource.PlayOneShot(audioDie);
                break;
            case "Item":
                audioSource.clip = audioItem;
                audioSource.PlayOneShot(audioItem);
                break;
            case "TimeOver":
                audioSource.clip = audioTimeOver;
                audioSource.PlayOneShot(audioTimeOver);
                break;
            case "GirlMissing":
                audioSource.clip = audioGirlMissing;
                audioSource.PlayOneShot(audioGirlMissing);
                break;
            case "Enter":
                audioSource.clip = audioEnter;
                audioSource.PlayOneShot(audioEnter);
                break;
        }
    }

    public void StopSound(string action)
    {
        switch (action)
        {
            case "Walk":
                audioSource.clip = audioWalk;
                audioSource.Stop();
                break;
        }
    }
}
