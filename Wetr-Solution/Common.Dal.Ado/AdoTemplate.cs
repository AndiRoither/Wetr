﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Common.Dal.Ado
{
    public class AdoTemplate
    {
        private readonly IConnectionFactory connectionFactory;

        public AdoTemplate(IConnectionFactory connectionFactory)
        {
            // Beacuse this variable is readonly it can only be set in the constructor
            // When this check succeeds, it cannot be null anywhere else
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, RowMapper<T> rowMapper, params Parameter[] parameters)
        {
            var items = new List<T>();

            // Create Connection to DB
            using (DbConnection connection = this.connectionFactory.CreateConnection())
            {
                // Create Commend/Query
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    AddParameters(command, parameters);

                    try
                    {
                        // Read reveived data
                        using (IDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                items.Add(rowMapper(reader));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new MySqlException("Database not set up or missing table", ex.InnerException);
                    }
                }
            }

            return items;
        }

        public async Task<object> ScalarAsync<T>(string sql, params Parameter[] parameters)
        {

            // Create Connection to DB
            using (DbConnection connection = this.connectionFactory.CreateConnection())
            {
                // Create Commend/Query
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    AddParameters(command, parameters
                        );
                    object result = null;
                    try
                    {
                        result = await command.ExecuteScalarAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new MySqlException("Database not set up or missing table", ex.InnerException);
                    }
                    
                    return result;
                }
            }

            throw new Exception("Failed to execute Scalar-Query!");
        }

        private void AddParameters(DbCommand command, Parameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                DbParameter dbParameter = command.CreateParameter();
                dbParameter.ParameterName = parameter.Name;
                dbParameter.Value = parameter.Value;
                command.Parameters.Add(dbParameter);
            }
        }

        public async Task<int> ExecuteAsync(string sql, params Parameter[] parameters)
        {
            using (DbConnection connection = connectionFactory.CreateConnection())
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                this.AddParameters(command, parameters);

                try
                {
                    return await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw new MySqlException("Database not set up or missing table", ex.InnerException);
                }
            }
        }
    }
}