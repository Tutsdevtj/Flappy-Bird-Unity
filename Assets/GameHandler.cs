    using System;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;

    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private GameObject canoPrefab;

        [SerializeField] private float tempoSpawn = 1.3f;
        private float tempoAtual = 0f;

        [SerializeField] private float spawnMin = -5f;
    [SerializeField] private float spawnMax = 5f;
        
        [SerializeField] private GameObject projeteisPrefab;
        private Bullet bullet;
        private GameObject pipe;
    void Start()
        {
        
        }

        void Update()
    {
        if (Points.scoreValue >= 20)
        {
            tempoSpawn = 1f;
        }
        if (Points.scoreValue >= 40)
        {
            tempoSpawn = 0.95f;
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
        SpawnarCano();
        SpawnarProjeteis();
        SpawnarProjeteisAgrupados();
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

    private void SpawnarProjeteis()
    {
        float alturaRandom = UnityEngine.Random.Range(-1.5f, 2.8f);

                if(alturaRandom == 0)
                {
                    alturaRandom = 0.7f;
                }
        if (Points.scoreValue >= 2 && tempoAtual <= 0) // se a pontuação for maior ou igual a 2 ele começa a spawnar projéteis
        {
            // Lógica para spawnar projéteis
            var projeteis = Instantiate(projeteisPrefab);

            projeteis.transform.position = new Vector3(8, pipe.transform.position.y + alturaRandom, 0);
        }
    }
     
     private void SpawnarProjeteisAgrupados()
    {


        if (Points.scoreValue >= 15 && tempoAtual <= 0) // e aq projeteis agrupados
        {   
            tempoSpawn = 1.3f;
            // Lógica para spawnar projéteis agrupados
            for (int i = 0; i <= 4; i++)
            {
                var projeteis = Instantiate(projeteisPrefab);
                float alturaRandom = UnityEngine.Random.Range(-5f, 5f);
                float velocidadeRandom = UnityEngine.Random.Range(7f, 10f);
                if (i % 2 == 0)
                {
                    bullet.velocidade = velocidadeRandom;
                    projeteis.transform.position = new Vector3(8, pipe.transform.position.y + alturaRandom, 0);
                }
                else
                    projeteis.transform.position = new Vector3(8, UnityEngine.Random.Range(-3, 4), 0);
            }
        }
    }

}
