using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TitsBot.Models;
using TitsBot.Models.TitsModels;

namespace TitsBot.Events
{
    public static class TitsCommands
    {
        public static string GetStatistic()
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var list = context.Tits.OrderByDescending(x => x.Size).ToList();
                var str = "Самые большие сиськи:\n";
                var i = 1; 
                foreach(var item in list)
                {
                    str += $"{i}. @{item.UserName} : {item.Size.ToString()} размер\n";
                    i++; 
                }

                return str; 
            }
        }

        public static async Task<string> GenerateNewResultAsync(Message message)
        {
            using(ApplicationContext context = new ApplicationContext())
            {
                var tits = context.Tits.Where(x => x.UserId == message.From.Id).FirstOrDefault();
                if(tits != null && tits.Updated.Date == DateTime.Now.Date) return "Нельзя так часто играть с сиськами!!!";

                var rnd = new Random();
                var sizeAdded = rnd.Next(-10, 10);
                if (tits != null)
                {
                    tits.Size += sizeAdded;
                    tits.Updated = DateTime.Now.Date; 
                }
                else
                {
                    await context.Tits.AddAsync(new TitsModel
                    {
                        ChatId = message.Chat.Id,
                        UserId = message.From.Id,
                        UserName = message.From.Username,
                        Size = sizeAdded,
                        Updated = DateTime.Now.Date
                    });
                }
                await context.SaveChangesAsync();
                return $"Твои сиськи увеличились на {sizeAdded} размера!"; 
            }
        }
    }
}
