using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaomeiCtrl : MonoBehaviour {

    public PlayerCtrl playerCtrl;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.player))
        {
            playerCtrl.AddNumber();
            gameObject.SetActive(false);
        }
    }
}
