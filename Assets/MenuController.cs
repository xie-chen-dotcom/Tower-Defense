using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
