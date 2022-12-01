using System;
using System.Collections.Generic;
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

namespace ООО__Столовые_приборы_.COMPONENTS
{

    public partial class Admin_products : Form
    {
        SqlConnection con1;

        bool btn4 = false;
        public Admin_products()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = D134_GolopapaDU; Integrated Security = true");
            InitializeComponent();
        }
        private void textbox_clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
        }
        private void Disable_Buttons()
        {

            if (btn4 == true)
            {
                add.Enabled = false;
                add.BackColor = Color.Red;

                back_button.Enabled = false;
                back_button.BackColor = Color.Red;

                delete.Enabled = false;
                delete.BackColor = Color.Red;

                save.Enabled = true;
                save.BackColor = Color.Green;
            }
            else if (btn4 == false)
            {
                add.Enabled = true;
                add.BackColor = Color.GreenYellow;

                back_button.Enabled = true;
                back_button.BackColor = Color.GreenYellow;

                delete.Enabled = true;
                delete.BackColor = Color.GreenYellow;

                save.Enabled = false;
                save.BackColor = Color.Red;
            }
        }

        private void PopulateGrid()
        {
            string SQL_Grid = "SELECT * FROM Product";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL_Grid, con1);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            con1.Close();
        }

        private void Admin_products_Load(object sender, EventArgs e)
        {
            PopulateGrid();

            btn4 = false;
            Disable_Buttons();
        }

        private void add_Click(object sender, EventArgs e)
        {
            con1.Open();

            if ((textBox1.Text.Equals("")) || (textBox2.Text.Equals("")) || (textBox3.Text.Equals("")) || (textBox4.Text.Equals("")) || (textBox5.Text.Equals("")) || (textBox6.Text.Equals("")) || (textBox7.Text.Equals("")) || (textBox8.Text.Equals("")) || (textBox9.Text.Equals("")) || (textBox9.Text.Equals("")) || (textBox10.Text.Equals("")) || (textBox11.Text.Equals("")) || (textBox12.Text.Equals("")))
            {
                MessageBox.Show("Вы не ввели все необходимые данные!!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                con1.Close();
                return;
            }

            string insS = "INSERT Товары values ('" + textBox1.Text
                + "','" + textBox2.Text
                + "','" + textBox3.Text
                + "','" + textBox4.Text
                + "','" + textBox5.Text
                + "','" + textBox6.Text
                + "','" + textBox7.Text
                + "','" + textBox8.Text
                + "','" + textBox9.Text
                + "','" + textBox10.Text
                + "','" + textBox11.Text
                + "','" + textBox12.Text
                + "')";

            SqlCommand seans = new SqlCommand(insS);
            seans.Connection = con1;
            seans.ExecuteNonQuery();

            MessageBox.Show("товар добавлен",
            "Сообщение об успехе",
            MessageBoxButtons.OK
            );

            textbox_clear();

            PopulateGrid();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
            ProductsView a = new ProductsView();
            a.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con1.Open();

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM Product WHERE [ProductArticleNumber] = '" + id + "'";
                SqlCommand comm = new SqlCommand(sql, con1);
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("Запись Удалена");
                PopulateGrid();
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            btn4 = true;
            Disable_Buttons();
            textBox1.BackColor = Color.Red;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            con1.Open();
            btn4 = false;
            Disable_Buttons();
            textBox1.BackColor = Color.White;
            textBox1.Enabled = true;
            dataGridView1.CurrentRow.Cells[0].Value = textBox1.Text;
            dataGridView1.CurrentRow.Cells[1].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[2].Value = textBox3.Text;
            dataGridView1.CurrentRow.Cells[3].Value = Convert.ToDecimal(textBox4.Text);
            dataGridView1.CurrentRow.Cells[4].Value = textBox5.Text;
            dataGridView1.CurrentRow.Cells[5].Value = textBox6.Text;
            dataGridView1.CurrentRow.Cells[6].Value = textBox1.Text;
            dataGridView1.CurrentRow.Cells[7].Value = textBox2.Text;
            dataGridView1.CurrentRow.Cells[8].Value = textBox3.Text;
            dataGridView1.CurrentRow.Cells[9].Value = textBox4.Text;
            dataGridView1.CurrentRow.Cells[10].Value = textBox5.Text;
            dataGridView1.CurrentRow.Cells[11].Value = textBox6.Text;
         

            string change = "UPDATE Product Set ProductName = '"
                + textBox2.Text + "',ProductUnit = '" +
                textBox3.Text + "',ProductCost = '" +
                Convert.ToDecimal(textBox4.Text) + "',ProductDiscountAmount = '" +
                textBox5.Text + "',ProductManufacturer = '" +
                textBox6.Text + "',ProductSupplier = '" +
                textBox7.Text + "',ProductCategory = '" +
                textBox8.Text + "',ProductCurrentDiscount = '" +
                textBox9.Text + "',ProductQuantityInStock = '" +
                textBox10.Text + "',ProductDescription = '" +
                textBox11.Text + "',ProductPhoto = '" +
                textBox12.Text + "' where [ProductArticleNumber] = '" + textBox1.Text + "'";


            textbox_clear();
            SqlCommand mm = new SqlCommand(change, con1);
            mm.ExecuteNonQuery();
            PopulateGrid();
        }
    }
}