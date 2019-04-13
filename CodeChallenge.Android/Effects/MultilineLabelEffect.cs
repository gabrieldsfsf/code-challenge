// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultilineLabelEffect.cs" company="ArcTouch LLC">
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
//   Defines the MultilineLabelEffect type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using Android.Widget;
using CodeChallenge.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("CodeChallenge")]
[assembly: ExportEffect(typeof(MultiLineLabelEffect), "MultiLineLabelEffect")]
namespace CodeChallenge.Droid.Effects
{
    public class MultiLineLabelEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is TextView control)
            {
                var effect = (CodeChallenge.Effects.MultiLineLabelEffect)Element.Effects.FirstOrDefault(item => item is CodeChallenge.Effects.MultiLineLabelEffect);
                if (effect != null && effect.Lines > 0)
                {
                    if (effect.Lines == 1)
                    {
                        control.SetSingleLine(true);
                    }
                    else
                    {
                        control.SetSingleLine(false);
                        control.SetLines(effect.Lines);
                    }
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
