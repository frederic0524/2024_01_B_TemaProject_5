using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // "GameScene"을 실제 게임 씬의 이름으로 변경하세요
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
