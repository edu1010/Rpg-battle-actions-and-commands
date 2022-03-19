using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivePlayerControls : MonoBehaviour
{
    [SerializeField]
    GameObject inputs;
    void Update()
    {
        if (EntityManager.ExecutorEntity.GetComponent<IA>() != null)
        {
            inputs.SetActive(false);
        }
        else
        {
            inputs.SetActive(true);
        }
    }
}
