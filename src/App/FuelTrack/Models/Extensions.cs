// -----------------------------------------------------------------------
//  <copyright file="Extensions.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using static FuelTrack.Models.Constants;

namespace FuelTrack.Models
{
    internal static class Extensions
    {
        internal static string ToSymbol(this DistanceUnit unit)
        {
            return unit switch
            {
                DistanceUnit.Kilometers => SYMBOL_KILOMETERS,
                DistanceUnit.Miles => SYMBOL_MILES,
                _ => string.Empty
            };
        }

        internal static string ToSymbol(this FuelUnit unit)
        {
            return unit switch
            {
                FuelUnit.Liters => SYMBOL_LITERS,
                FuelUnit.Gallons => SYMBOL_GALLONS,
                FuelUnit.KilowattHours => SYMBOL_KILOWATT_HOURS,
                _ => string.Empty
            };
        }
    }
}
