using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DoorOpening : MonoBehaviour
{
    public Vector3 OpenValue;
    public Vector3 closeDoor;
    public bool NeedRotation;
   public AudioSource sound;
  
    public void OpenDoor()
    {
        if (!NeedRotation)
        {
            this.transform.DOLocalMove(OpenValue, 2f);

        }
        else
        {
            transform.DOLocalRotate(OpenValue, 2f);
        }
        Debug.Log("Opening Door");
       sound.Play();
      //  StartCoroutine(WaitForClose());
    }

    public void CloseDoor()
    {
        this.transform.DOLocalRotate(closeDoor, 2);
    }
    public IEnumerator WaitForClose()
    {
        yield return new WaitForSeconds(3.5f);
        CloseDoor();
    }





}
