using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Set_Value : MonoBehaviour
{
    [SerializeField]
    private float Current_Difficulty;
    [SerializeField]
    private float Current_Mouse_Smooth;
    [SerializeField]
    private Slider Smooth_;
    [SerializeField]
    private bool Current_Invert;
    [SerializeField]
    private TMP_Text Invert_Text;
    [SerializeField]
    private float Current_Shadow;
    [SerializeField]
    private float Current_Texture;

    [SerializeField]
    private Start_Scene SS;
    private void Awake()
    {
        Current_Difficulty = GameManager.Instance.Minute;
        Current_Mouse_Smooth = OptionManager.Instance.current_smooth;
        Current_Invert = OptionManager.Instance.Mouse_Invert;
        Current_Shadow = OptionManager.Instance.Current_S_Quality;
        Current_Texture = OptionManager.Instance.Current_T_Quality;

        Difficulty_Set();
        MouseOption_Set();
        Graphics_Set();
    }
    private void Difficulty_Set()
    {
        if (Current_Difficulty != 5f)
        {
            SS.Hard_On();
        }else
        {
            SS.Nomal_On();
        }
    }
    private void MouseOption_Set()
    {
        Smooth_.value = Current_Mouse_Smooth;

        if (Current_Invert)
        {
            Invert_Text.text = "on";
        }
        else
        {
            Invert_Text.text = "off";
        }
    }
    private void Graphics_Set()
    {
        switch (Current_Shadow)
        {
            case 0:
                SS.Shadow_Off();
                break;
            case 2:
                SS.Shadow_Low();
                break;
            case 3: 
                SS.Shadow_High();
                break;
        }

        switch (Current_Texture)
        {
            case 1:
                SS.Texture_Low();
                break;
            case 3:
                SS.Texture_Middle();
                break;
            case 5:
                SS.Texture_High();
                break;
        }
    }
    public void Get_Mouse_S()
    {
        Current_Mouse_Smooth = OptionManager.Instance.current_smooth;
    }
}
