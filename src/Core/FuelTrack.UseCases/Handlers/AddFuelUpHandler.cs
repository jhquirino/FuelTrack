// -----------------------------------------------------------------------
//  <copyright file="AddFuelUpHandler.cs" company="Jorge Quirino">
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
    public class AddFuelUpHandler : IRequestHandler<AddFuelUpRequest, AddFuelUpResponse>
    {
        private readonly IFuelUpStore fuelUpStore;

        public AddFuelUpHandler(IFuelUpStore fuelUpStore)
        {
            this.fuelUpStore = fuelUpStore ?? throw new ArgumentNullException(nameof(fuelUpStore));
        }

        public async Task<AddFuelUpResponse> Handle(AddFuelUpRequest request, CancellationToken cancellationToken)
        {
            var timestamp = DateTime.Now.ToUnixTimestamp();
            var newFuelUp = new FuelUp
            {
                Id = Guid.NewGuid().ToString("N"),
                CarId = request.CarId,
                Timestamp = request.DateTime.ToUnixTimestamp(),
                Quantity = request.Quantity,
                Amount = request.Amount,
                Distance = request.Distance,
                Note = request.Note,
                IsPartial = request.IsPartial,
                CreatedAt = timestamp,
                LastChangedAt = timestamp
            };
            var success = await fuelUpStore.AddAsync(newFuelUp).ConfigureAwait(false);
            return new AddFuelUpResponse(
                success,
                success ? newFuelUp.Id : null,
                success ? request.CarId : null
            );
        }
    }
}