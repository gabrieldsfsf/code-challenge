// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiLineLabelEffect.cs" company="ArcTouch LLC">
//   Copyright 2019 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the MultiLineLabelEffect type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using CodeChallenge.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("CodeChallenge")]
[assembly: ExportEffect(typeof(MultiLineLabelEffect), "MultiLineLabelEffect")]
namespace CodeChallenge.iOS.Effects
{
    public class MultiLineLabelEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is UILabel control)
            {
                var effect = (CodeChallenge.Effects.MultiLineLabelEffect)Element.Effects.FirstOrDefault(item => item is CodeChallenge.Effects.MultiLineLabelEffect);
                if (effect != null && effect.Lines > 0)
                {
                    control.Lines = effect.Lines;
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
