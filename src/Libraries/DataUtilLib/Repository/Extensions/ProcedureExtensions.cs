using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSD.Util.Data.Repository.Extensions
{
    public static class ProcedureExtensions
    {
        private static IList<T> MapToList<T>(this DbDataReader dr)
        {
            var list = new List<T>();
            var properties = typeof(T).GetRuntimeProperties();

            var colDict = dr.GetColumnSchema()
                .Where(t => properties.Any(pi => pi.Name.ToLower() == t.ColumnName.ToLower()))
                .ToDictionary(k => k.ColumnName.ToLower());

            while (dr.Read()) {
                T t = Activator.CreateInstance<T>();

                foreach (var p in properties) {
                    var val = dr.GetValue(colDict[p.Name.ToLower()].ColumnOrdinal.Value);

                    p.SetValue(t, val == DBNull.Value ? null : val);
                }

                list.Add(t);
            }

            return list;            
        }

        public static DbCommand LoadProcedure(this DbContext context, string name)
        {            
            var cmd = context.Database.GetDbConnection().CreateCommand();

            cmd.CommandText = name;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        public static DbCommand SetParameters(this DbCommand cmd, params (string, object)[] parameters)
        {
            foreach (var pi in parameters) {
                var parameter = cmd.CreateParameter();

                parameter.ParameterName = pi.Item1;
                parameter.Value = pi.Item2 ?? DBNull.Value;
                cmd.Parameters.Add(parameter);
            }

            return cmd;
        }

        public static IEnumerable<T> ExecuteProcedure<T>(this DbCommand cmd) where T: class
        {
            if (cmd.Connection.State != ConnectionState.Open)
                cmd.Connection.Open();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return reader.MapToList<T>();
                }
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static async Task<IEnumerable<T>> ExecuteProcedureAsync<T>(this DbCommand cmd) where T : class
        {
            if (cmd.Connection.State != ConnectionState.Open)
                await cmd.Connection.OpenAsync();

            try
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return reader.MapToList<T>();
                }
            }
            finally {
                cmd.Connection.Close();
            }
        }
    }
}
