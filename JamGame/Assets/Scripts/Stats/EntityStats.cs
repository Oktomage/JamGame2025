using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EntityStats : MonoBehaviour
{

    public float Atack_Damage;
    public float Atack_Speed;
    public float Hp_;
    public float Hp_Max;


    public float move_cabrito;

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
