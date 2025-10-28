using UnityEngine;
using System;
public class Money : MonoBehaviour
{
public static event Action<int> OnCoinsChanged;

    private const string COINS_KEY = "PlayerCoins";
    public int currentCoins;

    public static Money Instance { get; private set; }

   void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;


        currentCoins = PlayerPrefs.GetInt(COINS_KEY, 0);

        OnCoinsChanged?.Invoke(currentCoins);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        
   
        PlayerPrefs.SetInt(COINS_KEY, currentCoins);
        PlayerPrefs.Save(); 

        OnCoinsChanged?.Invoke(currentCoins);
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
    
    public bool SpendCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            
            PlayerPrefs.SetInt(COINS_KEY, currentCoins);
            PlayerPrefs.Save();
            OnCoinsChanged?.Invoke(currentCoins);
            return true;
        }
        else
        {
            Debug.Log("Moedas insuficientes.");
            return false;
        }
    }
}
