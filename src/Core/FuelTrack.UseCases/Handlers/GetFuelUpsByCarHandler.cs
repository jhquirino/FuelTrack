// -----------------------------------------------------------------------
//  <copyright file="GetFuelUpsByCarHandler.cs" company="Jorge Quirino">
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
    public class GetFuelUpsByCarHandler : IRequestHandler<GetFuelUpsByCarRequest, IReadOnlyCollection<FuelUp>>
    {
        private readonly IFuelUpStore fuelUpStore;

        public GetFuelUpsByCarHandler(IFuelUpStore fuelUpStore)
        {
            this.fuelUpStore = fuelUpStore ?? throw new ArgumentNullException(nameof(fuelUpStore));
        }

        public async Task<IReadOnlyCollection<FuelUp>> Handle(GetFuelUpsByCarRequest request, CancellationToken cancellationToken)
        {
            return await fuelUpStore.GetAllByCarAsync(request?.CarId, true).ConfigureAwait(false);
        }
    }
}