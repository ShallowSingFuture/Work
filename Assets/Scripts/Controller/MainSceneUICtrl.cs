using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUICtrl : MonoBehaviour {

    public Button BackBtn;
    public Button caomeiBtn;
    public Text caomeiNum;
    public Text countDownTxt;

    public PlayerCtrl playerCtrl;


	// Use this for initialization
	void Start () {
        BackBtn.onClick.RemoveAllListeners();
        BackBtn.onClick.AddListener(OnClickBackBtn);
        caomeiBtn.onClick.RemoveAllListeners();
        caomeiBtn.onClick.AddListener(OnClickCaomeiBtn);
	}
	
    public void OnClickBackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickCaomeiBtn()
    {
        playerCtrl.RemoveLastPoint();
    }

    public void SetCaomeiNum(int num)
    {
        caomeiNum.text = num.ToString();
    }

    public void SetCountDownTxt(string countDown)
    {
        countDownTxt.text = countDown;
    }
}
