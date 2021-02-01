// -----------------------------------------------------------------------
//  <copyright file="MockCarDataStore.cs" company="Jorge Quirino">
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
    public class MockCarStore : ICarStore
    {
        private readonly List<Car> cars;

        public MockCarStore()
        {
            cars = new List<Car>();
        }

        public async Task<bool> AddAsync(Car item)
        {
            cars.Add(item);
            await Task.Delay(500).ConfigureAwait(false); ;
            return await Task.FromResult(true).ConfigureAwait(false); ;
        }

        public async Task<bool> UpdateAsync(Car item)
        {
            var oldItem = cars.Where((Car arg) => arg.Id == item.Id).FirstOrDefault();
            if (oldItem != null)
            {
                cars.Remove(oldItem);
                cars.Add(item);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = cars.Where((Car arg) => arg.Id == id).FirstOrDefault();
            if (oldItem != null)
            {
                cars.Remove(oldItem);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<Car> GetAsync(string id)
        {
            return await Task.FromResult(cars.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IReadOnlyCollection<Car>> GetAllAsync(bool forceRefresh = false)
        {
            await Task.Delay(3000);
            return await Task.FromResult(cars);
        }

        public async Task<Car> FindAsync(Expression<Func<Car, bool>> expr)
        {
            var result = cars.FirstOrDefault(expr.Compile());
            return await Task.FromResult(result);
        }

        public async Task<IReadOnlyCollection<Car>> WhereAsync(Expression<Func<Car, bool>> expr)
        {
            var results = cars.Where(expr.Compile()).ToList();
            return await Task.FromResult(results);
        }
    }
}
