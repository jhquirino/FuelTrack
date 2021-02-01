// -----------------------------------------------------------------------
//  <copyright file="AddCarResponse.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.UseCases.Messages
{
    public class AddCarResponse
    {
        public bool Success { get; }
        public string Id { get; }
        public string Alias { get; }

        public AddCarResponse(bool success, string id, string alias)
        {
            Success = success;
            Id = id;
            Alias = alias;
        }
    }
}
