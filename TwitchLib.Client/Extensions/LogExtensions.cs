﻿#pragma warning disable SYSLIB1006 // Multiple logging methods cannot use the same event id within a class
using System;
using Microsoft.Extensions.Logging;

namespace TwitchLib.Client.Extensions;

internal static partial class LogExtensions
{
    [LoggerMessage(-1, LogLevel.Information, "Connecting Twitch Chat Client...")]
    public static partial void LogConnecting(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Information, "Disconnecting Twitch Chat Client...")]
    public static partial void LogDisconnecting(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Information, "TwitchLib-TwitchClient initialized, assembly version: {version}")]
    public static partial void LogInitialized(this ILogger<TwitchClient> logger, Version version);

    [LoggerMessage(-1, LogLevel.Information, "Joining channel: {channel}")]
    public static partial void LogJoiningChannel(this ILogger<TwitchClient> logger, string channel);

    [LoggerMessage(-1, LogLevel.Debug, "Finished channel joining queue.")]
    public static partial void LogChannelJoiningFinished(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Information, "Leaving channel: {channel}")]
    public static partial void LogLeavingChannel(this ILogger<TwitchClient> logger, string channel);

    [LoggerMessage(-1, LogLevel.Error, "Message length has exceeded the maximum character count. (500)")]
    public static partial void LogMessageTooLong(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Trace, "Received: {line}")]
    public static partial void LogReceived(this ILogger<TwitchClient> logger, string line);

    [LoggerMessage(-1, LogLevel.Information, "Reconnecting to Twitch")]
    public static partial void LogReconnecting(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Debug, "Should be connected!")]
    public static partial void LogShouldBeConnected(this ILogger<TwitchClient> logger);

    [LoggerMessage(-1, LogLevel.Warning, "Unaccounted for: {ircString} (please create a TwitchLib GitHub issue :P)")]
    public static partial void LogUnaccountedFor(this ILogger<TwitchClient> logger, string ircString);

    [LoggerMessage(-1, LogLevel.Debug, "Writing: {message}")]
    public static partial void LogWriting(this ILogger<TwitchClient> logger, string message);

    [LoggerMessage(-1, LogLevel.Error, "{message}")]
    public static partial void LogException(this ILogger logger, string message, Exception ex);
}
