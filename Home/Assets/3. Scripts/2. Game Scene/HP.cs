using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private int HPValue = 3;
    [SerializeField] private GameObject[] UIHealth;

    public void HealthDown()
    {
        HPValue--;
        switch (HPValue)
        {
            case 2:
                UIHealth[HPValue].SetActive(false);
                break;
            case 1:
                UIHealth[HPValue].SetActive(false);
                break;
            case 0:
                UIHealth[HPValue].SetActive(false);
                break;
        }

    }
}
