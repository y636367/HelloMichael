using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    private GameObject G_Hammer = null;

    [SerializeField]
    private GameObject G_Michel = null;

    [SerializeField]
    private GameObject Soon_B_M = null;

    [SerializeField]
    private GameObject Next_to_do = null;

    Player player;

    private void Awake()
    {
        player=FindObjectOfType<Player>();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void Grab_Hammer()
    {
        Next_to_do.SetActive(true);
        Soon_B_M.SetActive(true);
        player.HammerGet = true;

        G_Michel.SetActive(false);
        this.gameObject.SetActive(false);
    }
    public void Grab_On()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
