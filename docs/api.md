# API


- [start](#start)
- [setIsDebug](#setIsDebug)

<hr>

##### <a id="start"> `public static void start()`
  
  Start sending AdRevenue data to AppsFlyer.
  
  *Example:*
  
  ```c#
  
  using AppsFlyerSDK;
    
    void Start()
    {
      AppsFlyerAdRevenue.start();
    }
    
  ```
  
  <hr>
  
##### <a id="setIsDebug"> `public static void setIsDebug(bool isDebug)`
  
  Set to true to view debug logs. (development only!)
  
  *Example:*
  
  ```c#
    AppsFlyerAdRevenue.setIsDebug(true);
  ```

  **Note** this API will only set the debug logs for iOS. For Android the debug logs are controlled by the native SDK.
  To turn on the debug logs on Android call `AppsFlyer.setIsDebug(true);`
  
| Setting | type   |  description                  |
| --------|------- |-------------------------------|
| isDebug | bool   | set true in development only  |

  <hr>
  
##### <a id="logAdRevenue"> `public static void logAdRevenue(string           monetizationNetwork, AppsFlyerAdRevenueMediationNetworkType mediationNetwork, double eventRevenue, string revenueCurrency, Dictionary<string, string> additionalParameters)`
  
Allow you send data from the impression payload to AdRevenue no matter which mediation network you use.

  
  *Example:*
  
  ```c#
         Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("custom", "foo");
        dic.Add("custom_2", "bar");
        dic.Add("af_quantity", "1");
        AppsFlyerAdRevenue.logAdRevenue("facebook", AppsFlyerAdRevenueMediationNetworkType.AppsFlyerAdRevenueMediationNetworkTypeMoPub., 0.026, "USD", dic);
  ```

  
| Setting | type   |  description                  |
| --------|------- |-------------------------------|
| monetizationNetwork | string   | monetization network |
| mediationNetwork | AppsFlyerAdRevenueMediationNetworkType   | Enum for mediaton network type |
| eventRevenue | string   |event revenue |
| monetizationNetwork | double   | event revenue |
| revenueCurrency | string   | revenue currency  |
| additionalParameters | Dictionary<string, string>    | Any custom additional parameters |
  
