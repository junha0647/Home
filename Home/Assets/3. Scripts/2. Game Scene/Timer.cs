using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [Tooltip("�ð�")]
    [SerializeField] private Text UItime;
    [Tooltip("�� �к��� ī��Ʈ �ٿ� �� �ǰ�?")]
    [SerializeField] private float timeValue;

    [Tooltip("_Sound ������Ʈ �޾ƿ���")]
    [SerializeField] private SoundManager soundManager;

    void Update()
    {
        calcTime();

        DisplayTime(timeValue);
    }

    void calcTime()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            soundManager.PlaySound("TimeOver");
            soundManager.PlaySound("GirlMissing");
            StartCoroutine(timeOver());
        }

        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);

        UItime.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    [Tooltip("Fade ������Ʈ �޾ƿ���")]
    [SerializeField] private Fade fade;
    [Tooltip("Game Over �ؽ�Ʈ ������Ʈ")]
    [SerializeField] private Text text;
    IEnumerator timeOver()
    {
        StartCoroutine(onText());
        yield return new WaitForSeconds(5f);
        fade.FadeIn();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("3. Game Over Scene");
    }

    float time = 0f;
    float F_time = 1f;
    IEnumerator onText()
    {
        text.gameObject.SetActive(true);
        Color alpha = text.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        yield return null;
    }
}