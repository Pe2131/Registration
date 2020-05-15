using Microsoft.Extensions.Configuration;
using Service.Telegram.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Service.Telegram.Service
{
    public class TelegramService : ITelegramService
    {
        private readonly IConfiguration _conf;
        TelegramBotClient bot;
        public TelegramService(IConfiguration configuration)
        {
            _conf = configuration;
            bot = new TelegramBotClient(_conf["Telegram:BotId"]);
        }

        public async Task SendMessage(string ChatId, string Text)
        {
            try
            {
                await bot.SendTextMessageAsync(ChatId, Text, parseMode: ParseMode.Html);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
