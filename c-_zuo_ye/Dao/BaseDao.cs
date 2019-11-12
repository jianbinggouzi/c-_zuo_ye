using System;
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
        protected static string connString = "";
        protected SqlConnection conn = new SqlConnection(connString);
        protected string tablename = "";

        //添加实例 
        public int add(String tablename,T instance)
        {
            conn.Open();
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into ").Append(tablename).Append("(");
            Type type = typeof(T);
            PropertyInfo[] prop = type.GetProperties();
            for(int i = 0; i < prop.Length; i++)
            {
                sqlBuilder.Append(prop[i].Name.ToString());
                if (i != prop.Length - 1)
                    sqlBuilder.Append(",");
            }
            sqlBuilder.Append(") ").Append("values").Append("(");
            for(int i = 0; i < prop.Length; i++)
            {
                sqlBuilder.Append(prop[i].GetValue(instance).ToString());
                if (i != prop.Length - 1)
                    sqlBuilder.Append(",");
            }
            sqlBuilder.Append(")");
            SqlCommand command = new SqlCommand(sqlBuilder.ToString());
            return command.ExecuteNonQuery();

            
        }
        //通过uuid获取实例
        public T get(string uuid)
        {
            string sql = "select * from " + tablename + " where uuid = '{0}'";
            return executeReader(sql, new object[] { uuid })[0];
        }

        //更新实例属性值
        public int updateField(string uuid, string key, string value)
        {
            if (key.Equals("uuid"))
                return 0;
            string sql = "update "+this.tablename+" set '{0}' = '{1}' where uuid = '{2}'";
            object[] args = new object[] { key, value, uuid };
            return executeNonQuery(sql, args);
        }

        //返回改变的列数
        public int executeNonQuery(string sql,object[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            SqlCommand command = new SqlCommand(sql,conn);
            return command.ExecuteNonQuery();

        }
        //返回所有查询结果
        public List<T> executeReader(string sql,object[] args)
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

        //返回结果第一行第一列
        public object executeScalar(string sql,object[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            SqlCommand command = new SqlCommand(sql, conn);
            return command.ExecuteScalar();
        }
    }
}
