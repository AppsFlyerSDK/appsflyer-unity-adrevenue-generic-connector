//
//  AppsFlyerAdRevenueWrapper.mm
//  Unity-iPhone
//
//  Created by Jonathan Wesfield on 25/11/2019.
//

#import "AppsFlyerAdRevenueWrapper.h"


@implementation AppsFlyerAdRevenueWrapper


extern "C" {

    NSString* stringFromChar(const char *str) {
        return str ? [NSString stringWithUTF8String:str] : nil;
    }

    NSDictionary* dictionaryFromJson(const char *jsonString) {
        if(jsonString){
            NSData *jsonData = [[NSData alloc] initWithBytes:jsonString length:strlen(jsonString)];
            NSDictionary *dictionary = [NSJSONSerialization JSONObjectWithData:jsonData options:kNilOptions error:nil];
            return dictionary;
        }
        return nil;
    }
    
    
    const void _start(int length, int* adRevenueTypes){
        [AppsFlyerAdRevenue start];
    }
    const void _setIsDebugAdrevenue(bool isDebug){
        [[AppsFlyerAdRevenue shared] setIsDebug:isDebug];
    }
    
    const void _logAdRevenue(const char* monetizationNetwork,
                             int mediationNetwork,
                             double eventRevenue,
                             const char* revenueCurrency,
                             const char* additionalParameters){
        [[AppsFlyerAdRevenue shared] logAdRevenueWithMonetizationNetwork:stringFromChar(monetizationNetwork)
                                                        mediationNetwork:(AppsFlyerAdRevenueMediationNetworkType) mediationNetwork
                                                            eventRevenue:[NSNumber numberWithDouble:eventRevenue]
                                                         revenueCurrency:stringFromChar(revenueCurrency)
                                                    additionalParameters:dictionaryFromJson(additionalParameters)];
        
    }
}

@end
