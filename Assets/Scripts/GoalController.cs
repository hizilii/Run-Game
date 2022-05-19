using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public GameObject GoalSignText;
    void Start()
    {
        GoalSignText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag=="Player"){
            GoalSignText.SetActive(true);
        }
    }
}
