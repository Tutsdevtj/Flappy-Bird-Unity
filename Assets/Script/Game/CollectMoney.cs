using TMPro;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Money.Instance.AddCoins(1);
        Destroy(gameObject);
    }

}
