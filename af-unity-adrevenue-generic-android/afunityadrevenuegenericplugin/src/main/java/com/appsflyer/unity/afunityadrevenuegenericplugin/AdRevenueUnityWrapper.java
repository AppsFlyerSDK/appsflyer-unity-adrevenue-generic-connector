package com.appsflyer.unity.afunityadrevenuegenericplugin;

import android.app.Application;
import com.appsflyer.adrevenue.AppsFlyerAdRevenue;
import com.appsflyer.adrevenue.adnetworks.generic.MediationNetwork;

import java.util.Currency;
import java.util.HashMap;

public class AdRevenueUnityWrapper {

    /**
     * Start - currently we only support MoPub
     * In the future we will support more AppsFlyerAdRevenueWrapperTypes
     *
     * @param application
     */
    public static void start(Application application) {
        AppsFlyerAdRevenue.initialize(new AppsFlyerAdRevenue.Builder(application)
                .build());
    }
    public static void logAdRevenue(String monetizationNetwork,
                                    int mediationNetwork,
                                    String eventRevenueCurrency,
                                    double eventRevenue,
                                    HashMap<String, String> nonMandatory) {
        Currency currency = Currency.getInstance(eventRevenueCurrency);
        AppsFlyerAdRevenue.logAdRevenue(monetizationNetwork,
                MediationNetwork.values()[mediationNetwork],
                currency,
                eventRevenue,
                nonMandatory);
    }

}