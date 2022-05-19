using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene1 : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
       FadeManager.Instance.LoadScene("Level1Stage",1.0f);
    }
}

