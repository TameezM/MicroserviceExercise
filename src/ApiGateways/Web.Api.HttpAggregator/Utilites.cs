using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator
{
    /// <summary>
    /// This should go in seperate utils lib. putting it here for quick development.
    /// </summary>
    public static class Utilites
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public static bool validateAddress(string Address)
        {
            bool isValidAddres = true;
            if (String.IsNullOrEmpty(Address))
            {
                return false;
            }
            if (!Utilites.ValidateIPAddress(Address))
            {
                //return BadRequest("Invalid IP Address is empty. Please give valid address.");
                isValidAddres = false;
            }
            if (!Utilites.ValidateDomainAddress(Address))
            {
                if (!isValidAddres)
                    return false;
            }
            else
            {
                isValidAddres = true;
            }
            return isValidAddres;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static bool ValidateIPAddress(string ipAddress)
        {
            // Set the default return value to false
            bool isIPAddress = false;

            // Set the regular expression to match IP addresses
            string ipPattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

            // Create an instance of System.Text.RegularExpressions.Regex
            Regex regex = new Regex(ipPattern);

            // Validate the IP address
            isIPAddress = regex.IsMatch(ipAddress);

            return isIPAddress;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Address"></param>
        /// <returns></returns>
        public static bool ValidateDomainAddress(string Address)
        {
            // Set the default return value to false
            bool isIPAddress = false;

            // Set the regular expression to match IP addresses
            string ipPattern = @"\b([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}\b";

            // Create an instance of System.Text.RegularExpressions.Regex
            Regex regex = new Regex(ipPattern);

            // Validate the IP address
            isIPAddress = regex.IsMatch(Address);

            return isIPAddress;
        }
    }
}
