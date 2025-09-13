using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Analytics;

public class Stunts_CarSelection : MonoBehaviour
{
    //public Game_Reward gr;
    public bool Puzzel;
    public int coin;
    public GameObject CarsBuy;
    public GameObject[] Cars_Model;
    public int[] prices;
    int c_no = 0;
    public GameObject Selectbtn, PurchasedText, LowCashText, LockImage;
    private int ModleNum;
    public Text cash, CashRequired;
    public GameObject Firework;
    [Header("Try This")]
    public bool Get_2x;
    public GameObject Get2X_B;
    public GameObject Get2X_T;

    [Header("Reward")]
    public GameObject Reward;

    void OnEnable()
    {
        gr_u();

        if (Puzzel == true)
        {
            PlayerPrefs.SetInt("CurrentPuzzelCar", 0);
            c_no = PlayerPrefs.GetInt("CurrentPuzzelCar");
        }
        else
        {
            PlayerPrefs.SetInt("CurrentStuntCar", 0);
            c_no = PlayerPrefs.GetInt("CurrentStuntCar");
        }
        Cars_Model[c_no].SetActive(true);
        CarCheck();
        Coins();
    }
    void gr_u()
    {
        //gr = Game_Reward.gr;
        //Reward = gr.Reward_UnLock;
    }
    void Coins()
    {
        coin = PlayerPrefs.GetInt("TotalCoins");
        cash.text = ("$ " + coin).ToString();
        Invoke("Coins", 1f);
    }
    public void Get_Coins()
    {
        AD_LS();
    }
    void AD_LS()
    {
        load_rew();
        //Reward.SetActive(true);
        Invoke("waitAD_now", 0.1f);
    }
    void waitAD_now()
    {
        show_rew();
        off_R();
    }
    void off_R()
    {
        //Reward.SetActive(false);
    }
    void Chk_Coins()
    {
        abcd = abcd + 1;
        if (abcd == 2)
        {
            abcd = 0;
        }
        AdmobAdsManager.Instance.Btn_Reward_Done("You Have Got Successfully Coins.");
        coin = coin + coin;
        PlayerPrefs.SetInt("TotalCoins", coin);
        coin = PlayerPrefs.GetInt("TotalCoins");
        cash.text = ("$ " + coin);
        off_R();
    }
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("Reward") == 0)
        {
            PlayerPrefs.SetInt("Reward", 1);
        }
    }
    public void Try_This_Now()
    {
        Cars_Selected();
    }
    public void Cars_Selected()
    {
        if (Puzzel == true)
        {
            PlayerPrefs.SetInt("CurrentPuzzelCar", c_no);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentStuntCar", c_no);
        }


    }
    public void NextModleBtn()
    {
        Cars_Model[c_no].SetActive(false);
        c_no++;
        if (c_no > Cars_Model.Length - 1)
        {
            c_no = 0;
        }
        Cars_Model[c_no].SetActive(true);
        CarCheck();
    }
    public void PreviousModleBtn()
    {
        Cars_Model[c_no].SetActive(false);
        c_no--;
        if (c_no < 0)
        {
            c_no = Cars_Model.Length - 1;
        }
        Cars_Model[c_no].SetActive(true);
        CarCheck();
    }
    void Btn_Buy(bool xXx)
    {
        if (xXx == false)
        {
            CarsBuy.SetActive(false);
            if (Get_2x == true)
            {
                // Get2X_B.SetActive(false);
                Get2X_T.SetActive(false);
            }
        }
        else
        {
            CarsBuy.SetActive(true);
            if (Get_2x == true)
            {
                //  Get2X_B.SetActive(true);
                Get2X_T.SetActive(true);
            }
        }
    }
    public void CarCheck()
    {
        CashRequired.text = ("$ " + prices[c_no]).ToString();
        if (Puzzel == true)
        {
            if (c_no == 1 && PlayerPrefs.GetInt("PuzzelCar1") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 2 && PlayerPrefs.GetInt("PuzzelCar2") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 3 && PlayerPrefs.GetInt("PuzzelCar3") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 4 && PlayerPrefs.GetInt("PuzzelCar4") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 5 && PlayerPrefs.GetInt("PuzzelCar5") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else
            {
                Btn_Buy(false);
                Selectbtn.SetActive(true);
                LockImage.SetActive(false);
                CashRequired.text = ("0");
            }
        }
        else
        {
            if (c_no == 1 && PlayerPrefs.GetInt("StuntCar1") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 2 && PlayerPrefs.GetInt("StuntCar2") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 3 && PlayerPrefs.GetInt("StuntCar3") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 4 && PlayerPrefs.GetInt("StuntCar4") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else if (c_no == 5 && PlayerPrefs.GetInt("StuntCar5") == 0)
            {
                Btn_Buy(true);
                Selectbtn.SetActive(false);
                LockImage.SetActive(true);
            }
            else
            {
                Btn_Buy(false);
                Selectbtn.SetActive(true);
                LockImage.SetActive(false);
                CashRequired.text = ("0");
            }
        }
    }
    public void buy_Cars()
    {
        if (PlayerPrefs.GetInt("TotalCoins") >= prices[c_no])
        {
            FW_on();

            PlayerPrefs.SetInt("TotalCoins", coin - prices[c_no]);
            coin = PlayerPrefs.GetInt("TotalCoins");
            cash.text = ("$ " + coin).ToString();

            if (Puzzel == true)
            {
                if (c_no == 1)
                {
                    PlayerPrefs.SetInt("PuzzelCar1", 1);
                }
                else if (c_no == 2)
                {
                    PlayerPrefs.SetInt("PuzzelCar2", 1);
                }
                else if (c_no == 3)
                {
                    PlayerPrefs.SetInt("PuzzelCar3", 1);
                }
                else if (c_no == 4)
                {
                    PlayerPrefs.SetInt("PuzzelCar4", 1);
                }
                else if (c_no == 5)
                {
                    PlayerPrefs.SetInt("PuzzelCar5", 1);
                }
            }
            else
            {
                if (c_no == 1)
                {
                    PlayerPrefs.SetInt("StuntCar1", 1);
                }
                else if (c_no == 2)
                {
                    PlayerPrefs.SetInt("StuntCar2", 1);
                }
                else if (c_no == 3)
                {
                    PlayerPrefs.SetInt("StuntCar3", 1);
                }
                else if (c_no == 4)
                {
                    PlayerPrefs.SetInt("StuntCar4", 1);
                }
                else if (c_no == 5)
                {
                    PlayerPrefs.SetInt("StuntCar5", 1);
                }
            }
            CarCheck();
        }
        else
        {
            LowCashText.SetActive(true);
            Invoke("textoff", 3f);
        }
    }
    private void textoff()
    {
        LowCashText.SetActive(false);
    }
    public void FW_on()
    {
        Firework.SetActive(true);
        Invoke("FW_off", 2.5f);
    }
    public void FW_off()
    {
        Firework.SetActive(false);
    }
    static int abcd;
    int number;
    void load_rew()
    {
        if (abcd == 0)
        {
            // ADsMax
        }
        else
        {
            if (AdmobAdsManager.Instance._Name == true)
            {
                // ADsMax
            }
            else
            {
                //Unity_Ads_Manager.Instance.Btn_Rew_Load();
            }
        }
    }
    void show_rew()
    {
        //if (abcd == 0)
        //{
        //    MaxAdsManager.Instance.Btn_LS_Rew(Chk_Coins);
        //}
        //else
        //{
        //    if (AdmobAdsManager.Instance._Name == true)
        //    {
        //        MaxAdsManager.Instance.Btn_LS_Rew(Chk_Coins);
        //    }
        //    else
        //    {
        //        Unity_Ads_Manager.Instance.Btn_Rew_Show();
        //        Chk_Coins();
        //    }
        //}
    }
}
