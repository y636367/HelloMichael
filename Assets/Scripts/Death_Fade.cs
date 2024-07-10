using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Death_Fade : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private TMP_Text text = null;

    [SerializeField]
    private Image block = null;

    [SerializeField]
    private GameObject[] Buttons = null;

    Player player;
    private void OnEnable()
    {
        block.gameObject.SetActive(false);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);

        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(false);

        StartCoroutine(Fade_Out());
    }
    private IEnumerator text_Fade_Out()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / Speed));
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        StartCoroutine(Block_Fade_In());
    }
    private IEnumerator Fade_Out()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        while (image.color.a < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + (Time.deltaTime / Speed));
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

        player=FindObjectOfType<Player>();
        player.Cursor_visiable();
        StartCoroutine(text_Fade_Out());
    }
    private IEnumerator Block_Fade_In()
    {
        block.gameObject.SetActive(true);
        block.color = new Color(block.color.r, block.color.g, block.color.b, 1);

        for (int i = 0; i < Buttons.Length; i++)
            Buttons[i].SetActive(true);

        while (block.color.a >= 0.0f)
        {
            block.color = new Color(block.color.r, block.color.g, block.color.b, block.color.a - (Time.deltaTime / Speed));
            yield return null;
        }
        block.color = new Color(block.color.r, block.color.g, block.color.b, 0);
        block.gameObject.SetActive(false);
    }
    public void Death_False()
    {
        image.gameObject.SetActive(false);
    }
}
