package com.appsflyer.unity.afunityadrevenuegenericplugin;

import android.app.Application;
import com.appsflyer.adrevenue.AppsFlyerAdRevenue;
import com.appsflyer.adrevenue.adnetworks.generic.MediationNetwork;

import java.util.Currency;
import java.util.HashMap;

public class AdRevenueUnityWrapper {

    /**
     * start
     * @param application
     */
    public static void start(Application application) {
        AppsFlyerAdRevenue.initialize(new AppsFlyerAdRevenue.Builder(application)
                .build());
    }

    /**
     * logAdRevenue
     *
     * @param monetizationNetwork
     * @param mediationNetwork
     * @param eventRevenueCurrency
     * @param  eventRevenue
     * @param  nonMandatory
     */
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