using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEffectManager : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject,GetComponent<ParticleSystem>().main.duration);
    }
}
