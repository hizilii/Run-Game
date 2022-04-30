using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public GameObject[] lifegauge;

    public Unity_ChanController Unity_Chan_generic;

    void Start()
    {
        
    }

    void Update()
    {
        Lifecheck(Unity_Chan_generic.Life());
    }

    public void Lifecheck(int life){
        for(int i=0;i<lifegauge.Length;i++){
            if(i<life){
                lifegauge[i].SetActive(true);
            }else{
                lifegauge[i].SetActive(false);
            }
        }
    }
}
