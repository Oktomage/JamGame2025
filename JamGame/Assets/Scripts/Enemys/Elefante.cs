using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elefante : MonoBehaviour
{
    public GameObject Ele;

    private void Start()
    {
        Instantiate( Ele, new Vector3(-7 , Random.Range(-6.5f, -5.5f), 0) ,Quaternion.identity);
    }

}


