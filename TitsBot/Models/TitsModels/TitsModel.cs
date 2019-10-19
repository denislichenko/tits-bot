using System;
using System.Collections.Generic;
using System.Text;

namespace TitsBot.Models.TitsModels
{
    public class TitsModel
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Size { get; set; }
        public DateTime Updated { get; set; }
    }
}
