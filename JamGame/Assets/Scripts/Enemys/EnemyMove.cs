using Game.Humanoids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    

    GameObject Arvore_obj;


    Humanoid HU;


    private void Start()
    {
        HU = gameObject.GetComponent<Humanoid>();

        Arvore_obj = GameObject.FindGameObjectWithTag("Arvore");
    }

    void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, Arvore_obj.transform.position, HU.MoveSpeed * Time.deltaTime);
    }


    private void Update()
    {
        moveEnemy();
    }

}
