using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowGo.API
{
    public class API
    {
        private static string key = " ";
        public static string Key { get { return key; } set { key = value; } }


        private static readonly string apiLinkGMap = "https://maps.googleapis.com/maps/api/js?key=" + key + " ";
        public static string APILinkGMap { get { return apiLinkGMap; } }

        private static readonly string apiLinkGeocoder = "https://maps.googleapis.com/maps/api/geocode/json?key=" + key + "&address";
        public static string APILinkGeocoder { get { return apiLinkGeocoder; } }

        private static readonly string APILinkTicketmaster = "https://app.ticketmaster.com/discovery/v2/events.json?apikey= key";

    }
}