using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHandling : MonoBehaviour
{
    public static HealthHandling instance;
    public GameObject AdPanel;
    public GameObject RevivePanel;
    public Image HealthImg;
    public Image HealthBar;
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject GetHealthBtn;
    public Text HealthText;

    public float decreaseSpeed = 0.6f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = 100f;
    }
    private void Update()
    {

            if (GamePlayHandler.instance.UsingHealth == true)
            {
                DecreaseFuel(Time.deltaTime * decreaseSpeed);
                float fuelPercentage = (currentHealth / maxHealth) * 100f;
                HealthText.text = Mathf.RoundToInt(fuelPercentage) + "%";

                if (currentHealth > 30)
                {
                    GetHealthBtn.SetActive(false);
                }
                if (currentHealth <= 30f)
                {
                    GetHealthBtn.SetActive(true);
                }
                if (currentHealth <= 0f)
                {
                    RevivePanel.SetActive(true);
                    GetHealthBtn.SetActive(false);

                }
            }
    }
    void DecreaseFuel(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        float fillAmount = currentHealth / maxHealth;
        HealthBar.fillAmount = fillAmount;
    }

    public IEnumerator ActiveAdPanel()
    {
        yield return new WaitForSeconds(15);
        AdPanel.SetActive(true);
    }
    public void OnClickCross()
    {
        UIManager.instance.Ad.SetActive(true);
        AdPanel.SetActive(false);


    }
    public void OnClickGetHealthBtn()
    {
        AdPanel.SetActive(true);
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene("Loading");
    }
}
