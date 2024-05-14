using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LegacyScript : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI lifetimeScoreText;
    // Start is called before the first frame update
    void Start()
    {   
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
            PlayerPrefs.SetInt("lifetimeScore", 0);
        }
        int highScore = PlayerPrefs.GetInt("highScore");
        int lifetimeScore = PlayerPrefs.GetInt("lifetimeScore");
        highScoreText.text = "High Score: " + highScore.ToString();
        lifetimeScoreText.text = "Lifetime Points: " + lifetimeScore.ToString();
    }

}
