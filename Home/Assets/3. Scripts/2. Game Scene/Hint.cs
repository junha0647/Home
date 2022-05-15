using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    [SerializeField] private GameObject[] UIHint;
    [SerializeField] private int HintValue;

    [Tooltip("����")]
    [SerializeField] private Text UILevel;

    [Tooltip("_Sound ������Ʈ �޾ƿ���")]
    [SerializeField] private SoundManager soundManager;

    [Tooltip("Arrow ������Ʈ �޾ƿ���")]
    [SerializeField] private GameObject Arrow;
    [Tooltip("���� ���� ������Ʈ �޾ƿ���")]
    [SerializeField] private GameObject Girlobj;

    [SerializeField] private GameObject trackSpawn;
    [SerializeField] private GameObject itemSpawn;

    public void getHint()
    {
        soundManager.PlaySound("Item");
        ++HintValue;
        switch (HintValue)
        {
            case 1:
                UIHint[HintValue - 1].SetActive(true);
                break;

            case 2:
                UIHint[HintValue - 1].SetActive(true);
                UILevel.text = "2";
                break;

            case 3:
                UIHint[HintValue - 1].SetActive(true);
                break;

            case 4:
                UIHint[HintValue - 1].SetActive(true);
                UILevel.text = "3";
                break;

            case 5:
                UIHint[HintValue - 1].SetActive(true);
                break;

            case 6:
                UIHint[HintValue - 1].SetActive(true);
                UILevel.text = "4";
                break;

            case 7:
                UIHint[HintValue - 1].SetActive(true);
                break;

            case 8:
                UIHint[HintValue - 1].SetActive(true);
                UILevel.text = "5";
                break;

            case 9:
                UIHint[HintValue - 1].SetActive(true);
                break;

            case 10:
                UIHint[HintValue - 1].SetActive(true);
                Arrow.SetActive(true);
                Girlobj.SetActive(true);

                trackSpawn.SetActive(false);
                itemSpawn.SetActive(false);
                break;
        }
    }

    public int GetValue()
    {
        return HintValue;
    }
}