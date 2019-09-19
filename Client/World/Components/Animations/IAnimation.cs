using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.World.Components.Animations
{
    internal interface IAnimation
    {
        int AnimationSpeed { get; set; }
        Rectangle GetNewAnimationState();
    }
}
