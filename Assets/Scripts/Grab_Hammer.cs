using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Hammer : MonoBehaviour
{
    Animator animator;

    Player player;
    LagDoll_Un lag_un;

    [SerializeField]
    private KeyCode KeyCodeSwing;

    RaycastHit hit;

    [Header("Sounds")]
    [SerializeField]
    private string Hammer_Swing;
    [SerializeField]
    private string Thumb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        player=FindObjectOfType<Player>();

        KeyCodeSwing = KeySetting.keys[(KeyAction)9];
    }
    private void Update()
    {
        if (player.HammerGet)
        {
            if (!GameManager.Instance.Option_)
            {
                if (Input.GetKeyDown(KeyCodeSwing))
                {
                    Swing_Hammer_();
                }
            }
        }
    }
    private void Swing_Hammer_()
    {

        animator.SetTrigger("On");

    }

    private void Hit_Hammer()
    {
        if (player.See_Michel)
        {
            soundManager.Instance.PlaySoundEffect(Thumb);
            lag_un=hit.transform.GetComponent<LagDoll_Un>();
            lag_un.this_Damage(hit);
        }
    }
    public void fragment(RaycastHit t_f)
    {
        hit = t_f;
    }
    public void Set_Key()
    {
        KeyCodeSwing = KeySetting.keys[(KeyAction)9];
    }
    private void Hammer_Swing_Sound()
    {
        soundManager.Instance.PlaySoundEffect(Hammer_Swing);
    }
}
