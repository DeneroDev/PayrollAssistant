using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace PayrollAssistant
{
    class DBHelper
    {
        private const string TABLE_NAME = "Работники";
        private SQLiteConnection DB;

        public static DBHelper instance;
        public static DBHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DBHelper();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        DBHelper() {
       }

        public void connectDB() {
            DB = new SQLiteConnection("DataSource=MainBD.sqlite;Version=3");
            if (DB != null)
            {
                DB.Open();
            }
            else
            {
                SQLiteConnection.CreateFile("MainBD.sqlite");
                SQLiteConnection m_dbConnection = new SQLiteConnection("DataSource=MainBD.sqlite;Version=3;");
                m_dbConnection.Open();
                string sql = "CREATE TABLE Работники (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,Имя VARCHAR(50)  NULL,ДатаПоступления VARCHAR  NULL,Группа VARCHAR  NULL,Подчиненные VARCHAR  NULL,Начальник VARCHAR  NULL)";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }
        
        }

        public void CloseDB()
        {
            if (DB != null)
                 DB.Close();
        }

        public void LoadAllElementDB() {
            if (DB != null)
            {
                CasheAllWolkerHelper.GetInstance().ClearAllWorker();
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "select * from " + TABLE_NAME;
                // SQLiteDataReader dr = CMD.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                SQLiteDataAdapter da = new SQLiteDataAdapter(CMD.CommandText, DB);
                DataSet ds = new System.Data.DataSet();
                da.Fill(ds);
                DataTable dtable = ds.Tables[0];
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    DataRow drow = dtable.Rows[i];
                    if (drow.RowState != DataRowState.Deleted)
                    {
                        Enum.TryParse(drow["Группа"].ToString(), out Worker.Group currentGroup);

                        CurrentWorker worker = new CurrentWorker(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                       , DateTime.Parse(drow["ДатаПоступления"].ToString())
                       , currentGroup);
                        
                        CasheAllWolkerHelper.GetInstance().AddWorker(worker);
                        if (drow["Подчиненные"].ToString() != "") {
                            string[] ids = drow["Подчиненные"].ToString().Split(',');
                            for (int j = 0; j < ids.Length; j++) {
                                    worker.Idssubb.Add(ids[j]);
                            } 
                        }
                        if (drow["Начальник"].ToString() != "-")
                        {
                            worker.Idchief = drow["Начальник"].ToString();
                        }
                  //      Console.WriteLine("ID_ADDED:" + worker.GetID());
                    }
                }

                CasheAllWolkerHelper.GetInstance().CalculateChiefAndSub();
            }
        }


        public void SaveResult(List<Worker> allWorkers) {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "delete from " + TABLE_NAME;
            CMD.ExecuteNonQuery();
            CMD.CommandText = "delete from sqlite_sequence where name='Работники'";
            CMD.ExecuteNonQuery();
            for (int i = 0; i < allWorkers.Count; i++) {
                AddWorker(allWorkers[i]);
            }
        }

        public void AddWorker(Worker worker) {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "insert into "+TABLE_NAME+"(Имя,ДатаПоступления,Группа,Подчиненные,Начальник)" +
                " values( @name , @date , @group , @subordinate , @chief )";
            CMD.Parameters.Add("@name", DbType.String).Value = worker.GetName();
            CMD.Parameters.Add("@date", DbType.String).Value = worker.GetDate().ToShortDateString();
            CMD.Parameters.Add("@group", DbType.String).Value = worker.GetCurrentGroup().ToString();

            if (worker.GetSubbordinate() != null) {
                string summ = "";
                int countSubb = worker.GetSubbordinate().Count;
                for (int i = 0; i < countSubb; i++) {
                    if ((i + 1) < countSubb)
                        summ += worker.GetSubbordinate()[i].GetID().ToString() + ",";
                    else
                        summ += worker.GetSubbordinate()[i].GetID().ToString();
                }
                  
              //  Console.WriteLine(summ + "-SUM_SPLIT");
                CMD.Parameters.Add("@subordinate", DbType.String).Value = summ;
            }
            else
                CMD.Parameters.Add("@subordinate", DbType.String).Value = "-";

            if (worker.GetChief()!=null)
                CMD.Parameters.Add("@chief", DbType.String).Value = worker.GetChief().GetID();
            else
                CMD.Parameters.Add("@chief", DbType.String).Value = "-";

            CMD.ExecuteNonQuery();

        }

        public Worker GetWorkerUseID(int id) {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "select * from " + TABLE_NAME +" where ID like '%' || @id";
            CMD.Parameters.Add("@id", System.Data.DbType.Int32).Value = id;
            SQLiteDataReader drow = CMD.ExecuteReader();
            if (drow.HasRows)
            {
                while (drow.Read()) {
                    Enum.TryParse(drow["Группа"].ToString(), out Worker.Group currentGroup);
                    CurrentWorker worker = new CurrentWorker(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                  , DateTime.Parse(drow["ДатаПоступления"].ToString())
                  , currentGroup);  
                    return worker;
                }
                return null;
            }
            else
                return null;
           
        }

    }
}
