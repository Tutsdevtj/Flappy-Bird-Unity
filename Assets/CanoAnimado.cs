using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class CanoAnimado : MonoBehaviour
{
    float velocidade = 8f;
    void Start()
    {
       
    }
    
    void Update()
    {
        MoverCanoAnimado();

    }


     private void MoverCanoAnimado()
     {
        transform.Translate(Vector3.left * (velocidade * Time.deltaTime));

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
            
        //Enter: no ato de alguma coisa encostar na outra (pro cano)
        //Stay: no ato de continuar encostando, enquanto tiver colidindo
        //trigger: tipo camera de segurança, entrando no bagulho (pra pontuação no meio de 2 canos)
        //Exit: saindo do bagulho
   
}
