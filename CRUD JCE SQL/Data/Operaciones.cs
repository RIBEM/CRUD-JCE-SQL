using CRUD_JCE_SQL.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JCE_SQL.Data
{
    public class Operaciones
    {
        public bool CreateCedula(Cedula oCedula)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Configuration.Conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_CreateCedula", oConexion);
                    cmd.Parameters.AddWithValue("Id", oCedula.Id);
                    cmd.Parameters.AddWithValue("NumeroCed", oCedula.NumeroCed);
                    cmd.Parameters.AddWithValue("Nombre", oCedula.Nombre);
                    cmd.Parameters.AddWithValue("LugarNac", oCedula.LugarNac);
                    cmd.Parameters.AddWithValue("FechaNac", oCedula.FechaNac);
                    cmd.Parameters.AddWithValue("Nacionalidad", oCedula.Nacionalidad);
                    cmd.Parameters.AddWithValue("Sexo", oCedula.Sexo);
                    cmd.Parameters.AddWithValue("Sangre", oCedula.Sangre);
                    cmd.Parameters.AddWithValue("EstadoCivil", oCedula.EstadoCivil);
                    cmd.Parameters.AddWithValue("Ocupacion", oCedula.Ocupacion);
                    cmd.Parameters.AddWithValue("FechaExpiracion", oCedula.FechaExpiracion);
                    cmd.Parameters.AddWithValue("Foto", oCedula.Foto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta =false;
                }
            }

            return respuesta;
        }

        public bool ModifyCedula(Cedula oCedula)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Configuration.Conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModifyCedula", oConexion);
                    cmd.Parameters.AddWithValue("Id", oCedula.Id);
                    cmd.Parameters.AddWithValue("NumeroCed", oCedula.NumeroCed);
                    cmd.Parameters.AddWithValue("Nombre", oCedula.Nombre);
                    cmd.Parameters.AddWithValue("LugarNac", oCedula.LugarNac);
                    cmd.Parameters.AddWithValue("FechaNac", oCedula.FechaNac);
                    cmd.Parameters.AddWithValue("Nacionalidad", oCedula.Nacionalidad);
                    cmd.Parameters.AddWithValue("Sexo", oCedula.Sexo);
                    cmd.Parameters.AddWithValue("Sangre", oCedula.Sangre);
                    cmd.Parameters.AddWithValue("EstadoCivil", oCedula.EstadoCivil);
                    cmd.Parameters.AddWithValue("Ocupacion", oCedula.Ocupacion);
                    cmd.Parameters.AddWithValue("FechaExpiracion", oCedula.FechaExpiracion);
                    cmd.Parameters.AddWithValue("Foto", oCedula.Foto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public List<Cedula> ObtainCedula()
        {
            List<Cedula> oListaCedula = new List<Cedula>();
            using (SqlConnection oConexion = new SqlConnection(Configuration.Conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtainCedula", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    oListaCedula.Add(new Cedula
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        NumeroCed = dr["NumeroCed"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        LugarNac = dr["LugarNac"].ToString(),
                        FechaNac = DateTime.Parse(dr["NumeroCed"].ToString()),
                        Nacionalidad = dr["Nacionalidad"].ToString(),
                        Sexo = dr["Sexo"].ToString(),
                        Sangre = dr["Sangre"].ToString(),
                        EstadoCivil = dr["EstadoCivil"].ToString(),
                        Ocupacion = dr["Ocupacion"].ToString(),
                        FechaExpiracion = DateTime.Parse(dr["FechaExpiracion"].ToString()),
                        Foto = dr["Foto"] as byte[]
                    }) ;
                }
                dr.Close();
            }
            return oListaCedula;
        }
    }
}
