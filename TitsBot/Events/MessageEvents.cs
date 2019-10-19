using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TitsBot.Models;

namespace TitsBot.Events
{
    public static class MessageEvents
    {
        public async static void OnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var botClient = Bot.GetBotClient();
            var me = botClient.GetMeAsync().Result;
            var userName = $"@{me.Username}"; 

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split('@').First())
            {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Started!", replyToMessageId: message.MessageId);
                    break;
                case "/tits":
                    await botClient.SendTextMessageAsync(message.Chat.Id, await TitsCommands.GenerateNewResultAsync(message), replyToMessageId: message.MessageId);
                    break;
                case "/stats":
                    await botClient.SendTextMessageAsync(message.Chat.Id, TitsCommands.GetStatistic(), replyToMessageId: message.MessageId);
                    break;
            }
        }
    }
}
