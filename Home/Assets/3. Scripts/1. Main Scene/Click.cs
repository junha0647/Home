using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum BTNType
{
    Next,
}

public class Click : MonoBehaviour
{
    [Tooltip("각 버튼의 기능 선택")]
    [SerializeField] private BTNType currentType;

    [SerializeField] private SoundManager soundManager;
    int cnt = 0;

    [SerializeField] private GameObject tuto1;
    [SerializeField] private GameObject tuto2;

    public void OnBtnClick()
    {
        soundManager.PlaySound("Enter");

        switch (currentType)
        {
            case BTNType.Next:
                ++cnt;
                if(cnt == 1)
                {
                    tuto1.SetActive(false);
                    tuto2.SetActive(true);
                }
                else
                {
                    StartCoroutine(gameStart());
                }
                break;
        }
    }

    IEnumerator gameStart()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("2. Game Scene");
    }
}