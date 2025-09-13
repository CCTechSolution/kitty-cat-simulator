using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGameObjsActive : MonoBehaviour
{
    [SerializeField] GameObject[] allGameObjects;

    public void EnableAll()
    {
        foreach (GameObject obj in allGameObjects)
        {
            obj.SetActive(true);
        }
    }
}
