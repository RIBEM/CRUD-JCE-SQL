using CRUD_JCE_SQL.Data;
using CRUD_JCE_SQL.Model;
using System.Data.SqlClient;

namespace CRUD_JCE_SQL
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            DiseñoInicial();
            MostrarListaCedula();
            SqlConnection oConexion = new SqlConnection(Configuration.Conexion);
            oConexion.Close();
        }

        private void DiseñoInicial()
        {
            DgCedula.MultiSelect = false;
            DgCedula.ReadOnly = true;
            DgCedula.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgCedula.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgCedula.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        private void MostrarListaCedula()
        {
            List<Cedula> oListaCedula = new Operaciones().ObtainCedula();

            DgCedula.DataSource = null;
            DgCedula.Columns.Clear();
            DgCedula.Rows.Clear();
            DgCedula.Refresh();

            DgCedula.DataSource = oListaCedula;
            DgCedula.Columns["Id"].Visible = false;
            DgCedula.Columns["Foto"].Visible = false;

            if (!DgCedula.Columns.Contains("Accion"))
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.HeaderText = "Accion";
                boton.Text = "Modificar";
                boton.Name = "btnModificar";
                boton.UseColumnTextForButtonValue = true;
                DgCedula.Columns.Add(boton);
            }
        }

        private void datagridPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgCedula.Columns[e.ColumnIndex].Name == "btnModificar")
            {
                Cedula cedula = (Cedula)DgCedula.SelectedRows[0].DataBoundItem;
                New_Registry formUsuario = new New_Registry(cedula);
                formUsuario.ShowDialog();
                MostrarListaCedula();
            }
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            Cedula cedula = (Cedula)DgCedula.SelectedRows[0].DataBoundItem;
            New_Registry formregistro = new New_Registry(cedula);
            formregistro.ShowDialog();
            MostrarListaCedula();
        }

        private void BtCreate_Click(object sender, EventArgs e)
        {
            New_Registry formusuario = new New_Registry(null);
            formusuario.ShowDialog();
            MostrarListaCedula();
        }
    }
}
