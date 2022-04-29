using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ChoicesTest;
    public GameObject LeftButton;
    public GameObject RightButton;

    void Start()
    {
        ChoicesTest.SetActive(false);
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            ChoicesTest.SetActive(true);
            LeftButton.SetActive(true);
            RightButton.SetActive(true);
        }
    }
}
