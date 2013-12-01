using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MePOR.Controller
{
    /// <summary>
    /// Static class that will have methods that validates new member registration information.
    /// </summary>
    public static class NewMemberValidationController
    {

        private const string US_ZIP_REGEX = @"^\d{5}$|^\d{5}-\d{4}$";
        

        /// <summary>+
        /// Validates the name so that the given name only contains letters
        /// </summary>
        /// <param name="name">The name to validate</param>
        /// <returns>True if the name is valid, false otherwise</returns>
        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        /// <summary>
        /// Validates the phone number by making sure it is only numbers and is 10 numbers lone
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate</param>
        /// <returns>True if the phone number is valid, false otherwise</returns>
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            return (Regex.IsMatch(phoneNumber, @"^[0-9]+$") && phoneNumber.Length == 10);

        }

        /// <summary>
        /// Validates the given SSN by making sure it is only numbers
        /// </summary>
        /// <param name="ssn">The SSN to validate</param>
        /// <returns>True if the SSN is valid, false otherwise</returns>
        public static bool ValidateSSN(string ssn)
        {
            return Regex.IsMatch(ssn, @"^[0-9]+$");
        }

        /// <summary>
        /// Validates the given Zip Code (string)
        /// </summary>
        /// <param name="zip">The string of the zip code</param>
        /// <returns>True if the zip code is valid, false otherwise</returns>
        public static bool ValidateZipCode(string zip)
        {
            return Regex.IsMatch(zip, US_ZIP_REGEX);
        }

    }
}
