using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSensor : MonoBehaviour
{
    public bool IsPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
            IsPlayer = true;
    }
}
