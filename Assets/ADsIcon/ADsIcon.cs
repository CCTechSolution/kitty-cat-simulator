using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ADsIcon : MonoBehaviour
{
    public string Link;
    public int mini;
    public int maxi;
    public int Current;
    public int next;
    public Sprite[] Image;
    public float tiMe = 4f;

    void OnEnable()
    {
        maxi = Image.Length;
        chanGe();
    }
    void OnDisable()
    {

    }
    void chanGe()
    {
        Current = next;
        this.GetComponent<Image>().sprite = Image[Current];
        next = next + 1;
        if (next == maxi)
        {
            next = 0;
        }
        Invoke("chanGe", tiMe);
    }
    public void Btn_myCall()
    {
        Application.OpenURL(Link);
    }
}