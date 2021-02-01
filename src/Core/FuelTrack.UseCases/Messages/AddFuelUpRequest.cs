// -----------------------------------------------------------------------
//  <copyright file="AddFuelUpRequest.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using MediatR;

namespace FuelTrack.UseCases.Messages
{
    public class AddFuelUpRequest : IRequest<AddFuelUpResponse>
    {
        public string CarId { get; }
        public DateTime DateTime { get; }
        public decimal Quantity { get; }
        public decimal Amount { get; }
        public decimal Distance { get; }
        public string Note { get; set; }
        public bool IsPartial { get; set; }

        public AddFuelUpRequest(
            string carId,
            DateTime dateTime,
            decimal quantity,
            decimal amount,
            decimal distance
            )
        {
            CarId = carId;
            DateTime = dateTime;
            Quantity = quantity;
            Amount = amount;
            Distance = distance;
        }
    }
}