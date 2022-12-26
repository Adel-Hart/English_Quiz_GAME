using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{

    public void MoveMenu(int mode)
    {
        if (mode == 1) SceneManager.LoadScene("Menu");
        else SceneManager.LoadScene("StartScreen");
    }


    public void GoLv(int menu)
    {
        SceneManager.LoadScene("Lv"+menu);
    }

    public void backtoexplain_menu()
    {
        SceneManager.LoadScene("Explain");
    }

}
