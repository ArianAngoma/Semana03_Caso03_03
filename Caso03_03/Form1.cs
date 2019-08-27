using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace Caso03_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Caso03_03"].ConnectionString);

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaAnios();
        }

        public void ListaAnios()
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Pais_Cliente", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "ListaAnios");

                        Ls01.DataSource = df.Tables["ListaAnios"];

                    }
                }
            }
        }
    }
}
