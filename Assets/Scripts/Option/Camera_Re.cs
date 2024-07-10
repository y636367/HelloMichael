using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Re : MonoBehaviour
{
    [SerializeField]
    private OptionManager t_Option_Manager;

    [SerializeField]
    public bool Check=false;

    private void Awake()
    {
        t_Option_Manager=FindObjectOfType<OptionManager>();

        if (!Check)
        {
            t_Option_Manager.Scene_Set_Resolution();
        }
        else
        {
            t_Option_Manager.Scene_Set_Resolution(this.gameObject.GetComponent<Camera>());
        }
    }
}
