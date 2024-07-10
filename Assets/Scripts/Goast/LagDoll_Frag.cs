using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagDoll_Frag : MonoBehaviour
{
    [SerializeField]
    private Transform C_Position = null;

    [SerializeField]
    private GameObject fragments = null;

    [SerializeField]
    private GameObject Drop_Hammer = null;

    [SerializeField]
    private GameObject Next_Story_Box = null;

    public bool Check = false;

    S_Zones SZE;
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        Drop_Hammer.SetActive(false);
    }
    public void On_()
    {
        this.gameObject.transform.position = C_Position.position;
        fragments.SetActive(true);
        player.HammerGet = false;
        Invoke("Next_Story", 2.5f);

        Swing_Hammer();
    }
    private void Swing_Hammer()
    {
        Rigidbody rb;
        rb=Drop_Hammer.GetComponent<Rigidbody>();

        Drop_Hammer.SetActive(true);

        rb.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        rb.AddTorque(Vector3.right * 1.5f, ForceMode.Impulse);
    }
    private void Next_Story()
    {
        Next_Story_Box.SetActive(true);
        Check = true;
    }
    public void Next_Story_2()
    {
        SZE=FindObjectOfType<S_Zones>();
        Destroy(fragments);
        player.FragmentGet = true;
        SZE.Story_10();
    }
    
}
