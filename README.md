<img src="https://www.appsflyer.com/wp-content/uploads/2016/11/logo-1.svg"  width="450">

# appsflyer-unity-adrevenue-generic-connector

🛠 In order for us to provide optimal support, we would kindly ask you to submit any issues to support@appsflyer.com

*When submitting an issue please specify your AppsFlyer sign-up (account) email , your app ID , production steps, logs, code snippets and any additional relevant information.*


## Table of content

- [Installation](#installation)
- [Initialization](#init-sdk)
- [API](#api) 

## <a id="installation"> 📲 Installation
   
   This plugin requires the AppsFlyer Unity plugin version >= 4.22.x.


1. Clone / download this repository.
2. [Import](https://docs.unity3d.com/Manual/AssetPackages.html) appsflyer-unity-adrevenue-plugin-x.x.x.unitypackage  into your Unity project.
    * Go to Assets >> Import Package >> Custom Package
    * Select appsflyer-unity-adrevenue-plugin-x.x.x.unitypackage.

**Note:** You must have the [AppsFlyer Unity plugin](https://github.com/AppsFlyerSDK/appsflyer-unity-plugin) already in your project. In addition, make sure to init AppsFlyer SDK before AppsFlyerAdRevenue.

## <a id="init-sdk"> 🚀 Initialization


---
```c#
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
   

## <a id="api"> 📑 API
  Check out the API [here](/docs/api.md).


