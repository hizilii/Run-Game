using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public Unity_ChanController Unity_Chan;
    public Text scoreText;
    public Text HighScoreText;
    public LifePanel lifePanel;
    public OnigiriPanel onigiriPanel;

    public void Start(){
        // ハイスコアを表示
        HighScoreText.text="HighScore: " + PlayerPrefs.GetInt("HighScore") + "m";
    }

    public void Update(){
        // スコアを更新
        int score=CalcScore();
        scoreText.text="Score: " + score + "m";

        //ライフパネル更新
        lifePanel.UpdateLife(Unity_Chan.Life());

        //おにぎりパネルを更新
        onigiriPanel.UpdateOnigiri(Unity_Chan.Onigiri());

        // ライフが0になればゲームオーバー
        if(Unity_Chan.Life()<=0){
            enabled=false;

            if(PlayerPrefs.GetInt("HighScore")<score){
                PlayerPrefs.SetInt("HighScore",score);
            }

            Invoke("GameOver",4.0f);
        }
    }

    int CalcScore(){
        // 走行距離をスコアとする
        return (int)Unity_Chan.transform.position.z;
    }

    // ゲームオーバーシーンに切り替え
    void GameOver(){
        SceneManager.LoadScene("GameOverScene_EndlessRun");
    }
}
