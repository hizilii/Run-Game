using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene6 : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag=="Player"){
            FadeManager.Instance.LoadScene("GameClearScene",1.0f);
        }
    }
}

