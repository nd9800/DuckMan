using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
namespace Duck.Adapters
{
    class SQLiteHelper
    {
        private readonly string dbName = "t2004e.db";
                
        private static SQLiteHelper sQLiteHelper;
        public static SQLiteHelper GetInstance()
        {
            if(sQLiteHelper==null)
            {
                sQLiteHelper = new SQLiteHelper();
            }
            return sQLiteHelper;
        }
        private SQLiteHelper()
        {
            sQLiteConnection = new SQLiteConnection(dbName);
            CreateCartTable();
        }
        public SQLiteConnection sQLiteConnection { get; private set; }
        public void CreateCartTable()
        {
            var sql_txt = @"CREATE TABLE IF NOT EXISTS Cart(id integer primary key, name varchar(200), image varchar(200), price integer, qty integer)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }
    }
}
