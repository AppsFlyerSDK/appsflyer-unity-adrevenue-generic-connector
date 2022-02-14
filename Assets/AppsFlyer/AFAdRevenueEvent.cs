using System.Collections;
using UnityEngine;

public class AFAdRevenueEvent {

    /**
    *Pre-defined keys for non-mandatory dictionary
    *Code ISO 3166-1 format
    **/
    public const string COUNTRY = "country";

    /**
    *ID of the ad unit for the impression
    **/
    public const string AD_UNIT = "ad_unit";

    /**
    *Format of the ad
    **/
    public const string AD_TYPE = "ad_type";

      /**
    *ID of the ad placement for the impression
    **/
    public const string PLACEMENT = "placement";

      /**
    *Provided by Facebook Audience Network only, and will be reported to publishers
    *approved by Facebook Audience Network within the closed beta
    **/
    public const string ECPM_PAYLOAD = "ecpm_payload";


}
