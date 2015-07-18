//-----------------------------------------------------------------------------
// 
//  Tetris game for .NET Micro Framework
//
//  http://bansky.net/blog
// 
// This code was written by Pavel Bansky. It is released under the terms of 
// the Creative Commons "Attribution NonCommercial ShareAlike 2.5" license.
// http://creativecommons.org/licenses/by-nc-sa/2.5/
//-----------------------------------------------------------------------------

using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;

namespace MicroTetris.Presentation
{
    /// <summary>
    /// StackPanel with gradient brush background
    /// </summary>
    public class GradientStackPanel : StackPanel
    {
        Brush gradientBrush, solidBrush;       
        Color startColor, endColor;       

        /// <summary>
        /// Creates new gradient stack panel
        /// </summary>
        /// <param name="orientation">Stack orientation</param>
        /// <param name="startColor">Gradient start color</param>
        /// <param name="endColor">Gradient stop color</param>
        public GradientStackPanel(Orientation orientation, Color startColor, Color endColor) : base(orientation)
        {            
            this.startColor = startColor;
            this.endColor = endColor;
            this.solidBrush = new SolidColorBrush(ColorUtility.ColorFromRGB(164, 164, 164));
        }        

        public override void OnRender(Microsoft.SPOT.Presentation.Media.DrawingContext dc)
        {
            // Saving performance create fill brush only once
            if (gradientBrush == null)
                gradientBrush = new LinearGradientBrush(startColor, endColor, 0, this.Height / 2, 0, this.Height);

            // Gradient fill
            dc.DrawRectangle(gradientBrush, null , 0, 0, this.Width, this.Height);

            // Left line separator
            dc.DrawRectangle(solidBrush, null, 0, 0, 2, this.Height);
        }
    }
}
