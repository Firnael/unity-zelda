using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyOnComplete : MonoBehaviour {

    ParticleSystem particuleSystem;

    public void Start()
    {
        particuleSystem = GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (particuleSystem)
        {
            if (!particuleSystem.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
