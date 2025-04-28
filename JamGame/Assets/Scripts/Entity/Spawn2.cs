using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public List<GameObject> objetosParaSpawnar;
    public float intervaloDeSpawn = 2f;
    public float variacaoIntervalo = 1f;
    public Vector2 areaDeSpawnMin;
    public Vector2 areaDeSpawnMax;

    private float tempoProximoSpawn;

    void Start()
    {
        tempoProximoSpawn = Time.time + intervaloDeSpawn;
    }

    void Update()
    {
        if (Time.time >= tempoProximoSpawn)
        {
            SpawnarObjetoAleatorio();
            CalcularProximoSpawn();
        }
    }

    void SpawnarObjetoAleatorio()
    {
        if (objetosParaSpawnar.Count == 0) return;

        int indiceAleatorio = Random.Range(0, objetosParaSpawnar.Count);

        Vector3 posicaoAleatoria = new Vector3(
            Random.Range(areaDeSpawnMin.x, areaDeSpawnMax.x),
            Random.Range(areaDeSpawnMin.y, areaDeSpawnMax.y),
            0
        );

        Instantiate(objetosParaSpawnar[indiceAleatorio], posicaoAleatoria, Quaternion.identity);
    }

    void CalcularProximoSpawn()
    {
        float intervaloAleatorio = intervaloDeSpawn + Random.Range(-variacaoIntervalo, variacaoIntervalo);
        tempoProximoSpawn = Time.time + Mathf.Max(0.1f, intervaloAleatorio);
    }
}


