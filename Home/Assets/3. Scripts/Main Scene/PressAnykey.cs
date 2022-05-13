using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnykey : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(offText());
    }

    void Update()
    {
        // Enter 키를 눌러 게임 시작
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PressAnyKey());
        }
    }

    // 아무 키나 누르면 실행되는 동작 방식 //
    [Tooltip("Fade 스크립트 가지고 있는 오브젝트")]
    [SerializeField] private Fade Fade;

    [Tooltip("First 오브젝트")]
    [SerializeField] private GameObject st;

    [Tooltip("Second 오브젝트")]
    [SerializeField] private GameObject nd;
    /*
    [Tooltip("Next 텍스트 오브젝트")]
    [SerializeField] private GameObject nextBtn;
    */

    public IEnumerator PressAnyKey()
    {
        Fade.FadeIn();

        yield return new WaitForSeconds(1.5f);

        st.SetActive(false);

        nd.SetActive(true);
        //nextBtn.SetActive(true);
    }
    // ================================ //

    // 텍스트 깜빡이는 효과 //
    [Tooltip("Start 오브젝트")]
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