using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Script : MonoBehaviour
{
    [Header("Script")]
    [SerializeField]
    private string[] Script;

    [Header("List?")] 
    [SerializeField]
    private string[] list_do;
    [SerializeField]
    private bool list_Check;

    Player player;
    S_Zones SZS;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        SZS=FindObjectOfType<S_Zones>();
    }

    public void Grab_Flash()
    {
        player.Move_Ok = false;
        ChatController.instance.GetScribt(this.Script);
        ChatController.instance.turnOn(this.gameObject, this.list_do, this.list_Check);

        Player.FindObjectOfType<Player>().survive = true;

        SZS.Story_6();

        player.Move_Ok = true;
        this.gameObject.SetActive(false);
    }
}
