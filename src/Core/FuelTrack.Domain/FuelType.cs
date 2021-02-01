// -----------------------------------------------------------------------
//  <copyright file="FuelType.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.Domain
{
    /// <summary>
    /// Fuel types.
    /// </summary>
    public enum FuelType
    {
        /// <summary>
        /// Unknown fuel type.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Gasoline.
        /// </summary>
        Gasoline = 1,
        /// <summary>
        /// Diesel.
        /// </summary>
        Diesel = 2,
        /// <summary>
        /// Liquified Petroleum.
        /// </summary>
        Petroleum = 3,
        /// <summary>
        /// Compressed Natural Gas.
        /// </summary>
        NaturalGas = 4,
        /// <summary>
        /// Ethanol.
        /// </summary>
        Ethanol = 5,
        /// <summary>
        /// Bio-diesel.
        /// </summary>
        BioDiesel = 6,
        /// <summary>
        /// Hydrogen.
        /// </summary>
        Hydrogen = 7,
        /// <summary>
        /// Electricity.
        /// </summary>
        Electricity = 8,
        /// <summary>
        /// Other not listed.
        /// </summary>
        Other = 99
    }
}
