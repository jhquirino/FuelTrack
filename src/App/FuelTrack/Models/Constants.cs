// -----------------------------------------------------------------------
//  <copyright file="Constants.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.Models
{
    internal static class Constants
    {
        /*
         * Symbols
         */

        /// <summary>
        /// Distance unit symbol: Kilometers.
        /// </summary>
        public const string SYMBOL_KILOMETERS = "km";

        /// <summary>
        /// Distance unit symbol: Miles.
        /// </summary>
        public const string SYMBOL_MILES = "mi";

        /// <summary>
        /// Fuel unit symbol: Liters.
        /// </summary>
        public const string SYMBOL_LITERS = "l";

        /// <summary>
        /// Fuel unit symbol: Gallons.
        /// </summary>
        public const string SYMBOL_GALLONS = "g";

        /// <summary>
        /// Fuel unit symbol: Kilowatt/Hours.
        /// </summary>
        public const string SYMBOL_KILOWATT_HOURS = "kWh";

        /*
         * Resources
         */

        /// <summary>
        /// Resource name: Navigation Bar Color.
        /// </summary>
        public const string RESOURCE_BAR_COLOR = "NavigationBarColor";

        /*
         * Messages (pub/sub)
         */

        /// <summary>
        /// Message name: Change Unit.
        /// </summary>
        public const string MESSAGE_CHANGE_UNIT = "ChangeUnit";

        /// <summary>
        /// Message name: Add Car.
        /// </summary>
        public const string MESSAGE_ADD_CAR = "AddCar";

        /// <summary>
        /// Message name: Add Fuel Up.
        /// </summary>
        public const string MESSAGE_ADD_FUELUP = "AddFuelUp";
    }
}
