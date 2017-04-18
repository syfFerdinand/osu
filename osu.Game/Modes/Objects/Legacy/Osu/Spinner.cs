﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Modes.Objects.Types;
using OpenTK;

namespace osu.Game.Modes.Objects.Legacy.Osu
{
    /// <summary>
    /// Legacy osu! Spinner-type, used for parsing Beatmaps.
    /// </summary>
    internal sealed class Spinner : HitObject, IHasEndTime, IHasPosition
    {
        public double EndTime { get; set; }

        public double Duration => EndTime - StartTime;

        public Vector2 Position { get; set; }

        public float X => Position.X;

        public float Y => Position.Y;
    }
}
