﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using osu.Game.Beatmaps;
using osu.Game.Modes.Objects;
using osu.Game.Modes.Osu.Objects;
using System.Collections.Generic;
using osu.Game.Modes.Objects.Types;
using System;
using osu.Game.Modes.Osu.UI;
using osu.Game.Modes.Beatmaps;

namespace osu.Game.Modes.Osu.Beatmaps
{
    internal class OsuBeatmapConverter : BeatmapConverter<OsuHitObject>
    {
        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[] { typeof(IHasPosition) };

        protected override IEnumerable<OsuHitObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            IHasCurve curveData = original as IHasCurve;
            IHasEndTime endTimeData = original as IHasEndTime;
            IHasPosition positionData = original as IHasPosition;
            IHasCombo comboData = original as IHasCombo;

            if (curveData != null)
            {
                yield return new Slider
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    CurveObject = curveData,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
            else if (endTimeData != null)
            {
                yield return new Spinner
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    EndTime = endTimeData.EndTime,

                    Position = positionData?.Position ?? OsuPlayfield.BASE_SIZE / 2,
                };
            }
            else
            {
                yield return new HitCircle
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
        }
    }
}
