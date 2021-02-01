// -----------------------------------------------------------------------
//  <copyright file="FuelUp.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.Domain
{
    /// <summary>
    /// Fuel-up data.
    /// </summary>
    public class FuelUp
    {
        /// <summary>
        /// Event (fuel-up) ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Car ID.
        /// </summary>
        public string CarId { get; set; }
        /// <summary>
        /// Timestamp (date/time) of the event.
        /// </summary>
        public long Timestamp { get; set; }
        /// <summary>
        /// Amount of fuel recharged.
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// Amount paid for fuel-up.
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Distance traveled since last fuel-up.
        /// </summary>
        public decimal Distance { get; set; }
        /// <summary>
        /// Observations/notes.
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Indicates whether the fuel-up was partial.
        /// </summary>
        public bool IsPartial { get; set; }
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
