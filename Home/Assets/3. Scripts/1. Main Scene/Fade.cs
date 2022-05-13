using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Tooltip("페이드인 시킬 오브젝트")]
    [SerializeField] private Image Image;

    float time = 0f;
    float F_time = 1f;

    public void FadeIn()
    {
        StartCoroutine(FadeInController());
    }
    IEnumerator FadeInController()
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
