using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void ReplayClick()
    {
        Time.timeScale = 1;
        foreach(var r in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(r);
        }
        SceneManager.LoadScene(0);
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
