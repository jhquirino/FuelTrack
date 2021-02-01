// -----------------------------------------------------------------------
//  <copyright file="IFuelUpStore.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using System.Threading.Tasks;
using FuelTrack.Domain;

namespace FuelTrack.Data
{
    /// <summary>
    /// Store to read/write fuel-up data.
    /// </summary>
    public interface IFuelUpStore : IDataStore<FuelUp>
    {
        /// <summary>
        /// Get fuel-ups by car.
        /// </summary>
        /// <param name="carId">Car ID.</param>
        /// <param name="forceRefresh">Determines whether to read from the source or cache (if implemented).</param>
        /// <returns>
        /// All fuel-ups done by car.
        /// </returns>
        Task<IReadOnlyCollection<FuelUp>> GetAllByCarAsync(string carId, bool forceRefresh = false);
    }
}
