using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyCtrl : MonoBehaviour {

    private ParticleSystem ps;
    private bool isShowEffect = true;
    public float stopTime = 60.0f;

	// Use this for initialization
	void Start () {
        ps = gameObject.GetComponent<ParticleSystem>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.player))
        {
            PlayerCtrl playerCtrl = other.GetComponentInChildren<PlayerCtrl>();
            if (playerCtrl.haveBuff)
            {
                return;
            }
            else
            {
                if (isShowEffect)
                {
                    playerCtrl.GetBuff();
                    isShowEffect = false;
                    ps.Stop();
                    //开启倒计时
                    StartCoroutine(countDown());
                }
            }
        }                
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(stopTime);
        ps.Play();
        isShowEffect = true;
        StopAllCoroutines();        
    }
}
