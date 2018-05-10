using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkEffectCtrl : MonoBehaviour {

    private float timer = 0f;
    private float cd = 1.0f;
    private CanvasGroup cG;

    private void Start()
    {
        cG = GetComponentInChildren<CanvasGroup>();
    }

    public void ShowInfo()
    {
        StartCoroutine(countDown());
    }

    IEnumerator countDown()
    {
        yield return new WaitForFixedUpdate();
        timer = timer + Time.deltaTime;
        if (timer >= cd)
        {
            StopAllCoroutines();
        }
        else
        {
            cG.alpha = timer;
            yield return StartCoroutine(countDown());
        }
    }
}
