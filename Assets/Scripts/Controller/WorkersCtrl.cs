using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorkersCtrl : MonoBehaviour {

    public Button BackBtn;
	// Use this for initialization
	void Start () {
        BackBtn.onClick.RemoveAllListeners();
        BackBtn.onClick.AddListener(OnClickBackBtn);
	}

    private void OnClickBackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
