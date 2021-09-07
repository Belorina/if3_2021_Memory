using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string EasyButton;
    public string NormalButton;

    public void change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGameScene(int level)        // passer le level
    {
        int row, col;
        switch (level)
        {
            case 1:
                row = 2;
                col = 3;
                break;
            case 2:
                row = 3;
                col = 4;
                break;
            default:
                row = 4;
                col = 5;
                break;
        }
        PlayerPrefs.SetInt("row", row);
        PlayerPrefs.SetInt("col", col);

        SceneManager.LoadScene("GameScene");
    }
    
    public void quit()
    {
        Application.Quit();
    }

}

