using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Box_Audio : MonoBehaviour
{
    [SerializeField]
    private string Sound;

    public void Sound_On()
    {
        soundManager.Instance.PlaySoundEffect(Sound);
    }
}
