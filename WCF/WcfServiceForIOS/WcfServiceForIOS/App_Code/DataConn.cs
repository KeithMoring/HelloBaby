using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WcfServiceForIOS
{
    /// <summary>
    /// 连接数据库,name存储过程的输入字符名称,pvalue存储过程的输入变量
    /// </summary>
    /// 
    public struct sqlparameters
    {
        public string name;//存储过程的输入字符名称
        public object pvalue;//存储过程的输入变量
        public sqlparameters(string names, object pvalues)
        {
            name = names;
            pvalue = pvalues;
        }
    }

    public class DataConn
    {
        private MySqlCommand cmm;
        private MySqlConnection conn;
        public DataConn()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //

            string connStr = "Database=fateapp;DataSource=127.0.0.1;User=root;Password=xxffate;Port=3306;";
            conn = new MySqlConnection(connStr);
            cmm = new MySqlCommand();

        }
        /// <summary>
        /// 支持SQL查询，返回DataTable类型
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable SQLGetDataTale(string sql)
        {
            conn.Open();
            MySqlDataAdapter datareader = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            datareader.Fill(dt);

            conn.Close();
            return dt;
        }

        /// <summary>
        /// 调用存储过程，参数名和值，无返回值类型
        /// </summary>
        /// <param name="Stroedname">存储过程名称</param>
        /// <param name="Parameters">Parameters.name,Parameters.pvalue</param>
        public void StroedGet(string Stroedname, List<sqlparameters> Parameters)
        {

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(Stroedname, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Parameters.Count; i++)
            {
                cmd.Parameters.AddWithValue(Parameters[i].name, Parameters[i].pvalue);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        /// <summary>
        /// 返回DataTable类型的存储过程，带参数输入
        /// </summary>
        /// <param name="StoredName"></param>
        /// <param name="Parameters"></param>
        /// <returns>DataTable类型</returns>
        public DataTable StroedGetTable(string StoredName, List<sqlparameters> Parameters)
        {

            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand();
            mysqldata.SelectCommand.CommandText = StoredName;
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            mysqldata.SelectCommand.Connection = conn;
            for (int i = 0; i < Parameters.Count; i++)
            {
                mysqldata.SelectCommand.Parameters.AddWithValue(Parameters[i].name, Parameters[i].pvalue);
            }
            DataTable dt = new DataTable();
            mysqldata.Fill(dt);
            // conn.Close();
            return dt;

        }
        /// <summary>
        /// 返回DataTable类型的存储过程
        /// </summary>
        /// <param name="StoredName"></param>
        /// <returns></returns>
        public DataTable StroedGetTable(string StoredName)
        {
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();
            mysqldata.SelectCommand = new MySqlCommand();
            mysqldata.SelectCommand.CommandText = StoredName;
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            mysqldata.SelectCommand.Connection = conn;
            DataTable dt = new DataTable();
            mysqldata.Fill(dt);
            // conn.Close();
            return dt;
        }

        public string getdata(string mysqlout, List<sqlparameters> Parameters, string typeStr, int returnsize, string StoreName)
        {


            conn.Open();
            MySqlCommand cmd = new MySqlCommand(StoreName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            switch (typeStr)
            {
                case "int":
                    cmd.Parameters.Add(mysqlout, MySqlDbType.Int32, returnsize);
                    break;
                case "string":
                    cmd.Parameters.Add(mysqlout, MySqlDbType.VarChar, returnsize);
                    break;
            }
            cmd.Parameters[mysqlout].Direction = ParameterDirection.Output;
            for (int i = 0; i < Parameters.Count; i++)
            {
                cmd.Parameters.AddWithValue(Parameters[i].name, Parameters[i].pvalue);
            }
            cmd.ExecuteNonQuery();

            string name = cmd.Parameters[mysqlout].Value.ToString();

            // cmd.CommandText = "sp_xxxxx";
            // cmd.Parameters.Add("_xxxx", MySqlDbType.Int32, 11);
            //注意输出参数要设置大小,否则size默认为0,
            //  cmd.Parameters.Add("_FLAG", MySqlDbType.Int32, 11);
            //设置参数的类型为输出参数,默认情况下是输入,

            //为参数赋值
            // cmd.Parameters["_xxxxx"].Value = 81;
            //  cmd.Connection = conn;
            //执行

            //得到输出参数的值,把赋值给name,注意,这里得到的是object类型的,要进行相应的类型轮换
            //  string name = cmd.Parameters["_FLAG"].Value.ToString();

            return name;

        }
    }
}