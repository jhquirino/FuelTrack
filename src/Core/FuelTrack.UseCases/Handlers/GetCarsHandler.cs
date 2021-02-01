// -----------------------------------------------------------------------
//  <copyright file="GetCarsHandler.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FuelTrack.Data;
using FuelTrack.Domain;
using FuelTrack.UseCases.Messages;
using MediatR;

namespace FuelTrack.UseCases.Handlers
{
    public class GetCarsHandler : IRequestHandler<GetCarsRequest, IReadOnlyCollection<Car>>
    {
        private readonly ICarStore carStore;

        public GetCarsHandler(ICarStore carStore)
        {
            this.carStore = carStore ?? throw new ArgumentNullException(nameof(carStore));
        }

        public async Task<IReadOnlyCollection<Car>> Handle(GetCarsRequest request, CancellationToken cancellationToken)
        {
            return await carStore.GetAllAsync(true).ConfigureAwait(false);
        }
    }
}
