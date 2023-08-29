---
title: Ad Revenue Generic Connector
category: 5f9705393c689a065c409b23
parentDoc: 6370c9e2441a4504d6bca3bd
order: 12
hidden: false
---

## Overview

**Ad revenue reporting options**

Ad revenue is reported to AppsFlyer by either aggregate granularity (via API) or impression-level granularity (via SDK). Impression-level data via SDK has better data freshness and earlier availability in AppsFlyer.

**SDK principles of operation**

The ad revenue SDK connector sends impression revenue data to the AppsFlyer SDK. An ad revenue event, `af_ad_revenue`, is generated and sent to the platform. These impression events are collected and processed in AppsFlyer, and the revenue is attributed to the original UA source.

## Install the connector

**Prerequisite:** Before installing the connector [update your SDK](https://dev.appsflyer.com/hc/docs/sdk-installation) and the [AppsFlyer Unity plugin](https://dev.appsflyer.com/hc/docs/installation) to their latest versions. 

1. Clone or download [the Ad revenue connector](https://github.com/AppsFlyerSDK/appsflyer-unity-adrevenue-generic-connector/tree/main) repository.
2. Import the Adrevenue Unity package into your Unity project (To learn how to import to Unity refer to the [Unity documentation](https://docs.unity3d.com/Manual/AssetPackages.html)).
    1. In Unity, go to **Assets** > **Import Package** > **Custom Package**
    2. From the repository root select the  `appsflyer-unity-adrevenue-plugin-x.x.x.unitypackage` file.

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

  ....

    Dictionary<string, string> dic = new Dictionary<string, string>();
    dic.Add("custom", "foo");
    dic.Add("custom_2", "bar");
    dic.Add("af_quantity", "1");
    AppsFlyerAdRevenue.logAdRevenue("facebook", AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeGoogleAdMob, 0.026, "USD", dic);
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
Dictionary<string, string> dic = new Dictionary<string, string>();
dic.Add("custom", "foo");
dic.Add("custom_2", "bar");
dic.Add("af_quantity", "1");
AppsFlyerAdRevenue.logAdRevenue("facebook", AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeMoPub., 0.026, "USD", dic);
```