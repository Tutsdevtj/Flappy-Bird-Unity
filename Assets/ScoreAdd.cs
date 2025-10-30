using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreAdd : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Points.scoreValue++;
<<<<<<< Updated upstream
        SoundManager.instance.PlayCoin();
=======
        SoundManager.instance.SoundScoreAdd();
>>>>>>> Stashed changes
    }
    
}
