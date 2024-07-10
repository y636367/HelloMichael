using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue_Check : MonoBehaviour
{
    [SerializeField]
    private GameObject Continue_Panel;

    [SerializeField]
    private GameObject Crawler_;
    private void Awake()
    {
        Invoke("Clear_Check", 0.2f);
        Invoke("Continue_Check_",0.1f);
    }
    private void Continue_Check_()
    {
        if (GameManager.Instance.Save_Point||GameManager.Instance.Back_Point)
        {
            Continue_Panel.SetActive(true);
        }
        else
        {
            Continue_Panel.SetActive(false);
        }
    }
    private void Clear_Check()
    {
        if (GameManager.Instance.Game_Clear)
        {
            Crawler_.SetActive(true);
        }
        else
        {
            Crawler_.SetActive(false);
        }
    }
}
