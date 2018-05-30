using System;
using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;


namespace TwetMemo
{
    public class TwitterDatabase
    {
        static readonly object Locker = new object(); // <-1
        readonly SQLiteConnection _db; // <-2

        public TwitterDatabase()
        {
            _db = DependencyService.Get<ISQLite>().GetConnection(); // <-3
            _db.CreateTable<TwItem>(); // <-4
        }

        public IEnumerable<TwItem> GetItems()
        { // <-5
            lock (Locker)
            { // <-6
              // Delete==falseの一覧を取得する（削除フラグが立っているものは対象外）
                return _db.Table<TwItem>().OrderByDescending(nnn => nnn.saveTime); // <-7
            }
        }

        public void DeleteItem(TwItem item){
            lock(Locker){
                _db.Delete(item);
            }
        }


        public void SaveData(TwItem item){
            lock(Locker){
                _db.Insert(item);
            }
        }

        /*
        public int SaveItem(TwItem item)
        { // <-8
            lock (Locker)
            { // <-9
                if (item.Id != 0)
                { // Idが0でない場合は、更新
                    _db.Update(item); // <-10
                    return item.Id;
                }
                return _db.Insert(item); // <-11
            }
        }
        */

    }
}
