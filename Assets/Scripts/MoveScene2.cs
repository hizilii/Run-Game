using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene2 : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Level2Stage");
    }
}

