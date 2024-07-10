using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Re_Start_Fade : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private Image image_2;

    [SerializeField]
    private float Speed;

    Death_Fade DF;
    Re_Match_Data RMD;
    public void Start_Re()
    {
        StartCoroutine(Start_Fade_In());
    }
    private IEnumerator Start_Fade_In()
    {
        DF = FindObjectOfType<Death_Fade>();
        if (DF == null)
        {
            GameObject UI_Canvas = GameObject.FindGameObjectWithTag("UI_Canvas");
            DF=UI_Canvas.gameObject.transform.Find("Death_").GetComponent<Death_Fade>();
        }
        DF.Death_False();

        RMD = FindObjectOfType<Re_Match_Data>();
        RMD.Set_Data_Position();

        image.gameObject.SetActive(true);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

        while (image.color.a >= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        image.gameObject.SetActive(false);

        GameManager.Instance.Re_Play();
    }
    public void Start_Back()
    {
        StartCoroutine(Start_Back_In());
    }
    private IEnumerator Start_Back_In()
    {
        DF = FindObjectOfType<Death_Fade>();
        if (DF == null)
        {
            GameObject UI_Canvas = GameObject.FindGameObjectWithTag("UI_Canvas");
            DF = UI_Canvas.gameObject.transform.Find("Death_").GetComponent<Death_Fade>();
        }
        DF.Death_False();

        image.gameObject.SetActive(true);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

        while (image.color.a >= 0.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        image.gameObject.SetActive(false);
    }
    public void Start_RE_Fade()
    {
        StartCoroutine(Start_RE_Fade_In());
    }
    private IEnumerator Start_RE_Fade_In()
    {
        image_2.gameObject.SetActive(true);
        image_2.color = new Color(image_2.color.r, image_2.color.g, image_2.color.b, 1);

        while (image_2.color.a >= 0.0f)
        {
            image_2.color = new Color(image_2.color.r, image_2.color.g, image_2.color.b, image_2.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        image_2.color = new Color(image_2.color.r, image_2.color.g, image_2.color.b, 0);
        image_2.gameObject.SetActive(false);
    }
}
