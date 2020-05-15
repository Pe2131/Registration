using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Telegram.InterFace
{
   public interface ITelegramService
    {
        Task SendMessage(string ChatId, string Text);
    }
}
