using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayerController rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void ProgramExit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
    
    //public void Death()
    //{
    //    Time.timeScale = 0;
    //    DeathMenu.SetActive(true);
    //}


}
