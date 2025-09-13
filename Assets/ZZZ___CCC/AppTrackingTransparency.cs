#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
using UnityEngine;

public class AppTrackingTransparency : MonoBehaviour
{
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void RequestTrackingAuthorization();
#endif

    void Start()
    {
#if UNITY_IOS && !UNITY_EDITOR
        RequestTrackingAuthorization();
#endif
    }
}