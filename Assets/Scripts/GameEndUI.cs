using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndUI : MonoBehaviour
    
{
    // Start is called before the first frame update
    public TextMeshProUGUI messageText;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
     
    public void Show(string message)
    {
        messageText.text = message;
        anim.SetTrigger("show");
        
    }
    public void OnRestartButtonClick()
    {
        GameManager.Instance.OnRestart();
    }
    public void OnMenuButtonClick()
    {
        GameManager.Instance.OnMenu();
    }
}
