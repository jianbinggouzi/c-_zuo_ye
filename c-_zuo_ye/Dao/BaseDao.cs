using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace c__zuo_ye.Dao
{
    class BaseDao<T>
    {
        protected static string connString = "datasource=jianbinggouzi.club;database=mini_forum;userid=root;password=lcy360013;pooling=true;charset=utf8;";
        MySqlConnection conn = new MySqlConnection(connString);
        //protected SqlConnection conn = new SqlConnection(connString);
        protected string tablename = "";

        public int delete(String uuid)
        {
            conn.Open();
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("delete from ").Append(tablename).Append(" where uuid = ").Append(uuid);
            MySqlCommand command = new MySqlCommand(sqlBuilder.ToString(), conn);
            return command.ExecuteNonQuery();
        }

        //添加实例 
        public int add(T instance)
        {
            conn.Open();
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into ").Append(tablename).Append("(");
            Type type = instance.GetType();
            Console.WriteLine(type.ToString());
            FieldInfo[] prop = type.GetFields((BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
            Console.WriteLine("--------- " + prop.Length);
            for(int i = 0; i < prop.Length; i++)
            {
                
                sqlBuilder.Append(prop[i].Name.ToString());
                
                if (i != prop.Length - 1)
                    sqlBuilder.Append(",");
            }
            sqlBuilder.Append(") ").Append("values").Append("(");
            for(int i = 0; i < prop.Length; i++)
            {
                sqlBuilder.Append("'");
                sqlBuilder.Append(prop[i].GetValue(instance).ToString());
                sqlBuilder.Append("'");
                if (i != prop.Length - 1)
                    sqlBuilder.Append(",");
            }
            sqlBuilder.Append(")");
            Console.WriteLine(sqlBuilder.ToString());
            MySqlCommand command = new MySqlCommand(sqlBuilder.ToString(),conn);
            return command.ExecuteNonQuery();

            
        }
        //通过uuid获取实例
        public T get(string uuid)
        {
            string sql = "select * from " + tablename + " where uuid = '{0}'";
            return executeReader(sql, new object[] { uuid })[0];
        }

        //更新实例属性值
        public int update(string uuid, string key, string value)
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
            MySqlCommand command = new MySqlCommand(sql,conn);
            return command.ExecuteNonQuery();

        }
        //返回所有查询结果
        public List<T> executeReader(string sql,object[] args)
        {
            conn.Open();
            sql = String.Format(sql, args);
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
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
            MySqlCommand command = new MySqlCommand(sql, conn);
            return command.ExecuteScalar();
        }
    }
}
