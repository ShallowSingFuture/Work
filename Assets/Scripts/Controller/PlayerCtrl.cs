using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {
    public GameObject player;
    public CharacterController playerCC;
    public Animation anim;
    public float moveSpeed = 1;
    //buff持续时间
    public float stopTime = 60.0f;
    private float timer = 0;
    private float timerSpeed = 1.0f;

    //持有萤火虫buff
    public bool haveBuff = false;
    //持有草莓数量
    public int number;
    //上次对话位置
    private List<Vector3> lastPointList = new List<Vector3>();
    //上次对话位置节点信息
    private List<string> lastPointStr = new List<string>();
    
    //所有门
    public List<GameObject> doorList = new List<GameObject>();

    //萤火虫buff倒计时
    public MainSceneUICtrl mainSceneUICtrl;

    //当前节点
    public string currentPointStr = "1";

    private void Start()
    {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, 90, player.transform.localEulerAngles.z);
            //前
            playerCC.SimpleMove(Vector3.forward * moveSpeed);
            anim.Play("Walk");
        }else if (Input.GetKey(KeyCode.S))
        {
            player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, -90, player.transform.localEulerAngles.z);
            //后
            playerCC.SimpleMove(Vector3.back * moveSpeed);
            anim.Play("Walk");
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, 0, player.transform.localEulerAngles.z);
            //左
            playerCC.SimpleMove(Vector3.left * moveSpeed);
            anim.Play("Walk");
        }else if (Input.GetKey(KeyCode.D))
        {
            player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, 180, player.transform.localEulerAngles.z);
            //右
            playerCC.SimpleMove(Vector3.right * moveSpeed);
            anim.Play("Walk");
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            anim.Play("Stand");
        }
    }

    public void GetBuff()
    {
        haveBuff = true;
        timer = 0;
        StartCoroutine(countDown());
    }

    IEnumerator countDown()
    {
        mainSceneUICtrl.SetCountDownTxt((stopTime - timer).ToString() + "s");
        yield return new WaitForSeconds(timerSpeed);
        timer = timer + timerSpeed;
        if (timer >= stopTime)
        {
            haveBuff = false;
            mainSceneUICtrl.SetCountDownTxt("");
            StopAllCoroutines();
        }
        else
        {
            mainSceneUICtrl.SetCountDownTxt((stopTime - timer).ToString()+"s");
            yield return StartCoroutine(countDown());
        }
    }

    public void SetCurrentPoint(string currentPointStr)
    {
        this.currentPointStr = currentPointStr;
    }

    public void AddLastPoint(Vector3 vec3)
    {
        lastPointList.Add(vec3);
        lastPointStr.Add(currentPointStr);
    }

    public void RemoveLastPoint()
    {
        int index = lastPointList.Count;
        if (index <= 0)
        {
            Debug.Log("已经到达最初位置");
        }else if (number <= 0)
        {
            Debug.Log("没有草莓可以使用");
        }
        else
        {
            number--;
            mainSceneUICtrl.SetCaomeiNum(number);
            for (int i = 0; i < doorList.Count; i++)
            {
                doorList[i].SetActive(true);
            }
            playerCC.transform.position = new Vector3(lastPointList[index - 1].x, lastPointList[index - 1].y, lastPointList[index - 1].z);
            currentPointStr = lastPointStr[index - 1];
            lastPointList.Remove(lastPointList[index - 1]);
            lastPointStr.Remove(lastPointStr[index - 1]);
        }
    }

    public void AddNumber()
    {
        number++;
        mainSceneUICtrl.SetCaomeiNum(number);
    }
}
