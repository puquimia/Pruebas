using Dapper.Contrib.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using static Dapper.SqlMapper;
using System.Data;

namespace SLD.LIB.O.SOL.AD
{
    public class DAccesos
    {
        public readonly string cadenaConexion;
        public DAccesos()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["GEN"].ToString();
        }
        public void Insert<T>(T entidad) where T : class
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                connection.Insert(entidad);
            }
        }
        public void Update<T>(T entidad) where T : class
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                connection.Insert(entidad);
            }
        }

        public void UpdateColumns<T>(T entidad, params string[] columnasAActualizar) where T : class
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                string formatoInsert = "UPDATE {0} SET {1} WHERE {2} = {3}";
                var parameter = new DynamicParameters();

                StringBuilder sbColumnas = new StringBuilder();

                Type myType = typeof(T);
                dynamic tabla = myType.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

                PropertyInfo[] lcolumnas = myType.GetProperties();
                string nombreKey = string.Empty;
                var idKey = new object();

                lcolumnas.ToList().ForEach(eProperty => {
                    if (string.IsNullOrEmpty(nombreKey))
                    {
                        if ((Attribute.GetCustomAttribute(eProperty, typeof(KeyAttribute)) as KeyAttribute) != null ||
                            (Attribute.GetCustomAttribute(eProperty, typeof(ExplicitKeyAttribute)) as ExplicitKeyAttribute) != null)
                        {
                            nombreKey = eProperty.Name;
                            idKey = eProperty.GetValue(entidad, null);
                        }
                    }
                    else
                    {
                        string nombreColumna = eProperty.Name;
                        if (columnasAActualizar.AsEnumerable().Where(x => x == nombreColumna).Count() > 0)
                        {
                            var value = eProperty.GetValue(entidad, null);
                            sbColumnas.Append(string.Format("{0}={1},", nombreColumna, $"@{nombreColumna}"));
                            parameter.Add($"@{nombreColumna}", value);
                        }
                    }
                });
                sbColumnas.Length -= 1;
                parameter.Add($"@{nombreKey}", idKey);

                string sb = string.Format(formatoInsert, tabla.Name, sbColumnas, nombreKey, $"@{nombreKey}");
                connection.Execute(sb.ToString(), parameter);
            }
        }

        public List<T> GetAll<T>() where T : class
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                return connection.GetAll<T>().ToList();
            }
        }

        public void EjecutarSP(string nombreSP)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                connection.Execute(nombreSP, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<object>EjecutarConsultaSP(string nombreSP, DynamicParameters parametros, params Func<GridReader, object>[] entidades)
        {
            using (var connection = new SqlConnection(cadenaConexion))
            {
                connection.Open();
                var lDatos = new List<object>();
                using (var mlt = connection.QueryMultiple(sql: nombreSP,
                                                   param: parametros,
                                                   commandType: CommandType.StoredProcedure))
                {
                    foreach (var entidad in entidades)
                    {
                        var obj = entidad(mlt);
                        lDatos.Add(obj);
                    }
                }
                return lDatos;
            }
        }
    }
}
