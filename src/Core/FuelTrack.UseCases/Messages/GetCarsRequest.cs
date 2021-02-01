// -----------------------------------------------------------------------
//  <copyright file="GetCarsRequest.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System.Collections.Generic;
using FuelTrack.Domain;
using MediatR;

namespace FuelTrack.UseCases.Messages
{
    public class GetCarsRequest : IRequest<IReadOnlyCollection<Car>>
    {
    }
}
