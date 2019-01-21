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
                SQLiteCommand CMD = new SQLiteCommand(DB);
                CMD.CommandText = "select * from " + TABLE_NAME;
                try
                {
                    CMD.ExecuteNonQuery();
                }
                catch (Exception e) {
                    string sql = "CREATE TABLE Работники (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,Имя VARCHAR(50)  NULL,ДатаПоступления VARCHAR  NULL,Группа VARCHAR  NULL,Подчиненные VARCHAR  NULL,Начальник VARCHAR  NULL)";
                    SQLiteCommand command = new SQLiteCommand(sql, DB);
                    command.ExecuteNonQuery();
                }
               
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
                CasheAllWorkerHelper.GetInstance().ClearAllWorker();
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
                        Worker worker;
                        switch (currentGroup) {
                            case Worker.Group.Employee:
                              worker = new Employee(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                       , DateTime.Parse(drow["ДатаПоступления"].ToString())
                       , currentGroup);
                                break;
                            case Worker.Group.Manager:
                                worker = new Manager(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                       , DateTime.Parse(drow["ДатаПоступления"].ToString())
                       , currentGroup);
                                break;
                            case Worker.Group.Salesman:
                                worker = new Salesman(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                       , DateTime.Parse(drow["ДатаПоступления"].ToString())
                       , currentGroup);
                                break;
                            default:
                                worker = new Employee(int.Parse(drow["ID"].ToString()), drow["Имя"].ToString()
                      , DateTime.Parse(drow["ДатаПоступления"].ToString())
                      , currentGroup);
                                break;
                        }
              
             
                        
                        CasheAllWorkerHelper.GetInstance().AddWorker(worker);
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

                CasheAllWorkerHelper.GetInstance().CalculateChiefAndSub();
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
            CMD.Parameters.Add("@name", DbType.String).Value = worker.Name;
            CMD.Parameters.Add("@date", DbType.String).Value = worker.Date.ToShortDateString();
            CMD.Parameters.Add("@group", DbType.String).Value = worker.CurrentGroup.ToString();
            CMD.Parameters.Add("@subordinate", DbType.String).Value = SubordinateConcatenation(worker);
            CMD.Parameters.Add("@chief", DbType.String).Value = CheckAvailabilityChief(worker);
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


        public void UpdateWorker(Worker updateWorker) {
            SQLiteCommand CMD = DB.CreateCommand();
            
            CMD.CommandText = "update " + TABLE_NAME + " set Имя = @name, ДатаПоступления = @date, Группа = @group, Подчиненные = @subordinate, Начальник = @chief where ID = @id";
            CMD.Parameters.Add("@id", DbType.String).Value = updateWorker.Id;
            CMD.Parameters.Add("@name", DbType.String).Value = updateWorker.Name;
            CMD.Parameters.Add("@date", DbType.String).Value = updateWorker.Date.ToShortDateString();
            CMD.Parameters.Add("@group", DbType.String).Value = updateWorker.CurrentGroup.ToString();
            CMD.Parameters.Add("@subordinate", DbType.String).Value = SubordinateConcatenation(updateWorker);
            CMD.Parameters.Add("@chief", DbType.String).Value = CheckAvailabilityChief(updateWorker);
            Console.WriteLine($"ID: {updateWorker.Id} / Name:{updateWorker.Name} /");
            CMD.ExecuteNonQuery();
        }

        public void DeleteWorker(Worker deleteWorker)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "delete from " + TABLE_NAME + " where ID = @id";
            CMD.Parameters.Add("@id", DbType.String).Value = deleteWorker.Id;
            CMD.ExecuteNonQuery();
        }

        private string SubordinateConcatenation(Worker worker) {
            if (worker.Subbordinate != null)
            {
                string summ = "";
                int countSubb = worker.Subbordinate.Count;
                for (int i = 0; i < countSubb; i++)
                {
                    if ((i + 1) < countSubb)
                        summ += worker.Subbordinate[i].Id.ToString() + ",";
                    else
                        summ += worker.Subbordinate[i].Id.ToString();
                }
                return summ;          
            }
            else
                return "-";
        }


        private string CheckAvailabilityChief(Worker worker) {
            if (worker.Chief != null)
                return worker.Chief.Id.ToString();
            else
                return "-";
        }
    }
}
