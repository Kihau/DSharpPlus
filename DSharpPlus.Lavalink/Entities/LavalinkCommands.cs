// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2022 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#nullable enable
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DSharpPlus.Lavalink.Entities
{
    internal sealed class LavalinkConfigureResume : LavalinkPayload
    {
        [JsonProperty("key")]
        public string Key { get; }

        [JsonProperty("timeout")]
        public int Timeout { get; }

        public LavalinkConfigureResume(string key, int timeout)
            : base("configureResuming")
        {
            this.Key = key;
            this.Timeout = timeout;
        }
    }

    internal sealed class LavalinkDestroy : LavalinkPayload
    {
        public LavalinkDestroy(LavalinkGuildConnection lvl)
            : base("destroy", lvl.GuildIdString)
        { }
    }

    internal sealed class LavalinkPlay : LavalinkPayload
    {
        [JsonProperty("track")]
        public string Track { get; }

        public LavalinkPlay(LavalinkGuildConnection lvl, LavalinkTrack track)
            : base("play", lvl.GuildIdString)
        {
            this.Track = track.TrackString;
        }
    }

    internal sealed class LavalinkPlayPartial : LavalinkPayload
    {
        [JsonProperty("track")]
        public string Track { get; }

        [JsonProperty("startTime")]
        public long StartTime { get; }

        [JsonProperty("endTime")]
        public long StopTime { get; }

        public LavalinkPlayPartial(LavalinkGuildConnection lvl, LavalinkTrack track, TimeSpan start, TimeSpan stop)
            : base("play", lvl.GuildIdString)
        {
            this.Track = track.TrackString;
            this.StartTime = (long)start.TotalMilliseconds;
            this.StopTime = (long)stop.TotalMilliseconds;
        }
    }

    internal sealed class LavalinkPause : LavalinkPayload
    {
        [JsonProperty("pause")]
        public bool Pause { get; }

        public LavalinkPause(LavalinkGuildConnection lvl, bool pause)
            : base("pause", lvl.GuildIdString)
        {
            this.Pause = pause;
        }
    }

    internal sealed class LavalinkStop : LavalinkPayload
    {
        public LavalinkStop(LavalinkGuildConnection lvl)
            : base("stop", lvl.GuildIdString)
        { }
    }

    internal sealed class LavalinkSeek : LavalinkPayload
    {
        [JsonProperty("position")]
        public long Position { get; }

        public LavalinkSeek(LavalinkGuildConnection lvl, TimeSpan position)
            : base("seek", lvl.GuildIdString)
        {
            this.Position = (long)position.TotalMilliseconds;
        }
    }

    internal sealed class LavalinkVolume : LavalinkPayload
    {
        [JsonProperty("volume")]
        public int Volume { get; }

        public LavalinkVolume(LavalinkGuildConnection lvl, int volume)
            : base("volume", lvl.GuildIdString)
        {
            this.Volume = volume;
        }
    }

    public class Karaoke
    {
        [JsonProperty("level")]
        public double Level { get; set; }

        [JsonProperty("monoLevel")]
        public double MonoLevel { get; set; }

        [JsonProperty("filterBand")]
        public double FilterBand { get; set; }

        [JsonProperty("filterWidth")]
        public double FilterWidth { get; set; }
    }

    public class TimeScale
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("pitch")]
        public double Pitch { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }
    }

    public class Tremolo
    {
        [JsonProperty("frequency")]
        public double Frequency { get; set; }

        [JsonProperty("depth")]
        public double Depth { get; set; }
    }

    public class Vibrato
    {
        [JsonProperty("frequency")]
        public double Frequency { get; set; }

        [JsonProperty("depth")]
        public double Depth { get; set; }
    }

    public class Rotation
    {
        [JsonProperty("rotationHz")]
        public double RotationFreq { get; set; }
    }

    public class Distortion
    {
        [JsonProperty("sinOffset")]
        public double SinOffset { get; set; }

        [JsonProperty("sinScale")]
        public double SinScale { get; set; }

        [JsonProperty("cosOffset")]
        public double CosOffset { get; set; }

        [JsonProperty("cosScale")]
        public double CosScale { get; set; }

        [JsonProperty("tanOffset")]
        public double TanOffset { get; set; }

        [JsonProperty("tanScale")]
        public double TanScale { get; set; }

        [JsonProperty("offset")]
        public double Offset { get; set; }

        [JsonProperty("scale")]
        public double Scale { get; set; }
    }

    public class ChannelMix
    {
        [JsonProperty("leftToLeft")]
        public double LeftToLeft { get; set; }

        [JsonProperty("leftToRight")]
        public double LeftToRight { get; set; }

        [JsonProperty("rightToLeft")]
        public double RightToLeft { get; set; }

        [JsonProperty("rightToRight")]
        public double RightToRight { get; set; }
    }

    public class LowPass
    {
        [JsonProperty("smoothing")]
        public double Smoothing { get; set; }
    }

    public class AudioFilters
    {
        public Karaoke? Karaoke { get; set; }
        public TimeScale? Timescale { get; set; }
        public Tremolo? Tremolo { get; set; }
        public Vibrato? Vibrato { get; set; }
        public Rotation? Rotation { get; set; }
        public Distortion? Distortion { get; set; }
        public ChannelMix? Channelmix { get; set; }
        public LowPass? Lowpass { get; set; }
    }

    internal sealed class LavalinkAudiofilters : LavalinkPayload
    {
        [JsonProperty("karaoke")]
        public Karaoke? Karaoke { get; }

        [JsonProperty("timescale")]
        public TimeScale? Timescale { get; }

        [JsonProperty("tremolo")]
        public Tremolo? Tremolo { get; }

        [JsonProperty("vibrato")]
        public Vibrato? Vibrato { get; }

        [JsonProperty("rotation")]
        public Rotation? Rotation { get; }

        [JsonProperty("distortion")]
        public Distortion? Distortion { get; }

        [JsonProperty("channelMix")]
        public ChannelMix? Channelmix { get; }

        [JsonProperty("lowPass")]
        public LowPass? Lowpass { get; }

        public LavalinkAudiofilters(LavalinkGuildConnection lvl, AudioFilters filters)
            : base("filters", lvl.GuildIdString)
        {
            this.Karaoke = filters.Karaoke;
            this.Timescale = filters.Timescale;
            this.Tremolo = filters.Tremolo;
            this.Vibrato = filters.Vibrato;
            this.Rotation = filters.Rotation;
            this.Distortion = filters.Distortion;
            this.Channelmix = filters.Channelmix;
            this.Lowpass = filters.Lowpass;
        }
    }

    internal sealed class LavalinkTimescale : LavalinkPayload
    {
        [JsonProperty("timescale")]
        public TimeScale Scale { get; }

        public LavalinkTimescale(LavalinkGuildConnection lvl, TimeScale scale)
            : base("filters", lvl.GuildIdString)
        {
            this.Scale = scale;
        }
    }

    internal sealed class LavalinkEqualizer : LavalinkPayload
    {
        [JsonProperty("bands")]
        public IEnumerable<LavalinkBandAdjustment> Bands { get; }

        public LavalinkEqualizer(LavalinkGuildConnection lvl, IEnumerable<LavalinkBandAdjustment> bands)
            : base("equalizer", lvl.GuildIdString)
        {
            this.Bands = bands;
        }
    }
}
