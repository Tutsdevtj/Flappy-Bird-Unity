using UnityEngine;

// Esta estrutura permite associar um ID (string) a um Sprite no Inspector
[System.Serializable]
public struct SkinMapping
{
    public string itemID; // Deve ser EXATAMENTE igual ao itemID no ShopItem
    public Sprite skinSprite;
}

[RequireComponent(typeof(SpriteRenderer))]
public class BirdSkinManager : MonoBehaviour
{
    // Arraste seus sprites aqui E configure os IDs
    public SkinMapping[] possibleSkins; 
    
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        LoadSkin();
    }

    void LoadSkin()
    {
        // 1. Pega o ID salvo pelo ShopItem.cs (Ex: "Classic" ou "ThePoffo")
        // O valor padrão "Classic" garante que algo seja carregado
        string equippedSkinID = PlayerPrefs.GetString("EquippedItem", "Classic");

        // 2. Encontra o Sprite correspondente a esse ID
        Sprite spriteToEquip = null;
        foreach (var skin in possibleSkins)
        {
            if (skin.itemID == equippedSkinID)
            {
                spriteToEquip = skin.skinSprite;
                break; // Para o loop assim que encontrar
            }
        }

        // 3. Aplica o Sprite
        if (spriteToEquip != null)
        {
            spriteRenderer.sprite = spriteToEquip;
        }
        else
        {
            // Se o ID salvo não for encontrado no array (ex: "Classic" não foi configurado)
            Debug.LogWarning($"Skin ID '{equippedSkinID}' não encontrada em BirdSkinManager!");
            
            // Tenta usar a primeira skin da lista como fallback
            if (possibleSkins.Length > 0)
            {
                spriteRenderer.sprite = possibleSkins[0].skinSprite;
            }
        }
    }
}