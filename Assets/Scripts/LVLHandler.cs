using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLHandler : MonoBehaviour
{
    public void SceneScanger(int lvlID) {
        SceneManager.LoadScene(lvlID);
    }

    public void EndGame() {
        Application.Quit();
    }
}
