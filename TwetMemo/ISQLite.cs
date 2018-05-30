using System;
using SQLite.Net;

namespace TwetMemo
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
