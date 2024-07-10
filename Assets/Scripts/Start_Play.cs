using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Play : MonoBehaviour
{
    [SerializeField]
    private GameObject Obj=null;

    [SerializeField]
    private GameObject Zone = null;

    [SerializeField]
    private GameObject Bella = null;

    [SerializeField]
    private GameObject Cam_Surprise = null;

    [SerializeField]
    private int num;

    S_Zones SZ;
    Start_Play SP;
    Surprise surprise;
    Surprise_Cam SPCam;
    void Awake()
    {
        SZ=FindObjectOfType<S_Zones>();
        SP = this;
    }
    public void DIsapear()
    {
        Destroy(SP.Bella);
        SZ.Story_7();

        Invoke("Dis_Doll", 0.5f);
    }
    public void Disapear_2()
    {
        Invoke("Dis_Doll", 0.5f);
    }
    public void WaitSceond()
    {
        SP.GetComponent<BoxCollider>().enabled = false;
        surprise=SP.Obj.GetComponent<Surprise>();
        surprise.Whoa(SP);
        SPCam=Cam_Surprise.GetComponent<Surprise_Cam>();
        SPCam.Whoa();

        if (SP.num == 0)
            DIsapear();
        else if (SP.num == 1)
            Disapear_2();
    }
    public void StP(RaycastHit t_SP)
    {
        SP = t_SP.collider.GetComponent<Start_Play>();
    }
    public void Dis_Doll()
    {
        SP.Zone.SetActive(true);
    }
    public void Destory_obj()
    {
        SP.GetComponent<BoxCollider>().enabled = true;
        SP.gameObject.SetActive(false);
    }
}
