using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Main : MonoBehaviour
{
    public GameObject dateTimeTimer;
    public GameObject rateBar;
    public GameObject ratePercentValue;
    public GameObject ratePercentValue2;

    public GameObject settingWindowUI;

    void Awake()
    {
        DateTimeSettingData.Initialize();
    }

    void Update()
    {
        DateTime dateTimeNow = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
        TimeSpan sizeOfTime = DateTimeSettingData.endDateTime - DateTimeSettingData.startDateTime;
        TimeSpan remainTime = DateTimeSettingData.endDateTime - dateTimeNow;
        double remainTimeRate = 1 - (remainTime / sizeOfTime);

        if (dateTimeNow < DateTimeSettingData.startDateTime)
        {
            //시작 시각 전
            double remainTimeRateBuffer = 0;

            dateTimeTimer.GetComponent<Text>().text = $"{sizeOfTime.Hours}:{sizeOfTime.Minutes:D2}:{sizeOfTime.Seconds:D2}:{sizeOfTime.Milliseconds:D3}";
            rateBar.GetComponent<Image>().fillAmount = (float)remainTimeRateBuffer;
            ratePercentValue.GetComponent<Text>().text = Math.Floor(remainTimeRateBuffer * 100).ToString() + "%";
            ratePercentValue2.GetComponent<Text>().text = Math.Floor(remainTimeRateBuffer * 100).ToString() + "%";
            return;
        }
        else if (dateTimeNow > DateTimeSettingData.endDateTime)
        {
            //종료 시각 후
            TimeSpan remainTimeBuffer = new();
            double remainTimeRateBuffer = 1;

            dateTimeTimer.GetComponent<Text>().text = $"{remainTimeBuffer.Hours}:{remainTimeBuffer.Minutes:D2}:{remainTimeBuffer.Seconds:D2}:{remainTimeBuffer.Milliseconds:D3}";
            rateBar.GetComponent<Image>().fillAmount = (float)remainTimeRateBuffer;
            ratePercentValue.GetComponent<Text>().text = Math.Floor(remainTimeRateBuffer * 100).ToString() + "%";
            ratePercentValue2.GetComponent<Text>().text = Math.Floor(remainTimeRateBuffer * 100).ToString() + "%";
            return;
        }
        else
        {
            //시각 범위 내
            dateTimeTimer.GetComponent<Text>().text = $"{remainTime.Hours}:{remainTime.Minutes:D2}:{remainTime.Seconds:D2}:{remainTime.Milliseconds:D3}";
            rateBar.GetComponent<Image>().fillAmount = (float)remainTimeRate;
            ratePercentValue.GetComponent<Text>().text = Math.Floor(remainTimeRate * 100).ToString() + "%";
            ratePercentValue2.GetComponent<Text>().text = Math.Floor(remainTimeRate * 100).ToString() + "%";
        }
    }

    public void SettingButtonClicked()
    {
        settingWindowUI.GetComponent<Setting>().ShowSetting();
    }
}
