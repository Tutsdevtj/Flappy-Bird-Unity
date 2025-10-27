using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float velocidade = 8.5f;
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        Mover();

    }


     private void Mover()
     {
        transform.Translate(Vector3.left * (velocidade * Time.deltaTime));

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
 
   

        //private void OnCollisionEnter2D(Collision2D other)
        //{
        //    var obj = other.gameObject.GetComponent<PlayerFlappyBird>();
            
        //    if (obj == null)
        //    {
        //        obj.GameOver();
        //    }
        //}
            
        //Enter: no ato de alguma coisa encostar na outra (pro cano)
        //Stay: no ato de continuar encostando, enquanto tiver colidindo
        //trigger: tipo camera de segurança, entrando no bagulho (pra pontuação no meio de 2 canos)
        //Exit: saindo do bagulho
}
