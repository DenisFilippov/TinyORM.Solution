using SQLitePCL;
using TinyORM.Core;

namespace TinyORM.Sqlite;

public static class SqliteContextExt
{
  public static void SqliteInitialize(this Context context)
  {
    raw.SetProvider(new SQLite3Provider_e_sqlite3());
  }
}