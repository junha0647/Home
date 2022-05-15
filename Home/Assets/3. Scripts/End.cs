using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Ending());
        }
    }

    IEnumerator Ending()
    {
        StartCoroutine(onText());
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("1. Main Scene");
    }

    [SerializeField] private Text text;
    IEnumerator onText()
    {
        text.gameObject.SetActive(true);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
    }

    [Tooltip("페이드인 시킬 오브젝트")]
    [SerializeField] private Image Image;
    float time = 0f;
    float F_time = 2f;
    IEnumerator FadeIn()
    {
        Image.gameObject.SetActive(true);
        Color alpha = Image.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Image.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
