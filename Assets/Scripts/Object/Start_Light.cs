using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Light : MonoBehaviour
{
    float Timing;
    float Count = 0.0f;

    bool Check = false;

    public bool this_time = false;

    Animator anim;

    [SerializeField]
    private string[] Lights;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        Timing = Random.Range(5f, 15f);
        Check = true;
    }
    private void Update()
    {
        if (this_time)
            if (Check)
            {
                if (Timing > Count)
                {
                    Count += Time.deltaTime;
                }
                else
                {
                    Check = false;
                    Count = 0.0f;
                    Timing = Random.Range(5f, 15f);
                    Eyes_Moving();
                }
            }
    }
    private void Eyes_Moving()
    {
        anim.SetTrigger("On");
    }
    public void Chekc_true()
    {
        Check = true;
    }
    #region Lights
    private void Light_One()
    {
        soundManager.Instance.PlaySoundEffect(Lights[0]);
    }
    private void Light_()
    {
        soundManager.Instance.PlaySoundEffect(Lights[0]);
    }
    #endregion
}
