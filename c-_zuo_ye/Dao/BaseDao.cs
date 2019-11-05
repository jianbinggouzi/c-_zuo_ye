﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Dao
{
    class BaseDao<T>
    {
        private static string connString = "";
        private SqlConnection conn = new SqlConnection(connString);

        public int executeNonQuery(string sql,string[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            SqlCommand command = new SqlCommand(sql,conn);
            return command.ExecuteNonQuery();

        }

        public List<T> executeReader(string sql,string[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string> names = new List<string>();
            for(int i = 0; i < reader.FieldCount; i++)
            {
                names.Add(reader.GetName(i));
            }
            
            Type type = typeof(T);
            List<T> list = new List<T>();
            while (reader.Read())
            {
                object obj = Activator.CreateInstance(type);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    MethodInfo method = type.GetMethod("set" + names[i]);
                    method.Invoke(obj, new object[] { reader.GetString(i) });
                }
                list.Add((T)obj);
            }
            return list;
        }
        public int executeScalar(string sql,string[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            SqlCommand command = new SqlCommand(sql, conn);
            return (int)command.ExecuteScalar();
        }
    }
}
