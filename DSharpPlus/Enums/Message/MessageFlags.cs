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

using System;

namespace DSharpPlus
{
    public static class MessageFlagExtensions
    {
        /// <summary>
        /// Calculates whether these message flags contain a specific flag.
        /// </summary>
        /// <param name="baseFlags">The existing flags.</param>
        /// <param name="flag">The flags to search for.</param>
        /// <returns></returns>
        public static bool HasMessageFlag(this MessageFlags baseFlags, MessageFlags flag) => (baseFlags & flag) == flag;
    }

    /// <summary>
    /// Represents additional features of a message.
    /// </summary>
    [Flags]
    public enum MessageFlags
    {
        /// <summary>
        /// Whether this message is the original message that was published from a news channel to subscriber channels.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        Crossposted = 1 << 0,

        /// <summary>
        /// Whether this message is crossposted (automatically posted in a subscriber channel).
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        IsCrosspost = 1 << 1,

        /// <summary>
        /// Whether any embeds in the message are hidden.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        SuppressedEmbeds = 1 << 2,

        /// <summary>
        /// The source message for this crosspost has been deleted.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        SourceMessageDeleted = 1 << 3,

        /// <summary>
        /// The message came from the urgent message system.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        Urgent = 1 << 4,

        /// <summary>
        /// The message is only visible to the user who invoked the interaction.
        /// </summary>
        Ephemeral = 1 << 6,

        /// <summary>
        /// The message is an interaction response and the bot is "thinking".
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        Loading = 1 << 7,

        /// <summary>
        /// Indicates that some roles mentioned in the message could not be added to the current thread.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        FailedToMentionSomeRolesInThread = 1 << 8,

        /// <summary>
        /// Indicates that the message contains a link (usually to a file) that will prompt the user
        /// with a precautionary message saying that the link may be unsafe.
        /// </summary>
        /// <remarks>This flag is inbound only (it cannot be set).</remarks>
        ContainsSuspiciousThirdPartyLink = 1 << 10,

        /// <summary>
        /// Indicates that this message will supress push notifications.
        /// Mentions in the message will still have a mention indicator, however.
        /// </summary>
        SupressNotifications = 1 << 12
    }
}
