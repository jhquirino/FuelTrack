// -----------------------------------------------------------------------
//  <copyright file="AddCarHandler.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Threading;
using System.Threading.Tasks;
using FuelTrack.Data;
using FuelTrack.Domain;
using FuelTrack.UseCases.Messages;
using MediatR;

namespace FuelTrack.UseCases.Handlers
{
    public class AddCarHandler : IRequestHandler<AddCarRequest, AddCarResponse>
    {
        private readonly ICarStore carStore;

        public AddCarHandler(ICarStore carStore)
        {
            this.carStore = carStore ?? throw new ArgumentNullException(nameof(carStore));
        }

        public async Task<AddCarResponse> Handle(AddCarRequest request, CancellationToken cancellationToken)
        {
            var timestamp = DateTime.Now.ToUnixTimestamp();
            var newCar = new Car
            {
                Id = Guid.NewGuid().ToString("N"),
                Alias = request.Alias,
                Vendor = request.Vendor,
                Model = request.Model,
                Year = request.Year,
                Plate = request.Plate,
                FuelType = request.FuelType,
                Note = request.Note,
                CreatedAt = timestamp,
                LastChangedAt = timestamp
            };
            var success = await carStore.AddAsync(newCar).ConfigureAwait(false);
            return new AddCarResponse(
                success,
                success ? newCar.Id : null,
                success ? request.Alias : null
            );
        }
    }
}
