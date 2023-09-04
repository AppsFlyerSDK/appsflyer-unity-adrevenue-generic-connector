//
//  AppsFlyerAdRevenueWrapper.h
//  Unity-iPhone
//
//  Created by Jonathan Wesfield on 01/12/2019.
//

#import <Foundation/Foundation.h>

#if __has_include(<AFUnityUitls.mm>)
#import "AFUnityUtils.mm"
#else
#import "Libraries/appsflyer-unity-plugin/Plugins/iOS/AFUnityUtils.mm"
#endif
#if __has_include(<AppsFlyerAdRevenue/AppsFlyerAdRevenue.h>)
#import <AppsFlyerAdRevenue/AppsFlyerAdRevenue.h>
#endif

@interface AppsFlyerAdRevenueWrapper : NSObject

@end
