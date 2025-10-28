using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class CoinTextUI : MonoBehaviour
{
    private TMP_Text coinText;

    void Awake()
    {
        coinText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        Money.OnCoinsChanged += UpdateText;


        if (Money.Instance != null)
        {
            UpdateText(Money.Instance.currentCoins);
        }
    }

    void OnDisable()
    {
        Money.OnCoinsChanged -= UpdateText;
    }

    private void UpdateText(int newTotal)
    {
        coinText.text = newTotal.ToString();
    }
}