using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirEfecto : MonoBehaviour
{
    private float tiempo = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo - Time.deltaTime;
        if (tiempo <= 0)
        {
            Destroy(gameObject);
        }
    }
}
