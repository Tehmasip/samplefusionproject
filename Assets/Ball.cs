using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Ball : NetworkBehaviour
{
    public void Init(Vector3 forward)
    {
        GetComponent<Rigidbody>().velocity = forward*100;
    }
}
