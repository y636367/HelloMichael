using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame_Scripts : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private string[] Script;

    ChatController CC;
    Player player;

    [Header("Sounds")]
    [SerializeField]
    private string Sound;
    void Awake()
    {
        CC = FindObjectOfType<ChatController>();
        player = FindObjectOfType<Player>();
    }
    public void Scripts()
    {
        CC.Get_player(player);
        player.Move_Ok = false;
        player.Now_Chat = true;
        CC.GetScribt(this.Script);
        CC.turnOn(this.gameObject);
        soundManager.Instance.PlaySoundEffect(Sound);
    }
}
