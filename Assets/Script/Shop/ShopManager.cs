using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    public static ShopManagement Instance;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateAllItemsUI()
    {
        foreach (ShopItem item in FindObjectsOfType<ShopItem>())
        {
            item.AtualizarBotao();
        }
    }
}
