using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagDoll_Un : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float forceAmount;

    LagDoll_M LM;
    public void this_Damage(RaycastHit t_hit)
    {
        rb = t_hit.transform.GetComponent<Rigidbody>();

        float P_power = Random.Range(0.0f, 0.5f);

        rb.AddForce(this.transform.position * (forceAmount + P_power), ForceMode.Impulse);
        rb.AddTorque(this.transform.position * (forceAmount + P_power), ForceMode.Impulse);

        LM=FindObjectOfType<LagDoll_M>();
        LM.On_Damage();
    }
}
