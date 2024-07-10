using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    Player player;

    S_Zones SZE;

    [SerializeField]
    private int num = 0;

    [SerializeField]
    private GameObject Michel = null;

    Hammer hammer;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        SZE=FindObjectOfType<S_Zones>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.Move_Ok)
            {
                if (this.num == 0)
                {
                    SZE.Story_8();
                    Destroy(this.gameObject);
                }
                else if(this.num == 1)
                {
                    Michel.GetComponent<SphereCollider>().enabled = true;

                    hammer=FindObjectOfType<Hammer>();
                    hammer.Grab_On();

                    Destroy(this.gameObject);
                }
            }
        }
    }
}
