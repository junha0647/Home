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
        // Enter Ű�� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PressAnyKey());
        }
    }

    // �ƹ� Ű�� ������ ����Ǵ� ���� ��� //
    [Tooltip("Fade ��ũ��Ʈ ������ �ִ� ������Ʈ")]
    [SerializeField] private Fade Fade;

    [Tooltip("First ������Ʈ")]
    [SerializeField] private GameObject st;

    [Tooltip("Second ������Ʈ")]
    [SerializeField] private GameObject nd;
    /*
    [Tooltip("Next �ؽ�Ʈ ������Ʈ")]
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