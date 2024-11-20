using System;
using UnityEngine;

public static class DateTimeSettingData
{
    public static DateTime startDateTime;
    public static DateTime endDateTime;

    public static void Initialize()
    {
        GetDataFromPP();
    }

    public static void GetDataFromPP()
    {
        int startDateTimeH = PlayerPrefs.GetInt("startDateTimeH", 9);
        int startDateTimeM = PlayerPrefs.GetInt("startDateTimeM", 0);
        int endDateTimeH = PlayerPrefs.GetInt("endDateTimeH", 18);
        int endDateTimeM = PlayerPrefs.GetInt("endDateTimeM", 0);

        startDateTime = new DateTime(1, 1, 1, startDateTimeH, startDateTimeM, 0);
        endDateTime = new DateTime(1, 1, 1, endDateTimeH, endDateTimeM, 0);
    }

    public static void SetDataToPP(int startDateTimeH, int startDateTimeM, int endDateTimeH, int endDateTimeM)
    {
        PlayerPrefs.SetInt("startDateTimeH", startDateTimeH);
        PlayerPrefs.SetInt("startDateTimeM", startDateTimeM);
        PlayerPrefs.SetInt("endDateTimeH", endDateTimeH);
        PlayerPrefs.SetInt("endDateTimeM", endDateTimeM);

        startDateTime = new DateTime(1, 1, 1, startDateTimeH, startDateTimeM, 0);
        endDateTime = new DateTime(1, 1, 1, endDateTimeH, endDateTimeM, 0);
    }
}
