using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Key_Text : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] txt;

    private void Start()
    { for (int i = 0; i < txt.Length; i++)
        {
            if (KeySetting.keys[(KeyAction)i] == KeyCode.Mouse0)
                txt[i].text = "LeftMouse";
            else if (KeySetting.keys[(KeyAction)i] == KeyCode.Mouse1)
                txt[i].text = "RightMouse";
            else if (KeySetting.keys[(KeyAction)i] == KeyCode.Mouse2)
                txt[i].text = "MouseWheel";
            else
                txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        }
    }
    private void Update()
    {
        if (Key_Manager.Instance.Check)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                switch (KeySetting.keys[(KeyAction)i])
                {
                    case KeyCode.Mouse0:
                        txt[i].text = "LeftMouse";
                        break;
                    case KeyCode.Mouse1:
                        txt[i].text = "RihgtMouse";
                        break;
                    case KeyCode.Mouse2:
                        txt[i].text = "MouseWheel";
                        break;
                    default:
                        txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
                        break;

                }
            }
        }
    }
    public void Set_Text_2()
    {
        GameObject Canvas_ = GameObject.FindGameObjectWithTag("Canvas_");
        GameObject Canv_Options = Canvas_.transform.Find("Canv_Options").gameObject;
        GameObject Panels = Canv_Options.transform.Find("PANELS").gameObject;
        GameObject Panel_Key = Panels.transform.Find("PanelKeyBindings").gameObject;

        GameObject MoveMentPanel = Panel_Key.transform.Find("MovementPanel").gameObject;
        GameObject ActionPanel = Panel_Key.transform.Find("ActonPanel").gameObject;
        GameObject GeneralPanel = Panel_Key.transform.Find("GeneralPanel").gameObject;

        GameObject Btn_1 = MoveMentPanel.transform.Find("Btn_Assign_1").gameObject;
        txt[0] = Btn_1.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_2 = MoveMentPanel.transform.Find("Btn_Assign_2").gameObject;
        txt[1] = Btn_2.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_3 = MoveMentPanel.transform.Find("Btn_Assign_3").gameObject;
        txt[2] = Btn_3.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_4 = MoveMentPanel.transform.Find("Btn_Assign_4").gameObject;
        txt[3] = Btn_4.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_5 = MoveMentPanel.transform.Find("Btn_Assign_5").gameObject;
        txt[4] = Btn_5.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_6 = MoveMentPanel.transform.Find("Btn_Assign_6").gameObject;
        txt[5] = Btn_6.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();

        GameObject Btn_7 = ActionPanel.transform.Find("Btn_Assign_7").gameObject;
        txt[6] = Btn_7.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_8 = ActionPanel.transform.Find("Btn_Assign_8").gameObject;
        txt[7] = Btn_8.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_9 = ActionPanel.transform.Find("Btn_Assign_9").gameObject;
        txt[8] = Btn_9.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_10 = ActionPanel.transform.Find("Btn_Assign_10").gameObject;
        txt[9] = Btn_10.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();

        GameObject Btn_11 = GeneralPanel.transform.Find("Btn_Assign_11").gameObject;
        txt[10] = Btn_11.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
    }
    public void Set_Text()
    {
        GameObject Start_Main = GameObject.FindGameObjectWithTag("Main_Menu");
        GameObject Option_Panel = Start_Main.transform.Find("Canv_Options").gameObject;
        GameObject Panels = Option_Panel.transform.Find("PANELS").gameObject;
        GameObject Panel_Key = Panels.transform.Find("PanelKeyBindings").gameObject;

        GameObject MoveMentPanel = Panel_Key.transform.Find("MovementPanel").gameObject;
        GameObject ActionPanel = Panel_Key.transform.Find("ActonPanel").gameObject;
        GameObject GeneralPanel = Panel_Key.transform.Find("GeneralPanel").gameObject;

        GameObject Btn_1 = MoveMentPanel.transform.Find("Btn_Assign_1").gameObject;
        txt[0] = Btn_1.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_2 = MoveMentPanel.transform.Find("Btn_Assign_2").gameObject;
        txt[1] = Btn_2.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_3 = MoveMentPanel.transform.Find("Btn_Assign_3").gameObject;
        txt[2] = Btn_3.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_4 = MoveMentPanel.transform.Find("Btn_Assign_4").gameObject;
        txt[3] = Btn_4.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_5 = MoveMentPanel.transform.Find("Btn_Assign_5").gameObject;
        txt[4] = Btn_5.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_6 = MoveMentPanel.transform.Find("Btn_Assign_6").gameObject;
        txt[5] = Btn_6.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();

        GameObject Btn_7 = ActionPanel.transform.Find("Btn_Assign_7").gameObject;
        txt[6] = Btn_7.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_8 = ActionPanel.transform.Find("Btn_Assign_8").gameObject;
        txt[7] = Btn_8.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_9 = ActionPanel.transform.Find("Btn_Assign_9").gameObject;
        txt[8] = Btn_9.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
        GameObject Btn_10 = ActionPanel.transform.Find("Btn_Assign_10").gameObject;
        txt[9] = Btn_10.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();

        GameObject Btn_11 = GeneralPanel.transform.Find("Btn_Assign_11").gameObject;
        txt[10] = Btn_11.transform.Find("notassigned").gameObject.GetComponent<TMP_Text>();
    }
}
