using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [Header("Configurações do item")]
    public string itemID;           // Ex: "Classic", "ThePoffo", etc.
    public int price;
    public Sprite birdSprite;
    public TMP_Text buttonText;
    public Button button;

    private bool isOwned;
    private bool isEquipped;

    void Start()
    {
        isOwned = PlayerPrefs.GetInt(itemID + "_Owned", 0) == 1;
        isEquipped = PlayerPrefs.GetString("EquippedItem", "Classic") == itemID;

        // O clássico é sempre possuído
        if (itemID == "Classic")
        {
            isOwned = true;
            PlayerPrefs.SetInt(itemID + "_Owned", 1);
        }

        AtualizarBotao();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        if (!isOwned)
        {
            ComprarItem();
        }
        else if (!isEquipped)
        {
            EquiparItem();
        }
    }

    void ComprarItem()
    {
        if (Money.Instance.SpendCoins(price))
        {
            isOwned = true;
            PlayerPrefs.SetInt(itemID + "_Owned", 1);
            PlayerPrefs.Save();
            EquiparItem();
        }
    }

    void EquiparItem()
{
    PlayerPrefs.SetString("EquippedItem", itemID);
    PlayerPrefs.Save();

    isEquipped = true;

    ShopManagement.Instance.UpdateAllItemsUI();

    Debug.Log($"Skin {itemID} equipada. Será aplicada ao iniciar o jogo.");
}

    public void AtualizarBotao()
    {
        isOwned = PlayerPrefs.GetInt(itemID + "_Owned", 0) == 1;
        isEquipped = PlayerPrefs.GetString("EquippedItem", "Classic") == itemID;

        if (isEquipped)
            buttonText.text = "Equipado";
        else if (isOwned)
            buttonText.text = "Equipar";
        else
            buttonText.text = price + " - Coins";
    }
}
