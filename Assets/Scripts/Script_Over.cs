using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Over : MonoBehaviour
{
    [SerializeField]
    int num = 0;

    bool Change = false;
    S_Zones SZS = null;

    void Awake()
    {
        SZS=FindObjectOfType<S_Zones>();
    }
    void Update()
    {
        if (num == 2)
        {
            SZS.Story_8();
            GameManager.Instance.TimeOn = true;
            GameManager.Instance.Survive_Succes = false;
        }

        if (this.gameObject.activeSelf == false)
        {
            if (!Change)
            {
                Change = true;
                num += 1;
            }
        }
        else
        {
            if (Change)
            {
                Change = false;
            }
        }
    }
}
