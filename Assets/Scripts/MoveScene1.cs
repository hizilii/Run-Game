using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene1 : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Level1Stage");
    }
}

