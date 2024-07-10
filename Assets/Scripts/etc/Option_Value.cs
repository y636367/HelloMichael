using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Option_Value : MonoBehaviour
{
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
    private Option_Ingame OI;
    private void Awake()
    {
        Current_Mouse_Smooth = OptionManager.Instance.current_smooth;
        Current_Invert = OptionManager.Instance.Mouse_Invert;
        Current_Shadow = OptionManager.Instance.Current_S_Quality;
        Current_Texture = OptionManager.Instance.Current_T_Quality;

        MouseOption_Set();
        Graphics_Set();
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
                OI.Shadow_Off();
                break;
            case 2:
                OI.Shadow_Low();
                break;
            case 3:
                OI.Shadow_High();
                break;
        }

        switch (Current_Texture)
        {
            case 1:
                OI.Texture_Low();
                break;
            case 3:
                OI.Texture_Middle();
                break;
            case 5:
                OI.Texture_High();
                break;
        }
    }
    public void Get_Mouse_S()
    {
        Current_Mouse_Smooth = OptionManager.Instance.current_smooth;
    }
}
