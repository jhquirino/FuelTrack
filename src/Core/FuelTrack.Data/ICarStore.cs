// -----------------------------------------------------------------------
//  <copyright file="ICarStore.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------

using FuelTrack.Domain;

namespace FuelTrack.Data
{
    /// <summary>
    /// Store to read/write car data.
    /// </summary>
    public interface ICarStore : IDataStore<Car>
    {
    }
}
