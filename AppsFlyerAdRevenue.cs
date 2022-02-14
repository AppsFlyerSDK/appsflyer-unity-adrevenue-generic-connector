using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

namespace AppsFlyerSDK
{
    public class AppsFlyerAdRevenue : MonoBehaviour
    {

        public static readonly string kAppsFlyerAdRevenueVersion = "6.5.3";

#if UNITY_ANDROID && !UNITY_EDITOR
        private static AndroidJavaClass appsFlyerAndroid = new AndroidJavaClass("com.appsflyer.unity.afunityadrevenuegenericplugin.AdRevenueUnityWrapper");
#endif

        public static void start()
        {
#if UNITY_IOS && !UNITY_EDITOR

        _start();

#elif UNITY_ANDROID && !UNITY_EDITOR

            using(AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {

                using(AndroidJavaObject cls_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity")) {

                    AndroidJavaObject cls_Application = cls_Activity.Call<AndroidJavaObject>("getApplication");

                                appsFlyerAndroid.CallStatic("start", cls_Application);
                }
            } 

#else

#endif
        }


        public static void setIsDebug(bool isDebug)
        {
#if UNITY_IOS && !UNITY_EDITOR
        _setIsDebugAdrevenue(isDebug);
#elif UNITY_ANDROID && !UNITY_EDITOR

#else

#endif
        }

        public static void logAdRevenue(string monetizationNetwork,
            AppsFlyerAdRevenueMediationNetworkType mediationNetwork,
            double eventRevenue,
            string revenueCurrency,
            Dictionary<string, string> additionalParameters)
        {
#if UNITY_IOS && !UNITY_EDITOR

        _logAdRevenue(monetizationNetwork, mediationNetwork, eventRevenue, revenueCurrency, AFMiniJSON.Json.Serialize(additionalParameters));

#elif UNITY_ANDROID && !UNITY_EDITOR

            int mediationNetworkAndroid = setMediationNetworkTypeAndroid(mediationNetwork);
            if (mediationNetworkAndroid == -1)
            {
                Debug.Log("Please choose a valid mediationNetwork");
            } else
            {
                appsFlyerAndroid.CallStatic("logAdRevenue",
                                            monetizationNetwork,
                                            mediationNetworkAndroid,
                                            revenueCurrency,
                                            eventRevenue,
                                            convertDictionaryToJavaMap(additionalParameters));

            }
#else

#endif
        }

#if UNITY_IOS && !UNITY_EDITOR
        
    [DllImport("__Internal")]
    private static extern void _start();

    [DllImport("__Internal")]
    private static extern void _setIsDebugAdrevenue(bool isDebug);

    [DllImport("__Internal")]
    private static extern void _logAdRevenue(string monetizationNetwork,
                                             AppsFlyerAdRevenueMediationNetworkType mediationNetwork,
                                             double eventRevenue,
                                             string revenueCurrency,
                                             string additionalParameters);

#elif UNITY_ANDROID && !UNITY_EDITOR

#else

#endif
        private static int setMediationNetworkTypeAndroid(AppsFlyerAdRevenueMediationNetworkType mediationNetwork)
        {
            switch (mediationNetwork)
            {
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeIronSource:
                    return 0;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeApplovinMax:
                    return 1;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeGoogleAdMob:
                    return 2;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeMoPub:
                    return 3;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeFyber:
                    return 4;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeAppodeal:
                    return 5;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeAdmost:
                    return 6;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeTopon:
                    return 7;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeTradplus:
                    return 8;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeYandex:
                    return 9;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeChartBoost:
                    return 10;
                case AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeUnity:
                    return 11;
                default:
                    return -1;
            }

        }
        private static AndroidJavaObject convertDictionaryToJavaMap(Dictionary<string, string> dictionary)
        {
            AndroidJavaObject map = new AndroidJavaObject("java.util.HashMap");
            IntPtr putMethod = AndroidJNIHelper.GetMethodID(map.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            jvalue[] val;
            if (dictionary != null)
            {
                foreach (var entry in dictionary)
                {
                    val = AndroidJNIHelper.CreateJNIArgArray(new object[] { entry.Key, entry.Value });
                    AndroidJNI.CallObjectMethod(map.GetRawObject(), putMethod, val);
                    AndroidJNI.DeleteLocalRef(val[0].l);
                    AndroidJNI.DeleteLocalRef(val[1].l);
                }
            }

            return map;
        }
    }


    public enum AppsFlyerAdRevenueMediationNetworkType
    {
        AppsFlyerAdRevenueMediationNetworkTypeGoogleAdMob = 1,
        AppsFlyerAdRevenueMediationNetworkTypeMoPub = 2,
        AppsFlyerAdRevenueMediationNetworkTypeIronSource = 3,
        AppsFlyerAdRevenueMediationNetworkTypeApplovinMax = 4,
        AppsFlyerAdRevenueMediationNetworkTypeFyber = 5,
        AppsFlyerAdRevenueMediationNetworkTypeAppodeal = 6,
        AppsFlyerAdRevenueMediationNetworkTypeAdmost = 7,
        AppsFlyerAdRevenueMediationNetworkTypeTopon = 8,
        AppsFlyerAdRevenueMediationNetworkTypeTradplus = 9,
        AppsFlyerAdRevenueMediationNetworkTypeYandex = 10,
        AppsFlyerAdRevenueMediationNetworkTypeChartBoost = 11,
        AppsFlyerAdRevenueMediationNetworkTypeUnity = 12

    }



}