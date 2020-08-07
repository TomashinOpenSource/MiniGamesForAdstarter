using System;
using System.Collections.Generic;
using UnityEngine;

public class OneSignalNotifications : MonoBehaviour
{
    public string OneSignalAppID;
    void Start()
    {
        // Uncomment this method to enable OneSignal Debugging log output 
        // OneSignal.SetLogLevel(OneSignal.LOG_LEVEL.INFO, OneSignal.LOG_LEVEL.INFO);

        OneSignal.StartInit(OneSignalAppID)
            .HandleNotificationOpened(HandleNotificationOpened)
            .Settings(new Dictionary<string, bool>() {
                { OneSignal.kOSSettingsAutoPrompt, false },
                { OneSignal.kOSSettingsInAppLaunchURL, false } })
            .EndInit();

        OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;

        // The promptForPushNotifications function code will show the iOS push notification prompt. We recommend removing the following code and instead using an In-App Message to prompt for notification permission.
        OneSignal.PromptForPushNotificationsWithUserResponse(OneSignal_promptForPushNotificationsResponse);
    }

    private void OneSignal_promptForPushNotificationsResponse(bool accepted)
    {
        Debug.Log("OneSignal_promptForPushNotificationsResponse: " + accepted);
    }

    private static void HandleNotificationOpened(OSNotificationOpenedResult result)
    {

    }
}
