using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlappyButton : MonoBehaviour
{

    public string nextLevel;
    public void OnMouseDown()
    {
        print("clicked");
        SceneManager.LoadScene(nextLevel);
    }
}
