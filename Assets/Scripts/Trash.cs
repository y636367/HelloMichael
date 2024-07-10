using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Silhouette silhouette;
    Player player;

    S_Zones S_Zones;

    [SerializeField]
    private AudioSource Trash_s;
    [SerializeField]
    private AudioClip trash;
    void Awake()
    {
        silhouette = FindObjectOfType<Silhouette>();
        player=FindObjectOfType<Player>();
        S_Zones=FindObjectOfType<S_Zones>();

        Trash_s=GetComponent<AudioSource>();
        Trash_s.clip = trash;
    }

    public void Trash_()
    {
        Trash_s.PlayOneShot(trash);
        player.DollGet = false;
        ChatController.instance.Clean_List();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        silhouette.On();
        S_Zones.Story_4();
    }
}
