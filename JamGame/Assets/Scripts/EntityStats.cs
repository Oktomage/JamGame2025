using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{

    public float Atack_Damage;
    public float Atack_Speed;
    public float Hp_;
    public float Hp_Max;




    private void Start()
    {
        Hp_ = Hp_Max;
    }



    void Death()
    {
        if(Hp_ <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Death();
    }

}
