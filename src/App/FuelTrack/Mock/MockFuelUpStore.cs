// -----------------------------------------------------------------------
//  <copyright file="MockFuelUpStore.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FuelTrack.Data;
using FuelTrack.Domain;

namespace FuelTrack.Mock
{
    public class MockFuelUpStore : IFuelUpStore
    {
        private readonly List<FuelUp> fuelups;

        public MockFuelUpStore()
        {
            fuelups = new List<FuelUp>();
        }

        public async Task<bool> AddAsync(FuelUp item)
        {
            fuelups.Add(item);
            await Task.Delay(500).ConfigureAwait(false); ;
            return await Task.FromResult(true).ConfigureAwait(false); ;
        }

        public async Task<bool> UpdateAsync(FuelUp item)
        {
            var oldItem = fuelups.Where((FuelUp arg) => arg.Id == item.Id).FirstOrDefault();
            if (oldItem != null)
            {
                fuelups.Remove(oldItem);
                fuelups.Add(item);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = fuelups.Where((FuelUp arg) => arg.Id == id).FirstOrDefault();
            if (oldItem != null)
            {
                fuelups.Remove(oldItem);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<FuelUp> GetAsync(string id)
        {
            return await Task.FromResult(fuelups.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IReadOnlyCollection<FuelUp>> GetAllAsync(bool forceRefresh = false)
        {
            await Task.Delay(3000);
            return await Task.FromResult(fuelups);
        }

        public async Task<FuelUp> FindAsync(Expression<Func<FuelUp, bool>> expr)
        {
            var result = fuelups.FirstOrDefault(expr.Compile());
            return await Task.FromResult(result);
        }

        public async Task<IReadOnlyCollection<FuelUp>> WhereAsync(Expression<Func<FuelUp, bool>> expr)
        {
            var results = fuelups.Where(expr.Compile()).ToList();
            return await Task.FromResult(results);
        }

        public async Task<IReadOnlyCollection<FuelUp>> GetAllByCarAsync(string carId, bool forceRefresh = false)
        {
            return await WhereAsync(f => f.CarId == carId);
        }
    }
}
