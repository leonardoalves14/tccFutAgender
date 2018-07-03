using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace SocietyAgendor.API.Base
{
    public abstract class Base : IDisposable
    {
        private readonly string _connectionString;

        public Base(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SocietyAgendorDb");
        }

        public void ExecuteSP(string procedureName, DynamicParameters parameters = null)
        {
            //using (var transaction = new TransactionScope())
            //{
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                if (parameters == null)
                    sqlConnection.Execute(procedureName, commandType: System.Data.CommandType.StoredProcedure);
                else
                    sqlConnection.Execute(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            //    transaction.Complete();
            //}
        }

        public void ExecuteSP(string procedureName, ref DynamicParameters parameters)
        {
            //using (var transactionScope = new TransactionScope())
            //{
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                sqlConnection.ExecuteAsync(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            //    transactionScope.Complete();
            //}

        }

        public List<T> ExecuteSP<T>(string procedureName, DynamicParameters parameters = null, IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            List<T> ret = new List<T>();

            //using (var transactionScope = new TransactionScope())
            //{
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                if (parameters == null)
                    ret = sqlConnection.Query<T>(procedureName).ToList<T>();
                else
                    ret = sqlConnection.Query<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList<T>();
            }

            //    transactionScope.Complete();
            //}

            return ret;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) { }
    }
}
