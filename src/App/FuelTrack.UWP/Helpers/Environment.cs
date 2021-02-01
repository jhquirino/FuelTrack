// -----------------------------------------------------------------------
//  <copyright file="Environment.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using FuelTrack.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FuelTrack.UWP.Helpers.Environment))]
namespace FuelTrack.UWP.Helpers
{
    public class Environment : IEnvironment
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
        }
    }
}