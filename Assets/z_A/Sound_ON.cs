using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_ON : MonoBehaviour
{
    public GameObject sound;
    private void OnEnable()
    {
        Invoke(nameof(ON_CLIP), 2f);
    }
    void ON_CLIP()
    {
        sound.SetActive(true);
    }
}
