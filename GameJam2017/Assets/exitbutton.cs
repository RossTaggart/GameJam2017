using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitbutton : MonoBehaviour {

    public void exitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
