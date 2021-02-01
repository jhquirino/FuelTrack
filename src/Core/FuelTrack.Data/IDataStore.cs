// -----------------------------------------------------------------------
//  <copyright file="IDataStore.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FuelTrack.Data
{
    /// <summary>
    /// Generic store to read/write data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Adds a single data entry.
        /// </summary>
        /// <param name="item">Data entry.</param>
        /// <returns>
        /// <see langword="true"/> if the entry is added, otherwise, <see langword="false"/>.
        /// </returns>
        Task<bool> AddAsync(T item);
        /// <summary>
        /// Updates a single data entry.
        /// </summary>
        /// <param name="item">Data entry.</param>
        /// <returns>
        /// <see langword="true"/> if the entry is updated, otherwise, <see langword="false"/>.
        /// </returns>
        Task<bool> UpdateAsync(T item);
        /// <summary>
        /// Deletes a single data entry.
        /// </summary>
        /// <param name="id">ID of the entry to delete.</param>
        /// <returns>
        /// <see langword="true"/> if the entry is deleted, otherwise, <see langword="false"/>.
        /// </returns>
        Task<bool> DeleteAsync(string id);
        /// <summary>
        /// Gets a single data entry.
        /// </summary>
        /// <param name="id">ID of the entry to read.</param>
        /// <returns>The entry read.</returns>
        Task<T> GetAsync(string id);
        /// <summary>
        /// Gets all data entries.
        /// </summary>
        /// <param name="forceRefresh">Determines whether to read from the source or cache (if implemented).</param>
        /// <returns>All the entries read.</returns>
        Task<IReadOnlyCollection<T>> GetAllAsync(bool forceRefresh = false);
        /// <summary>
        /// Finds a single entry that matches criteria.
        /// </summary>
        /// <param name="expr">Criteria to match.</param>
        /// <returns>Found entry.</returns>
        Task<T> FindAsync(Expression<Func<T, bool>> expr);
        /// <summary>
        /// Finds all entries that match criteria.
        /// </summary>
        /// <param name="expr">Criteria to match.</param>
        /// <returns>Found entries.</returns>
        Task<IReadOnlyCollection<T>> WhereAsync(Expression<Func<T, bool>> expr);
    }
}
