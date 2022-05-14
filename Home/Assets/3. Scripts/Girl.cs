using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Save());
    }

    [SerializeField] private GameObject spawner;
    [SerializeField] private SpriteRenderer flashSR;
    [SerializeField] private GameObject arrow;
    IEnumerator Save()
    {
        StartCoroutine(lightAlpha());
        flashSR.enabled = false;
        spawner.SetActive(false);
        arrow.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(alphaUP());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("4. Game Clear Scene");
    }

    [SerializeField] private SpriteRenderer sr;
    IEnumerator lightAlpha()
    {
        for (int i = 9; i >= 0; i--)
        {
            float f = i / 10.0f;
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    [Tooltip("페이드인 시킬 오브젝트")]
    [SerializeField] private Image Image;
    float time = 0f;
    float F_time = 1f;
    IEnumerator alphaUP()
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
