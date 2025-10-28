using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float velocidade = 3f;
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

}
