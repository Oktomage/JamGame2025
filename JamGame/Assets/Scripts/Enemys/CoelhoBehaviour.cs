using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoelhoBehaviour : MonoBehaviour
   
{
    public float Cooldown_;
    public float Value;

    public float Move;

    private void Update()
    {
        Transporte();
    }

    void Transporte()
    {

        if (Cooldown_ > 0 )
        {
            Cooldown_ -= Time.deltaTime;
        }

        else if ( Cooldown_ <= 0 )
        {

            transform.position = new Vector3(Random.Range(-3f, 3f), 0f, Random.Range(-3, 3) * Move );

            Cooldown_ = Value;

        }

    }

}


