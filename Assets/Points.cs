using System;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    float velocidade = 5f;

    public TMP_Text scoreText;

    public static float scoreValue;

    private void Start()
    {
        scoreText.text = scoreValue.ToString();
    }

    void Update()
    {
        Mover();
        scoreText.text = scoreValue.ToString();

    }


   private void Mover()
    {
        transform.Translate(Vector3.left * (velocidade * Time.deltaTime));
    } 


    //Enter: no ato de alguma coisa encostar na outra (pro cano)
    //Stay: no ato de continuar encostando, enquanto tiver colidindo
    //trigger: tipo camera de seguran�a, entrando no bagulho (pra pontua��o no meio de 2 canos)
    //Exit: saindo do bagulho

}
