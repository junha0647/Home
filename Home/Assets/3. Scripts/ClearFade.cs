using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearFade : MonoBehaviour
{
    [Tooltip("페이드인 시킬 오브젝트")]
    [SerializeField] private Image Image;

    float time = 0f;
    float F_time = 2f;

    void Start()
    {
        StartCoroutine(FadeOutController());
    }

    IEnumerator FadeOutController()
    {
        Color alpha = Image.color;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Image.color = alpha;
            yield return null;
        }
        Image.gameObject.SetActive(false);
        yield return null;
    }
}
