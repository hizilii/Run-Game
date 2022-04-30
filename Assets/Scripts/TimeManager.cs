using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text CountdownText;
    public Text StartText;
    float countdown=4f;
    int count;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>=0){
            countdown-=Time.deltaTime;
            count=(int)countdown;
            CountdownText.text=count.ToString();
        }
        if(countdown<=0){
            CountdownText.text="";
            StartText.text="";
        }
    }
}
