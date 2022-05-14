using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Enter : MonoBehaviour
{
    [Tooltip("_Sound ������Ʈ �޾ƿ���")]
    [SerializeField] private SoundManager soundManager;

    void Start()
    {
        StartCoroutine(offText());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            soundManager.PlaySound("Enter");
            StartCoroutine(PressEnter());
        }
    }

    public IEnumerator PressEnter()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("2. Game Scene");
    }

    // �ؽ�Ʈ �����̴� ȿ�� //
    [Tooltip("Start ������Ʈ")]
    [SerializeField] private Text text;
    public IEnumerator onText()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.2f);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(offText());
    }
    public IEnumerator offText()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.2f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
        StartCoroutine(onText());
    }
}
