using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafitibugFix : MonoBehaviour
{
    void Start()
    {
        transform.position += transform.forward * 0.0001f; 
    }
}
