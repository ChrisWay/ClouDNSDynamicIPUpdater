﻿using System;

namespace ClouDNSIPUpdater.Library
{
    public static class ResponseParser
    {
        public const string ValidResponce = "ok";
        public const string InvalidResponse = "invalid request.";

        /// <summary>
        /// Checks whether the <param name="cloudResponse" /> matches the successful value or not.
        /// </summary>
        /// <param name="cloudResponse">The response to check</param>
        /// <returns>A bool representing whether the response was successful. </returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the response isn't a known valid or invalid response.</exception>
        public static bool CheckResponse(string cloudResponse)
        {
            switch (cloudResponse.ToLower())
            {
                case ValidResponce:
                    return true;
                case InvalidResponse:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException("cloudResponse",
                                                          string.Format("The reponse was received was not a known response: {0}",cloudResponse));
            }
        }
    }
}