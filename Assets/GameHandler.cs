using System;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject canoPrefab;
    [SerializeField] private GameObject CanoAnimadoPrefab;

    private float tempoSpawn = 1f;
    private float tempoAtual = 0f;

    [SerializeField] private float spawnMin = -5f;
    [SerializeField] private float spawnMax = 5f;

    [SerializeField] private GameObject projeteisPrefab;
    private GameObject pipe;
    void Start()
    {

    }

    void Update()
    {
        if (Points.scoreValue >= 10)
        {
            tempoSpawn = 2f;
        }
        if (Points.scoreValue >= 20)
        {
            tempoSpawn = 1.5f;
        }
        if (Points.scoreValue >= 40)
        {
            tempoSpawn = 1f;
        }
        if (Points.scoreValue >= 60)
        {
            tempoSpawn = 0.85f;
        }
        if (Points.scoreValue >= 80)
        {
            tempoSpawn = 0.75f;
        }
        if (Points.scoreValue >= 90)
        {
            tempoSpawn = 0.7f;
        }
        if (Points.scoreValue >= 105)
        {
            tempoSpawn = 0.6f;
        }
        SpawnarProjeteisAgrupados();
        if (Points.scoreValue % 2 == 0 && Points.scoreValue != 0)
        {
            SpawnarCanoAnimado();
        }
        else
        {
            SpawnarCano();
            SpawnarProjeteis();
        }

    }


    private void SpawnarCano()
    {
        if (tempoAtual <= 0)
        {
            pipe = Instantiate(canoPrefab);

            pipe.transform.position = new Vector3(8, UnityEngine.Random.Range(spawnMin, spawnMax), 0);

            tempoAtual = tempoSpawn;

        }

        tempoAtual -= Time.deltaTime;
    }

    private void SpawnarCanoAnimado()
    {

        if (tempoAtual <= 0)
        {
            pipe = Instantiate(CanoAnimadoPrefab);

            pipe.transform.position = new Vector3(8, UnityEngine.Random.Range(spawnMin, spawnMax), 0);

            tempoAtual = tempoSpawn;

        }

        tempoAtual -= Time.deltaTime;
    }

    private void SpawnarProjeteis()
    {
        float alturaRandom = UnityEngine.Random.Range(-1.8f, 2.8f);

        if (alturaRandom == 0)
        {
            alturaRandom = 0.7f;
        }
        if (Points.scoreValue >= 20 && tempoAtual <= 0) // se a pontuação for maior ou igual a 2 ele começa a spawnar projéteis
        {
            // Lógica para spawnar projéteis
            var projeteis = Instantiate(projeteisPrefab);

            projeteis.transform.position = new Vector3(8, pipe.transform.position.y + alturaRandom, 0);
        }
    }

    private void SpawnarProjeteisAgrupados()
    {
        if (Points.scoreValue >= 70 && tempoAtual <= 0) // e aq projeteis agrupados
        {
            tempoSpawn = 1.3f;
            for (int i = 0; i <= 6; i++)
            {
                var projeteis = Instantiate(projeteisPrefab);
                projeteis.transform.position = new Vector3(8, pipe.transform.position.y + UnityEngine.Random.Range(-6f, 6f), 0);
            }
        }
    }

}
