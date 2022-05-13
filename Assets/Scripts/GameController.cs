using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Unity_ChanController Unity_Chan;
    public LifePanel lifePanel;

    public void Update(){
        //ライフパネル更新
        lifePanel.UpdateLife(Unity_Chan.Life());
    }
}
