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

    public void getHint()
    {
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
                // �÷��̾� �Ӹ� ���� ���̸� ����Ű�� ȭ��ǥ ����
                break;
        }
    }
}
