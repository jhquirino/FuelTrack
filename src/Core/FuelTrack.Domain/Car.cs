// -----------------------------------------------------------------------
//  <copyright file="Car.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.Domain
{
    /// <summary>
    /// Car information.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Car ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Alias or name assigned to car.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Vendor or manufacturer name.
        /// </summary>
        public string Vendor { get; set; }
        /// <summary>
        /// Model name.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Year of manufacturing/model.
        /// </summary>
        public ushort Year { get; set; }
        /// <summary>
        /// Car number plate.
        /// </summary>
        public string Plate { get; set; }
        /// <summary>
        /// Kind of fuel used by car.
        /// </summary>
        public FuelType FuelType { get; set; }
        /// <summary>
        /// Observations/notes.
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Timestamp of creation.
        /// </summary>
        public long CreatedAt { get; set; }
        /// <summary>
        /// Timestamp of last change.
        /// </summary>
        public long LastChangedAt { get; set; }
    }
}
