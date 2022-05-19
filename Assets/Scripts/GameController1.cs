using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public Unity_ChanController Unity_Chan;
    public LifePanel lifePanel;
    public OnigiriPanel onigiriPanel;

    public void Update(){
        //ライフパネル更新
        lifePanel.UpdateLife(Unity_Chan.Life());

        //おにぎりパネルを更新
        onigiriPanel.UpdateOnigiri(Unity_Chan.Onigiri());

        // ライフが0になればゲームオーバー
        if(Unity_Chan.Life()<=0){
            enabled=false;

            Invoke("GameOver",4.0f);
        }else if(Unity_Chan.transform.position.y<-32.0f){
            enabled=false;

            Invoke("GameOver",0.0f);
        }
    }

    // ゲームオーバーシーンに切り替え
    void GameOver(){
        SceneManager.LoadScene("GameOverScene_Level1");
    }
}
