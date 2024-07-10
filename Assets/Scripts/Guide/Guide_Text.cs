using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guide_Text : MonoBehaviour
{
    [Header("Stage_Day")]
    [SerializeField]
    private TMP_Text Move;
    [SerializeField]
    private TMP_Text Zone;
    [SerializeField]
    private TMP_Text Zoom;
    [SerializeField]
    private TMP_Text Sprint;

    [Header("InHouse_Day")]
    [SerializeField]
    private TMP_Text Interct;
    [SerializeField]
    private TMP_Text Crouch_Down;
    [SerializeField]
    private TMP_Text Object_Interct;

    public bool Stage = false;
    private void Awake()
    {
        if (!Stage)
        {
            Move.text = "Use the Key " + "\n" +
                "Forward " + ((KeySetting.keys[(KeyAction)0]==KeyCode.Mouse0)? "LeftMouse":
                (KeySetting.keys[(KeyAction)0] == KeyCode.Mouse1) ? "RightMouse":
                (KeySetting.keys[(KeyAction)0] == KeyCode.Mouse2) ? "MouseWheel": KeySetting.keys[(KeyAction)0]) + "\n" +
                "Backwards " + ((KeySetting.keys[(KeyAction)3] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)3] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)3] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)3]) + "\n" +
               "Left " + ((KeySetting.keys[(KeyAction)2] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)2] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)2] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)2]) + "\n" +
               "RIght " + ((KeySetting.keys[(KeyAction)1] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)1] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)1] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)1]);

            Zone.text = "Press " + ((KeySetting.keys[(KeyAction)6] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)6]);
            Zoom.text = "Press " + ((KeySetting.keys[(KeyAction)7] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)7] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)7] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)7]);
            Sprint.text = ((KeySetting.keys[(KeyAction)4] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)4] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)4] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)4]) + " for Sprint";
        }
        else
        {
            Interct.text = "Press " + ((KeySetting.keys[(KeyAction)6] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)6]) + " to interact with the object";
            Crouch_Down.text = ((KeySetting.keys[(KeyAction)5] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)5] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)5] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)5]) + " for Crouch down";
            Object_Interct.text = "Press the "+((KeySetting.keys[(KeyAction)9] == KeyCode.Mouse0) ? "LeftMouse" :
                    (KeySetting.keys[(KeyAction)9] == KeyCode.Mouse1) ? "RightMouse" :
                    (KeySetting.keys[(KeyAction)9] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)9]) + ", You can take object action";
        }
    }
    public void Setting_Update()
    {
        if (!Stage)
        {
            Move.text = "Use the Key " + "\n" +
                "Forward " + ((KeySetting.keys[(KeyAction)0] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)0] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)0] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)0]) + "\n" +
                "Backwards " + ((KeySetting.keys[(KeyAction)3] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)3] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)3] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)3]) + "\n" +
               "Left " + ((KeySetting.keys[(KeyAction)2] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)2] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)2] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)2]) + "\n" +
               "RIght " + ((KeySetting.keys[(KeyAction)1] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)1] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)1] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)1]);

            Zone.text = "Press " + ((KeySetting.keys[(KeyAction)6] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)6]);
            Zoom.text = "Press " + ((KeySetting.keys[(KeyAction)7] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)7] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)7] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)7]);
            Sprint.text = ((KeySetting.keys[(KeyAction)4] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)4] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)4] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)4]) + " for Sprint";
        }
        else
        {
            Interct.text = "Press " + ((KeySetting.keys[(KeyAction)6] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)6] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)6]) + " to interact with the object";
            Crouch_Down.text = ((KeySetting.keys[(KeyAction)5] == KeyCode.Mouse0) ? "LeftMouse" :
                (KeySetting.keys[(KeyAction)5] == KeyCode.Mouse1) ? "RightMouse" :
                (KeySetting.keys[(KeyAction)5] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)5]) + " for Crouch down";
            Object_Interct.text = "Press the " + ((KeySetting.keys[(KeyAction)9] == KeyCode.Mouse0) ? "LeftMouse" :
                    (KeySetting.keys[(KeyAction)9] == KeyCode.Mouse1) ? "RightMouse" :
                    (KeySetting.keys[(KeyAction)9] == KeyCode.Mouse2) ? "MouseWheel" : KeySetting.keys[(KeyAction)9]) + ", You can take object action";
        }
    }
}
