// -----------------------------------------------------------------------
//  <copyright file="AddCarRequest.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using FuelTrack.Domain;
using MediatR;

namespace FuelTrack.UseCases.Messages
{
    public class AddCarRequest : IRequest<AddCarResponse>
    {
        public string Alias { get; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public ushort Year { get; set; }
        public string Plate { get; set; }
        public FuelType FuelType { get; set; }
        public string Note { get; set; }

        public AddCarRequest(string alias)
        {
            Alias = alias;
        }
    }
}
