using Microsoft.Extensions.Logging;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

var loggerFactory = LoggerFactory.Create(c => c
    .AddConsole()
  .SetMinimumLevel(LogLevel.Trace) // uncomment to view raw messages received from twitch
);
var logger = loggerFactory.CreateLogger("MyChatBot");

var credentials = new ConnectionCredentials(); // anonymous user, add username and OAuth token to get the ability to send messages
var client = new TwitchClient(loggerFactory: loggerFactory);

client.Initialize(credentials);
client.OnConnected += Client_OnConnected;
client.OnJoinedChannel += Client_OnJoinedChannel;
client.OnMessageReceived += Client_OnMessageReceived;

client.OnNewSubscriber += Client_OnNewSubscriber;
client.OnReSubscriber += Client_OnReSubscriber;

await client.ConnectAsync();
await Task.Delay(Timeout.Infinite);


async Task Client_OnConnected(object sender, OnConnectedEventArgs e)
{
    await client.JoinChannelAsync("channel_name");
}

async Task Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
{
    await client.SendMessageAsync(e.Channel, "Hey guys! I am a bot connected via TwitchLib!");
}

async Task Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
{
    logger.LogInformation($"{e.ChatMessage.Username}#{e.ChatMessage.Channel}: {e.ChatMessage.Message}");
}

async Task Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
{
    if (e.Subscriber.MsgParamSubPlan == SubscriptionPlan.Prime)
        await client.SendMessageAsync(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
    else
        await client.SendMessageAsync(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
}

async Task Client_OnReSubscriber(object? sender, OnReSubscriberArgs e)
{
    if (e.ReSubscriber.MsgParamSubPlan == SubscriptionPlan.Prime)
        await client.SendMessageAsync(e.Channel, $"Hi {e.ReSubscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
    else
        await client.SendMessageAsync(e.Channel, $"Hi {e.ReSubscriber.DisplayName} to the substers! You just earned 500 points!");
}
