using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("발자국 개수")]
    [SerializeField] private Text UITrace;
    public int traceNum = 0;

    [Tooltip("레벨")]
    [SerializeField] private Text UILevel;

    void Update()
    {
        UITrace.text = traceNum.ToString();
        switch (traceNum)
        {
            case 5:
                UILevel.text = "2";
                break;

            case 10:
                UILevel.text = "3";
                break;

            case 15:
                UILevel.text = "4";
                break;

            case 20:
                UILevel.text = "5";
                break;
        }
    }
}
