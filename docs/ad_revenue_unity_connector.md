---
title: Ad Revenue Generic Connector
category: 5f9705393c689a065c409b23
parentDoc: 6370c9e2441a4504d6bca3bd
order: 12
hidden: false
---

## Overview

### Ad revenue reporting options

Ad revenue is reported to AppsFlyer by either aggregate granularity (via API) or impression-level granularity (via SDK). Impression-level data via SDK has better data freshness and earlier availability in AppsFlyer.

### SDK principles of operation

The ad revenue SDK connector sends impression revenue data to the AppsFlyer SDK. An ad revenue event, `af_ad_revenue`, is generated and sent to the platform. These impression events are collected and processed in AppsFlyer, and the revenue is attributed to the original UA source.

> 📘 **Note**
>
> The marketer also needs to configure the integration for each mediation partner in AppsFlyer, either impression-level (via SDK) or impression-level (via SDK) with device-level (via S2S API). [Learn more](https://support.appsflyer.com/hc/en-us/articles/217490046#connect-to-ad-revenue-integrated-partners)

## Install the connector

**Prerequisite:** Before installing the connector [update your SDK](https://dev.appsflyer.com/hc/docs/sdk-installation) and the [AppsFlyer Unity plugin](https://dev.appsflyer.com/hc/docs/installation) to their latest versions. 

## Using Unity Package

1. Clone or download [the Ad revenue connector](https://github.com/AppsFlyerSDK/appsflyer-unity-adrevenue-generic-connector/tree/main) repository.
2. Import the Adrevenue Unity package into your Unity project (To learn how to import to Unity refer to the [Unity documentation](https://docs.unity3d.com/Manual/AssetPackages.html)).
    1. In Unity, go to **Assets** > **Import Package** > **Custom Package**
    2. From the repository root select the  `appsflyer-unity-adrevenue-plugin-x.x.x.unitypackage` file.

## Using Unity Package Manager

1. Add the dependency in your `manifest.json` file:
```
 "appsflyer-unity-adrevenue-generic-connector": "https://github.com/AppsFlyerSDK/appsflyer-unity-adrevenue-generic-connector.git#upm"
```
2. If you haven't already done so, download the [External Dependency Manager for Unity](https://github.com/googlesamples/unity-jar-resolver) to be able to resolve our Android / iOS dependencies.

**Note:** To choose a specific version and not the latest, you can replace the `upm` with the specific version tag, `v6.9.4-upm` for example.

## Initialize the connector

Make sure to initialize the AppsFlyer SDK before initializing the connector. 

```java
using AppsFlyerSDK;

public class AppsFlyerObjectScript : MonoBehaviour
{
  void Start()
  {
  	AppsFlyerAdRevenue.start();
  	/* AppsFlyerAdRevenue.setIsDebug(true); */
  }
}

```

## Ad revenue connector API

### `start`


`public static void start()`

Start sending AdRevenue data to AppsFlyer.

*Example:*

```java
using AppsFlyerSDK;
  void Start()
  {
    AppsFlyerAdRevenue.start();
  }
```

### `setIsDebug`

 `public static void setIsDebug(bool isDebug)`

Set to true to view debug logs. (development only!)

| parameter | type | description |
| --- | --- | --- |
| isDebug | bool | set to true in development only |

*Example:*

```java
  AppsFlyerAdRevenue.setIsDebug(true);
```

**Note:** This API will only set the debug logs for iOS. For Android the debug logs are controlled by the native SDK.
To turn on the debug logs on Android call `AppsFlyer.setIsDebug(true);`

### `logAdRevenue`

`public static void logAdRevenue(string monetizationNetwork, AppsFlyerAdRevenueMediationNetworkType mediationNetwork, double eventRevenue, string revenueCurrency, Dictionary<string, string> additionalParameters)`

Send ad revenue data from the impression payload to AppsFlyer regardless of the mediation network you use.

| parameter | type | description |
| --- | --- | --- |
| monetizationNetwork | string | monetization network |
| mediationNetwork | AppsFlyerAdRevenueMediationNetworkType | Enum for mediaton network type |
| eventRevenue | string | event revenue |
| revenueCurrency | string | revenue currency |
| additionalParameters | Dictionary<string, string> | Any custom additional parameters |
|  |  |  |

*Example:*

```java
Dictionary<string, string> additionalParams = new Dictionary<string, string>();
additionalParams.Add(AFAdRevenueEvent.COUNTRY, "US");
additionalParams.Add(AFAdRevenueEvent.AD_UNIT, "89b8c0159a50ebd1");
additionalParams.Add(AFAdRevenueEvent.AD_TYPE, "Banner");
additionalParams.Add(AFAdRevenueEvent.PLACEMENT, "place");
additionalParams.Add(AFAdRevenueEvent.ECPM_PAYLOAD, "encrypt");

additionalParams.Add("custom", "foo");
additionalParams.Add("custom_2", "bar");
additionalParams.Add("af_quantity", "1");
AppsFlyerAdRevenue.logAdRevenue("facebook",
                                AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeGoogleAdMob,                                   
                                0.026,
                                "USD",
                                additionalParams);
```
