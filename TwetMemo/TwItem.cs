using System;
using SQLite.Net.Attributes;
namespace TwetMemo
{
    public class TwItem
    {
        //必要なプロパティ一覧
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } 

        public string UserName { get; set; }
        public string CreateDay { get; set; }
        public string Text { get; set; }

        public DateTime saveTime { get; set; }

    }
}
