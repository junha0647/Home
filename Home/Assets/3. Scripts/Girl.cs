using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Girl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Save());
        }
            
        if (collision.gameObject.tag == "Tile")
        {
            Debug.Log("이동 시킴");
            //GirlSpawn.GetComponent<GirlSpwan>().GetRandomPosition();
            GirlSpawn.Spawn();
        }
    }

    /*
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            Debug.Log("이동 시킴");
            GirlSpawn.GetComponent<GirlSpwan>().GetRandomPosition();
            GirlSpawn.GetComponent<GirlSpwan>().Spawn();
        }
    }*/



    [SerializeField] private GameObject spawner;
    [SerializeField] private SpriteRenderer flashSR;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GirlSpwan GirlSpawn;
    [SerializeField] private GameObject trackObj;

    IEnumerator Save()
    {
        StartCoroutine(lightAlpha());
        flashSR.enabled = false;
        spawner.SetActive(false);
        arrow.SetActive(false);
        trackObj.SetActive(false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(alphaUP());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("4. Game Clear Scene");
    }

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject fLight;
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
        Destroy(fLight);
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
