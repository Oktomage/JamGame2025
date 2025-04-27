using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{


    public float Move_Speed;

    GameObject Arvore_obj;


    private void Start()
    {
        Arvore_obj = GameObject.FindGameObjectWithTag("Arvore");
    }

    void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, Arvore_obj.transform.position, Move_Speed * Time.deltaTime);
    }


    private void Update()
    {
        moveEnemy();
    }

}
