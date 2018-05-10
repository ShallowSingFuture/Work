using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDoorCtrl : MonoBehaviour {

    public GameObject NpcObj;
    public NpcCtrl npcCtrl;
    public PlayerCtrl playerCtrl;
    public CharacterController playerCC;
    public GameObject showDoorCollider;
    public GameObject door;
    public Animation anim;
    public bool isLeft;
    public string currentPointStr = "2-1";

    public void SetDoor()
    {
        door.SetActive(false);
        showDoorCollider.SetActive(true);
        if (isLeft)
        {
            anim.Play("left");
        }
        else
        {
            anim.Play("right");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                //curObject = hit.collider.gameObject;  
                if (hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID() && NpcObj.activeSelf)
                {
                    if (npcCtrl.currentPointStr.Equals(playerCtrl.currentPointStr))
                    {
                        playerCtrl.AddLastPoint(new Vector3(playerCC.transform.position.x, playerCC.transform.position.y, playerCC.transform.position.z));
                        SetDoor();
                        playerCtrl.SetCurrentPoint(currentPointStr);
                    }
                } 
            }

        }
    }
}
