using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public List<GameObject> Level1_Formiga;
    public float Cooldown_;
    public float Value_Cooldown;



    private void Update()
    {
        Cooldow();
    }
    private void Start()
    {
       
           }

    void Cooldow()
    {
        if (Cooldown_ > 0)
        {
            Cooldown_ -= Time.deltaTime;
        }

        else if (Cooldown_ <= 0 )
        {

            Instantiate(Level1_Formiga[Random.Range(-0, Level1_Formiga.Count)], new Vector3(-9, Random.Range(1.2f, -12f), 0), Quaternion.identity);
            Instantiate(Level1_Formiga[Random.Range(0, Level1_Formiga.Count)], new Vector3(9, Random.Range(-12f, 1.2f), 0), Quaternion.identity);
            Cooldown_ = Value_Cooldown;
        }



    }


}
