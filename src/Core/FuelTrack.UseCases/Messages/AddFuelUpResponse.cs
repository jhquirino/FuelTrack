// -----------------------------------------------------------------------
//  <copyright file="AddFuelUpResponse.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.UseCases.Messages
{
    public class AddFuelUpResponse
    {
        public bool Success { get; }
        public string Id { get; }
        public string CarId { get; }

        public AddFuelUpResponse(bool success, string id, string carId)
        {
            Success = success;
            Id = id;
            CarId = carId;
        }
    }
}