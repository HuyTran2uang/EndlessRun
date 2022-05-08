using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSensor : MonoBehaviour
{
    public bool CheckPlayerExit;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            CheckPlayerExit = true;
        }
    }
}
