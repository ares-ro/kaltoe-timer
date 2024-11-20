using System;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public GameObject startDateTimeHUI;
    public GameObject startDateTimeMUI;
    public GameObject endDateTimeHUI;
    public GameObject endDateTimeMUI;

    public GameObject alertCallParent;
    public GameObject alertPrefab;

    void Start()
    {
        ShowNowData();
    }

    public void ConfirmButtonClicked()
    {
        int startDateTimeH = 0;
        int startDateTimeM = 0;
        int endDateTimeH = 0;
        int endDateTimeM = 0;

        bool startDateTimeHBool = int.TryParse(startDateTimeHUI.GetComponent<InputField>().text, out startDateTimeH);
        bool startDateTimeMBool = int.TryParse(startDateTimeMUI.GetComponent<InputField>().text, out startDateTimeM);
        bool endDateTimeHBool = int.TryParse(endDateTimeHUI.GetComponent<InputField>().text, out endDateTimeH);
        bool endDateTimeMBool = int.TryParse(endDateTimeMUI.GetComponent<InputField>().text, out endDateTimeM);

        //파싱 및 범위 체크
        if (startDateTimeHBool == false | 0 <= startDateTimeH == false | startDateTimeH < 24 == false)
        {
            string errorMsg = "시작 시각의 시 단위는 0 이상 24 미만이여야 합니다.";
            GameObject alert = Instantiate(alertPrefab, alertCallParent.transform);
            alert.GetComponent<Alert>().msg = errorMsg;
            return;
        }
        if (startDateTimeMBool == false | 0 <= startDateTimeM == false | startDateTimeM < 60 == false)
        {
            string errorMsg = "시작 시각의 분 단위는 0 이상 60 미만이여야 합니다.";
            GameObject alert = Instantiate(alertPrefab, alertCallParent.transform);
            alert.GetComponent<Alert>().msg = errorMsg;
            return;
        }
        if (endDateTimeHBool == false | 0 <= endDateTimeH == false | endDateTimeH < 24 == false)
        {
            string errorMsg = "종료 시각의 시 단위는 0 이상 24 미만이여야 합니다.";
            GameObject alert = Instantiate(alertPrefab, alertCallParent.transform);
            alert.GetComponent<Alert>().msg = errorMsg;
            return;
        }
        if (endDateTimeMBool == false | 0 <= endDateTimeM == false | endDateTimeM < 60 == false)
        {
            string errorMsg = "종료 시각의 분 단위는 0 이상 60 미만이여야 합니다.";
            GameObject alert = Instantiate(alertPrefab, alertCallParent.transform);
            alert.GetComponent<Alert>().msg = errorMsg;
            return;
        }

        //시각 차이 체크
        DateTime startDateTimeBuffer = new DateTime(1, 1, 1, startDateTimeH, startDateTimeM, 0);
        DateTime endDateTimeBuffer = new DateTime(1, 1, 1, endDateTimeH, endDateTimeM, 0);

        if (startDateTimeBuffer >= endDateTimeBuffer)
        {
            string errorMsg = "시작 시각은 종료 시각보다 빨라야 합니다.";
            GameObject alert = Instantiate(alertPrefab, alertCallParent.transform);
            alert.GetComponent<Alert>().msg = errorMsg;
            return;
        }

        //수정된 값 저장
        DateTimeSettingData.SetDataToPP(startDateTimeH, startDateTimeM, endDateTimeH, endDateTimeM);
        FadeOut();
    }

    public void CancelButtonClicked()
    {
        ShowNowData();
        FadeOut();
    }

    public void ShowSetting()
    {
        FadeIn();
    }

    void FadeIn()
    {
        gameObject.GetComponent<Animation>().Play("settingFadeIn");
    }

    void FadeOut()
    {
        gameObject.GetComponent<Animation>().Play("settingFadeOut");
    }

    void ShowNowData()
    {
        startDateTimeHUI.GetComponent<InputField>().text = DateTimeSettingData.startDateTime.Hour.ToString();
        startDateTimeMUI.GetComponent<InputField>().text = DateTimeSettingData.startDateTime.Minute.ToString();
        endDateTimeHUI.GetComponent<InputField>().text = DateTimeSettingData.endDateTime.Hour.ToString();
        endDateTimeMUI.GetComponent<InputField>().text = DateTimeSettingData.endDateTime.Minute.ToString();
    }
}
