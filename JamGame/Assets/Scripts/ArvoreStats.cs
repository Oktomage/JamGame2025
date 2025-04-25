using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoreStats : MonoBehaviour
{
    public float Arvore_HP;
    
    void Death()
    {
        if(Arvore_HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Death();
    }

}
