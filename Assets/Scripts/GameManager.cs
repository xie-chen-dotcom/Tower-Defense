using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameEndUI gameEndUI;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    public void Fail()
    {
        EnemySpawner.Instance.StopSpawn();
        gameEndUI.Show("ʧ ��");
    }
    public void Win()
    {
        gameEndUI.Show("ʤ ��");

    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }

}