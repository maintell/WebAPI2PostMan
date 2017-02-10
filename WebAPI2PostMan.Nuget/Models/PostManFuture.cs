﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAPI2PostMan.Nuget.Models
{
    public class PostMan
    {
        private static readonly RandomNumberGenerator Randgen = new RNGCryptoServiceProvider();
        private static readonly char[] UrlUnsafeBase64Chars = { '+', '/' };
        public static string GetId()
        {
            return Guid.NewGuid().ToString();
        }
        public static string GetRaddomId()
        {
            string base64Id;
            do
            {
                base64Id = CreateRandomBase64Id();
            } while (Base64StringContainsUrlUnfriendlyChars(base64Id));
            return base64Id;
        }
        public static long GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
        private static string CreateRandomBase64Id()
        {
            var data = new byte[15];
            Randgen.GetBytes(data);
            return Convert.ToBase64String(data);
        }
        private static bool Base64StringContainsUrlUnfriendlyChars(string base64)
        {
            return base64.IndexOfAny(UrlUnsafeBase64Chars) >= 0;
        }
    }

    public class PostmanCollection
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> order { get; set; }
        public long timestamp { get; set; }
        public List<PostmanRequest> requests { get; set; }
    }

    public class PostmanRequest
    {
        public string collection { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string dataMode { get; set; }
        public List<PostmanData> data { get; set; }
        public string description { get; set; }
        public string descriptionFormat { get; set; }
        public string headers { get; set; }
        public string method { get; set; }
        public Dictionary<string, string> pathVariables { get; set; }
        public string url { get; set; }
        public int version { get; set; }
        public string collectionId { get; set; }
        public string rawModeData { get; set; }
    }

    public class PostmanData
    {
        public string key { get; set; }
        public string value { get; set; }
        public string type {
            get { return "text"; }
        }
        public bool enabled {
            get { return true; }
        }
    }
}