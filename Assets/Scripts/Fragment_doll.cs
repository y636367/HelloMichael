using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment_doll : MonoBehaviour
{
    [SerializeField]
    private float forceAmount;

    [SerializeField]
    private float Range;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void frags()
    {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, Range, Vector3.up, 0f, LayerMask.GetMask("LagDoll"));
    
        foreach(RaycastHit hit in raycastHits)
        {
            hit.transform.GetComponent<Fragment_doll>().On_Force(transform.position);
        }
    }
    private void On_Force(Vector3 t_frag)
    {
        t_frag=t_frag.normalized;
        t_frag += Vector3.up * 3;
        float P_Power = Random.Range(0.0f, 2.0f);
        rb.AddForce(t_frag * (forceAmount+P_Power), ForceMode.Impulse);
        rb.AddTorque(t_frag * (forceAmount+P_Power), ForceMode.Impulse);
    }
}
