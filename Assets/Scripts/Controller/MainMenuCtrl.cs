using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour {

    public Button NewGameBtn;
    public Button PauseGameBtn;
    public Button CreditsBtn;
    public Button QuitBtn;

	// Use this for initialization
	void Start () {
        NewGameBtn.onClick.RemoveAllListeners();
        NewGameBtn.onClick.AddListener(OnClickNewGameBtn);
        PauseGameBtn.onClick.RemoveAllListeners();
        PauseGameBtn.onClick.AddListener(OnClickPauseGameBtn);
        CreditsBtn.onClick.RemoveAllListeners();
        CreditsBtn.onClick.AddListener(OnClickCreditsBtn);
        QuitBtn.onClick.RemoveAllListeners();
        QuitBtn.onClick.AddListener(OnClickQuitBtn);
    }
	
    /// <summary>
    /// 跳转至新游戏场景
    /// </summary>
	private void OnClickNewGameBtn()
    {
        //SceneManager.LoadScene("MainScene");
        SceneManager.LoadSceneAsync("MainScene");
    }

    /// <summary>
    /// 继续上次游戏
    /// </summary>
    private void OnClickPauseGameBtn()
    {
        //SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 查看制作人信息
    /// </summary>
    private void OnClickCreditsBtn()
    {
        SceneManager.LoadScene("Workers");
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    private void OnClickQuitBtn()
    {
        Application.Quit();
    }
}
