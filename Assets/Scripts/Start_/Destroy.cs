using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}
