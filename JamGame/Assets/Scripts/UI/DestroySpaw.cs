using Game.Humanoids;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroySpaw : MonoBehaviour
{
    Humanoid Hu;
    UI_controller ui;
    GameObject Player;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;

    private void Start()
    {
        Hu = GetComponent<Humanoid>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ui = GetComponent<UI_controller>();
        Spawn2.SetActive(false);
        Spawn3.SetActive(false);
        Spawn4.SetActive(false);
        Spawn5.SetActive(false);
        DesativarScripts(Spawn2);
        DesativarScripts(Spawn3);
        DesativarScripts(Spawn4);
        DesativarScripts(Spawn5);
    }

    void Update()
    {
        if (Hu.Level > 3)
        {
            ControlarSpawns();
            enabled = false;
        }
    }

    void ControlarSpawns()
    {
        Destroy(Spawn1);
        Spawn1 = null;

        if (Hu.Level > 5)
        {
            Spawn2.SetActive(true);
            AtivarScripts(Spawn2);
        }

        if (Hu.Level > 7)
        {
            Spawn3.SetActive(true);
            AtivarScripts(Spawn3);
        }

        if (Hu.Level > 9)
        {
            Spawn4.SetActive(true);
            AtivarScripts(Spawn4);
        }

        if (Hu.Level > 10)
        {
            Spawn5.SetActive(true);
            AtivarScripts(Spawn5);
        }
    }

    void DesativarScripts(GameObject spawn)
    {
        Behaviour[] scripts = spawn.GetComponents<Behaviour>();
        foreach (var script in scripts)
        {
            script.enabled = false;
        }
    }

    void AtivarScripts(GameObject spawn)
    {
        Behaviour[] scripts = spawn.GetComponents<Behaviour>();
        foreach (var script in scripts)
        {
            script.enabled = true;
        }
    }
}