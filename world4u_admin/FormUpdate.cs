using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using world4u_admin;

namespace world4u_admin
{
    public partial class FormUpdate : Form
    {
       private Form1 parent = null;

       private int row;
       private string name = null;
       private int? fugitive_Status = null;

       private string general_info = null;
       private string entry_doc = null;
       private string reg_doc= null;
       private string transport = null;
       private string housing = null;
       private string nutrition = null;
       private string pets = null;
       private string charity = null;
       private string add_info = null;

       private int? pointer = null; 
        public FormUpdate()
        {
            InitializeComponent();
        }

        public void setParent(Form1 parent)
        {
            this.parent = parent;
        }

        public void setLabelName(string name) {
            label1.Text = name;
        }
        public void setRow(int row)
        {
            this.row = row;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public void setFugitive_status(int? num)
        {
            this.fugitive_Status = num;
        }
        public void setGeneral_info(string text)
        {
            this.general_info = text;
        }
        public void setEntry_doc(string text)
        {
            this.entry_doc = text;
        }
        public void setReg_doc(string text)
        {
            this.reg_doc = text;
        }
        public void setTransport(string text)
        {
            this.transport = text;
        }
        public void setHousing(string text)
        {
            this.housing = text;
        }
        public void setNutrition(string text)
        {
            this.nutrition = text;
        }
        public void setPets(string text)
        {
            this.pets = text;
        }
        public void setCharity(string text)
        {
            this.charity = text;
        }
        public void setAdd_info(string text)
        {
            this.add_info = text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
/*                parent.Update(row, textBoxFName.Text, textBoxLName.Text, Convert.ToInt16(textBoxAge.Text), Convert.ToInt32(sexString), Convert.ToInt32(departmentString), Convert.ToInt32(rankString)); ;
                parent.FillDataGridViewPolicemen();
                this.Visible = false;*/
            
        }

        public void setTextBox(string text)
        {
            textBox1.Text = text;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            parent.UpdateInfo(row, fugitive_Status,general_info,entry_doc,reg_doc,transport,housing,nutrition,pets,charity,add_info);
            parent.FillDataGridView1ByGis();
            this.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "add_info";
            pointer = 10;
            setTextBox(add_info == null ? "" : add_info);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "charity";
            pointer = 9;
            setTextBox(charity == null ? "" : charity);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "pets";
            pointer = 8;
            setTextBox(pets == null ? "" : pets);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "nutrition";
            pointer = 7;
            setTextBox( nutrition == null ? "" : nutrition);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "housing";
            pointer = 6;
            setTextBox(housing == null ? "" : housing);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "transport";
            pointer = 5;
            setTextBox(transport == null ? "" : transport);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "reg_doc";
            pointer = 4;
            setTextBox(reg_doc == null ? "" : reg_doc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "entry_doc";
            pointer = 3;
            setTextBox(entry_doc == null ? "" : entry_doc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "fugitive_Status";
            pointer = 1;
            setTextBox(fugitive_Status == null ? null : Convert.ToString(fugitive_Status));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "general_info";
            pointer = 2;
            setTextBox(general_info == null ? "" : general_info);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (pointer)
            {
                case 1:
                    fugitive_Status = textBox1.Text == "" ? null : (int?)Convert.ToInt32(textBox1.Text) < 0 && (int?)Convert.ToInt32(textBox1.Text) > 3 ? null: (int?)Convert.ToInt32(textBox1.Text);
                    break;
                case 2:
                    general_info = textBox1.Text;
                    break;
                case 3:
                    entry_doc = textBox1.Text;
                    break;
                case 4:
                    reg_doc = textBox1.Text;
                    break;
                case 5:
                    transport = textBox1.Text;
                    break;
                case 6:
                    housing = textBox1.Text;
                    break;
                case 7:
                    nutrition = textBox1.Text;
                    break;
                case 8:
                    pets = textBox1.Text;
                    break;
                case 9:
                    charity = textBox1.Text;
                    break;
                case 10:
                    add_info = textBox1.Text;
                    break;
                default:
                    return;
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            string legend = "Умовні позначення:\n0. Вільний в'їзд\n1. Часткові обмеження\n2. Обмеження\n3. Заборонено";
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.button2, legend);
        }
    }
}
