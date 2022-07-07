using CRUD_JCE_SQL.Data;
using CRUD_JCE_SQL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_JCE_SQL
{
    public partial class New_Registry : Form
    {
        private bool modo_modificar = false;
        public New_Registry(Cedula ParametroCedula)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            if (ParametroCedula != null)
            {
                lblTitulo.Text = "Modificar Registro";
                modo_modificar = true;
                TbId.Text = ParametroCedula.Id.ToString();
                TbNumeroCed.Text = ParametroCedula.NumeroCed;
                TbNombre.Text = ParametroCedula.Nombre;
                TbLugarNac.Text = ParametroCedula.LugarNac;
                DtFechaNac.Value = ParametroCedula.FechaNac;
                DtFechaExpiracion.Value = ParametroCedula.FechaExpiracion;
                CbSexo.Text = ParametroCedula.Sexo;
                CbSangre.Text = ParametroCedula.Sangre;
                CbEstadoCivil.Text = ParametroCedula.EstadoCivil;
                CbOcupacion.Text = ParametroCedula.Ocupacion;

                PbrFoto.Image = null;
                PbrFoto.Image = Image.FromStream(new MemoryStream(ParametroCedula.Foto));
                PbrFoto.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            else
            {
                TbId.Text = "0";
            }


        }

        private void DiseñoInicial()
        {

            PbrFoto.BorderStyle = BorderStyle.FixedSingle;
            this.ActiveControl = TbNumeroCed;
            BtGuardar.Cursor = Cursors.Hand;
            BtCancelar.Cursor = Cursors.Hand;
            BtBrowse.Cursor = Cursors.Hand;
        }

        private void New_Registry_Load(object sender, EventArgs e)
        {
            DiseñoInicial();
        }

        private void BtGuardar_Click_1(object sender, EventArgs e)
        {
            Cedula oCedula = new Cedula();
            byte[] BitesImagen;


            using (MemoryStream ms = new MemoryStream())
            {
                PbrFoto.Image.Save(ms, PbrFoto.Image.RawFormat);
                BitesImagen = ms.GetBuffer();
            }



            oCedula.Id = int.Parse(TbId.Text);
            oCedula.NumeroCed = TbNumeroCed.Text;
            oCedula.Nombre = TbNombre.Text;
            oCedula.LugarNac = TbLugarNac.Text;
            oCedula.FechaNac = DtFechaNac.Value;
            oCedula.Nacionalidad = TbNacionalidad.Text;
            oCedula.Sexo = CbSexo.Text;
            oCedula.Sangre = CbSangre.Text;
            oCedula.EstadoCivil = CbEstadoCivil.Text;
            oCedula.Ocupacion = CbOcupacion.Text;
            oCedula.FechaExpiracion = DtFechaExpiracion.Value;
            oCedula.Foto = BitesImagen;


            string mensajeOk = "";
            bool respuesta = false; ;
            if (modo_modificar)
            {
                mensajeOk = "Se guardaron los cambios \n¿Desea hacer un nuevo registro?";
                respuesta = new Operaciones().ModifyCedula(oCedula);
            }
            else
            {
                mensajeOk = "Persona Registrada \n¿Desea hacer un nuevo registro?";
                respuesta = new Operaciones().CreateCedula(oCedula);
            }



            if (respuesta)
            {
                if (MessageBox.Show(mensajeOk, "Mensaje", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lblTitulo.Text = "Nuevo Registro";
                    TbNumeroCed.Text = "";
                    TbNombre.Text = "";
                    TbLugarNac.Text = "";
                    DtFechaNac.Value = DateTime.Parse("12 / 31 / 2003");
                    TbNacionalidad.Text = "";
                    CbSexo.Text = "";
                    CbSangre.Text = "";
                    CbEstadoCivil.Text = "";
                    CbOcupacion.Text = "";
                    DtFechaExpiracion.Value = DateTime.Parse("7 / 7 / 2022");
                    TbFotoLoc.Text = "";
                    PbrFoto.Image = null;
                }
                else
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Persona se encuentra registrada", "Mensaje");
            }
        }

        private void BtBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();
            oFileDialog.Filter = "Imagen jpg|*.jpg";


            if (oFileDialog.ShowDialog() == DialogResult.OK)
            {
                TbFotoLoc.Text = oFileDialog.FileName;

                PbrFoto.Image = new Bitmap(oFileDialog.FileName);
                PbrFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
