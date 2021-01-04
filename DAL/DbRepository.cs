using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using WebApplication5.DAL;

namespace WebApplication5.DAL
{
    public class DbRepository : IDbRepository
    {
        private string _configuration;
        public DbRepository(IConfiguration configuration)
        {
           _configuration = configuration.GetValue<string>("DbInfo:ConnectionString");           
        }

        internal IDbConnection dbConnection { get { return new SqlConnection(_configuration); } }

        public int GetNoEndStatus()
        {
            string startDate = "2020-12-01";
            string endDate = "2020-12-27";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid not in (select orderid from[Documents].[OrderStatuses] where[status] in (210, 205, 202, 212, 211))");


                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int GetStoresCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"SELECT COUNT(DISTINCT s.StoreId)
                                    FROM [Documents].[OrderStatuses] s 
                                    JOIN [Documents].[OrderHeaders] h ON h.OrderId = s.OrderId
                                    INNER JOIN [References].PN_PharmacySync p ON p.TableRowGUID = h.StoreId
                                    INNER JOIN [Documents].[OrderRows] r ON r.OrderId = s.OrderId 
                                    JOIN [References].[ProductsSync] pr ON pr.id_ISS = r.Nnt
                                    JOIN [References].[UnionNetSync] n ON n.id = p.id_pn_unionnet 
                                    WHERE n.Real_Net_Guid = {netGuid}
                                    AND s.TimeStamp > {startDate}
                                    AND s.TimeStamp < {endDate}");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;            
        }
        public int GetOrderCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"SELECT Count(OrderId) AS 'Количество заказов'
                                        FROM [Documents].[OrderRows]
                                        WHERE StoreId in
                                        (SELECT [TableRowGUID]
                                        FROM [References].PN_PharmacySync p 
                                        JOIN [References].[UnionNetSync] n ON n.id = p.id_pn_unionnet 
                                        WHERE n.Real_Net_Guid = {netGuid}
                                        AND p.Actual = 1)
                                        AND Timestamp > {startDate}
                                        AND Timestamp < {endDate}");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int GetSoldOrdersCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid in (select orderid from[Documents].[OrderStatuses] where[status] in (210))");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int GetTimeOutCanceledCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid in (select orderid from[Documents].[OrderStatuses] where[status] in (205))");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int CustomerCanceledOrdersCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid in (select orderid from[Documents].[OrderStatuses] where[status] in (211))");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int GetCanceledOrdCount()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid in (select orderid from[Documents].[OrderStatuses] where[status] in (212,202))");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }
        public int GetNoReceiveStatusOrd()
        {
            string startDate = "2021-01-01";
            string endDate = "2021-01-04";
            string netGuid = "efb05410-ba92-4a73-a37f-f05f9a499ded";
            int result = 0;

            using (IDbConnection connection = dbConnection)
            {
                string spName = "[Monitoring].[ExecQueryShards]";
                string sqlCommand = ($@"select COUNT(h.number)
                            from[Documents].[OrderHeaders] h
                            inner join[Documents].[OrderStatuses] s on h.orderid = s.orderid
                            where h.storeid in
                            (SELECT[TableRowGUID]
                            FROM[References].PN_PharmacySync p
                            JOIN[References].[UnionNetSync] n ON n.id = p.id_pn_unionnet
                            WHERE n.Real_Net_Guid = {netGuid}
                            AND p.Actual = 1)
                            and h.date between {startDate} and ({endDate}) and s.status = 100
                            and h.orderid not in (select orderid from[Documents].[OrderStatuses] where[status] in (200,211,202,201))");

                SqlCommand command = new SqlCommand(sqlCommand, (SqlConnection)connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = spName;
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@text";
                parameter.SqlDbType = SqlDbType.NVarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = sqlCommand;
                command.Parameters.AddWithValue("@text", sqlCommand);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = (Int16)reader[0];
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return result;
        }


    }
}
