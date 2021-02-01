// -----------------------------------------------------------------------
//  <copyright file="IEnvironment.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System.Drawing;

namespace FuelTrack.Interfaces
{
    public interface IEnvironment
    {
        void SetStatusBarColor(Color color, bool darkStatusBarTint);
    }
}
