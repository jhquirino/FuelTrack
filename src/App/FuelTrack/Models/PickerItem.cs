// -----------------------------------------------------------------------
//  <copyright file="PickerItem.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
namespace FuelTrack.Models
{
    /// <summary>
    /// Class to represent an item in <see cref="Xamarin.Forms.Picker"/>.
    /// </summary>
    /// <typeparam name="T">Type of item id.</typeparam>
    public class PickerItem<T>
    {
        /// <summary>
        /// Item ID.
        /// </summary>
        public T Id { get; set; }

        /// <summary>
        /// Text to display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PickerItem{T}"/> class.
        /// </summary>
        /// <param name="id">Item id.</param>
        /// <param name="text">Text to display.</param>
        public PickerItem(T id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
