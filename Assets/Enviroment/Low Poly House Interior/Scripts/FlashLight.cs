using UnityEngine;

public class FlashLight : MonoBehaviour {

    [SerializeField] private GameObject FlasLight;
    [SerializeField] private KeyCode KeyCode;

    private bool FlashLightActive = false;

    private void Start() {
        FlasLight.gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode)) {
            if (FlashLightActive == false) {
                FlasLight.gameObject.SetActive(true);
                FlashLightActive = true;
            } else {
                FlasLight.gameObject.SetActive(false);
                FlashLightActive = false;
            }
        }
    }
}
