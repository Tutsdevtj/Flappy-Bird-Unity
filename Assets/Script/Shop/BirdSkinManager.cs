using UnityEngine;

public class BirdSkinManager : MonoBehaviour
{
    public static BirdSkinManager Instance;
    private SpriteRenderer sr;

    [Header("Sprite padrão (Classic)")]
    public Sprite defaultSprite;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        sr = GetComponent<SpriteRenderer>();

        // Carregar a skin salva quando a cena começa
        string equippedID = PlayerPrefs.GetString("EquippedItem", "Classic");
        ApplySkin(equippedID);
    }

    public void ApplySkin(string itemID)
    {
        if (itemID == "Classic")
        {
            sr.sprite = defaultSprite;
        }
        else
        {
            Sprite loadedSprite = Resources.Load<Sprite>("Birds/" + itemID);
            if (loadedSprite != null)
                sr.sprite = loadedSprite;
        }
    }
}
