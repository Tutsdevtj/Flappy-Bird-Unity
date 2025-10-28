using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestText;
    public Image medalImage;
    public Sprite medalBronze;
    public Sprite medalSilver;
    public Sprite medalGold;

    private void OnEnable()
    {
        int current = Mathf.FloorToInt(Points.scoreValue);
        int best = PlayerPrefs.GetInt("BestScore", 0);

        if (scoreText != null)
            scoreText.text = current.ToString();
        if (bestText != null)
            bestText.text = best.ToString();

        if (medalImage != null)
        {
            // garante que a imagem volta a ser visível
            medalImage.enabled = true;

            if (current >= 30)
                medalImage.sprite = medalGold;
            else if (current >= 15)
                medalImage.sprite = medalSilver;
            else if (current >= 5)
                medalImage.sprite = medalBronze;
            else
                medalImage.enabled = false; // oculta se não atingiu pontuação mínima
        }
    }
}
