using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    // Start is called before the first frame update
    public void UpdateScoreDisplay(int _score){
        scoreText.text = _score.ToString();
	}

    public void UpdateHighScoreDisplay(int _score){
        highScoreText.text = _score.ToString();
	}
}
