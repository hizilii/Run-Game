using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene3 : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        FadeManager.Instance.LoadScene("EndlessRun",1.0f);
    }
}

