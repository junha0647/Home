using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HP : MonoBehaviour
{
    public int HPValue = 3;
    [SerializeField] private GameObject[] UIHealth;

    [Tooltip("_Sound ������Ʈ �޾ƿ���")]
    [SerializeField] private SoundManager soundManager;

    public void HealthDown()
    {
        HPValue--;
        switch (HPValue)
        {
            case 2:
                UIHealth[HPValue].SetActive(false);
                soundManager.PlaySound("HIT1");
                break;
            case 1:
                UIHealth[HPValue].SetActive(false);
                soundManager.PlaySound("HIT2");
                break;
            case 0:
                UIHealth[HPValue].SetActive(false);
                soundManager.PlaySound("DIE");
                StartCoroutine(pDie());
                break;
        }
    }

    [Tooltip("Fade ������Ʈ �޾ƿ���")]
    [SerializeField] private Fade fade;
    [Tooltip("Game Over �ؽ�Ʈ ������Ʈ")]
    [SerializeField] private Text text;
    public IEnumerator pDie()
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
