using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NpcCtrl : MonoBehaviour {

    public GameObject NpcObj;
    public GameObject NpcTalkObj;
    public GameObject leftDoor;
    public GameObject rightDoor;
    //是否显示
    public bool isShow = false;
    //使NPC显示的对话列表
    public List<TalkData> talkList = new List<TalkData>();
    //触发器
    public GameObject talkCollder;
    //当前显示第N句话
    public int currentIndex = 0;

    //当前NPC所处节点
    public string currentPointStr = "1";

    // Use this for initialization
    void Start () {
        for (int i = 0; i < talkList.Count; i++)
        {
            talkList[i].point.gameObject.SetActive(false);
        }
        NpcObj.SetActive(false);
        NpcTalkObj.SetActive(false);
        currentIndex = 0;
        talkCollder.transform.position = new Vector3(talkList[0].point.transform.position.x, talkList[0].point.transform.position.y, talkList[0].point.transform.position.z);
    }
	
	public void setNextCollder()
    {
        if (currentIndex < talkList.Count)
        {
            NpcObj.SetActive(false);
            NpcTalkObj.SetActive(false);
            talkList[currentIndex].point.gameObject.SetActive(true);
            talkList[currentIndex].point.gameObject.GetComponentInChildren<TalkEffectCtrl>().ShowInfo();
            if (currentIndex < talkList.Count - 1)
            {
                talkCollder.transform.position = new Vector3(talkList[currentIndex + 1].point.transform.position.x, talkList[currentIndex + 1].point.transform.position.y, talkList[currentIndex + 1].point.transform.position.z);
            }else
            {
                talkCollder.SetActive(false);
                NpcObj.SetActive(true);
                NpcTalkObj.SetActive(true);
                NpcTalkObj.GetComponentInChildren<TalkEffectCtrl>().ShowInfo();
            }
            currentIndex++;
        }
    }
    
}

[Serializable]
public class TalkData
{
    public string tolk;
    public Transform point;
}
