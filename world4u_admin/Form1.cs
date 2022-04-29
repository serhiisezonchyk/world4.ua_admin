using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace world4u_admin
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection = null;
        //Ссылка на DataSet
        private DataSet dataSet = null;
        //Ссылки на DataAdapter для группы и студента
        private NpgsqlDataAdapter gisDataAdapter = null;
        public Form1()
        {
            InitializeComponent();
        }
        public void setConnection(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        private DataSet getDataSet()
        {
            if (dataSet == null)
            {
                dataSet = new DataSet();
                dataSet.Tables.Add("Gis");
            }
            return dataSet;
        }
        public FormConnect getFormCon()
        {
            FormConnect formConnect = new FormConnect();
            formConnect.setParent(this);
            return formConnect;
        }

        public FormUpdate getFormUpdate()
        {
            FormUpdate formUpdate = new FormUpdate();
            formUpdate.setParent(this);
            return formUpdate;
        }

        //Установить соединение с базой
        public NpgsqlConnection Connect(string host, int port, string database,
         string user, string parol)
        {
            NpgsqlConnectionStringBuilder stringBuilder =
            new NpgsqlConnectionStringBuilder();
            stringBuilder.Host = host;
            stringBuilder.Port = port;
            stringBuilder.Username = user;
            stringBuilder.Password = parol;
            stringBuilder.Database = database;
            stringBuilder.Timeout = 30;
            NpgsqlConnection connection =
            new NpgsqlConnection(stringBuilder.ConnectionString);
            connection.Open();
            return connection;
        }
        //Заполнить DataGridView1 студентами
        public void FillDataGridView1ByGis()
        {
            getDataSet().Tables["Gis"].Clear();
            gisDataAdapter = new NpgsqlDataAdapter(
            "SELECT gid,\"name\",fugitive_status,general_info,entry_doc,reg_doc,transport,housing,nutrition,pets,charity,add_info FROM world_boundaries", connection);
            new NpgsqlCommandBuilder(gisDataAdapter);
            gisDataAdapter.Fill(getDataSet(), "Gis");
            dataGridView1.DataSource = getDataSet().Tables["Gis"];
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getFormCon().Visible = true;

        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (connection == null)
                return;
            getDataSet().Tables["Gis"].Clear();
            gisDataAdapter = new NpgsqlDataAdapter(
            "SELECT gid,\"name\",fugitive_status,general_info,entry_doc,reg_doc,transport,housing,nutrition,pets,charity,add_info " +
            "FROM world_boundaries " +
            "where \"name\" like '%"+textBox1.Text+"%'", connection);
            new NpgsqlCommandBuilder(gisDataAdapter);
            gisDataAdapter.Fill(getDataSet(), "Gis");
            dataGridView1.DataSource = getDataSet().Tables["Gis"];
        }

        private void updateRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            int row = (int)getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[0];
            string name = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[1]);
            int? fugitive_Status = DBNull.Value.Equals(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[2]) ? null : (int?)getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[2];
            string general_info = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[3]);
            string entry_doc = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[4]);
            string reg_doc = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[5]);
            string transport = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[6]);
            string housing = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[7]);
            string nutrition = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[8]);
            string pets = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[9]);
            string charity = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[10]);
            string add_info = emptyCheckStr(getDataSet().Tables["Gis"].Rows[selectedRow].ItemArray[11]);

            FormUpdate formUp = getFormUpdate();
            formUp.Visible = true;
            formUp.setName(name);
            formUp.setLabelName(name);
            formUp.setFugitive_status(fugitive_Status);
            formUp.setGeneral_info(general_info);
            formUp.setEntry_doc(entry_doc);
            formUp.setReg_doc(reg_doc);
            formUp.setTransport(transport);
            formUp.setHousing(housing);
            formUp.setNutrition(nutrition);
            formUp.setPets(pets);
            formUp.setCharity(charity);
            formUp.setAdd_info(add_info);
            formUp.setRow(selectedRow);

        }
        private string emptyCheckStr(object str) {
            return DBNull.Value.Equals(str) ? String.Empty : (string)str;
        }
        public void UpdateInfo(int row, int? fugitive_status, string general_info, 
            string entry_doc, string reg_doc, 
            string transport, string housing,
            string nutrition, string pets, 
            string charity, string add_info)
        {
            if(fugitive_status == null)
                getDataSet().Tables["Gis"].Rows[row]["fugitive_status"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["fugitive_status"] = fugitive_status;

            if(general_info == "")
                getDataSet().Tables["Gis"].Rows[row]["general_info"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["general_info"] = general_info;

            if(entry_doc == "")
                getDataSet().Tables["Gis"].Rows[row]["entry_doc"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["entry_doc"] = entry_doc;

            if(reg_doc == "")
                getDataSet().Tables["Gis"].Rows[row]["reg_doc"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["reg_doc"] = reg_doc;

            if(transport == "")
                getDataSet().Tables["Gis"].Rows[row]["transport"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["transport"] = transport;

            if (housing == "")
                getDataSet().Tables["Gis"].Rows[row]["housing"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["housing"] = housing;

            if(nutrition == "")
                getDataSet().Tables["Gis"].Rows[row]["nutrition"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["nutrition"] = nutrition;

            if(pets == "")
                getDataSet().Tables["Gis"].Rows[row]["pets"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["pets"] = pets;

            if(charity == "")
                getDataSet().Tables["Gis"].Rows[row]["charity"] = DBNull.Value;
            else
                getDataSet().Tables["Gis"].Rows[row]["charity"] = charity;

            if(add_info == "")
                getDataSet().Tables["Gis"].Rows[row]["add_info"] = add_info;
            else
                getDataSet().Tables["Gis"].Rows[row]["add_info"] = add_info;
            gisDataAdapter.Update(getDataSet(), "Gis");
        }

    }
}