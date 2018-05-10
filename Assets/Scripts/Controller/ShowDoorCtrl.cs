using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDoorCtrl : MonoBehaviour
{

    public PlayerCtrl playerCtrl;
    public string currentPointStr = "2-1";

    public List<GameObject> doorList = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.player))
        {
            playerCtrl.SetCurrentPoint(currentPointStr);
            for (int i = 0; i < doorList.Count; i++)
            {
                doorList[i].SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
