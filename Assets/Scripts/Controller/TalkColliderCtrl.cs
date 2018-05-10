using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkColliderCtrl : MonoBehaviour {
    public NpcCtrl npcCtrl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.player))
        {
            if (other.gameObject.GetComponentInChildren<PlayerCtrl>().haveBuff)
                npcCtrl.setNextCollder();
            else
                return;
        }
    }
}
