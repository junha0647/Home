using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Tooltip("ù ��° ������ ����")]
    [SerializeField] private AudioClip audioHit1;
    [Tooltip("�� ��° ������ ����")]
    [SerializeField] private AudioClip audioHit2;
    [Tooltip("�÷��̾� ����")]
    [SerializeField] private AudioClip audioDie;

    [Tooltip("Ÿ�� ����")]
    [SerializeField] private AudioClip audioTimeOver;
    [Tooltip("�ҳ� ����")]
    [SerializeField] private AudioClip audioGirlMissing;

    [Tooltip("����")]
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
}