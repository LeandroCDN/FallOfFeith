using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public Text scoreText, chipText, maxScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedIntance.currentGameState == GameState.inGame)
        {
            float score = PlayerMovements.sharedInstance.transform.position.y * -1;
            int chips = GameManager.sharedIntance.collectableChocolats;
            float maxScore = PlayerPrefs.GetFloat("maxscore", 0f);

            scoreText.text = "Score: " + score.ToString("f1");
            maxScoreText.text = "MaxScore: " + maxScore.ToString("f1");
            

            //maxScoreText.text = "MaxScore= " = masScore.toString('f1");
                                
        }
        
    }
}
