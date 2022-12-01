using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООО__Столовые_приборы_.COMPONENTS
{
    
    public partial class ProductsView : Form
    {
        SqlConnection conn;
        public ProductsView()
        {
            conn = new SqlConnection(@"Data Source=REDISKINK; Database=D134_GolopapaDU; Integrated Security=True");
            InitializeComponent();
        }
        string[] panels = { "panel2", "panel3", "panel4", "panel5", "panel6", "panel7", "panel8", "panel9" };
        private void ProductsView_Load(object sender, EventArgs e)
        {
            if (CLASSES.UserData.UserRole == "1")
            {
                button1.Visible = true;
            }
            else { 
                button1.Visible=false;
            }
            for (int i = 0; i < 7; i++)
            {
                ProductsGeneration(i, panels, " sdf", " sdf", " sdf", " sdf", " sdf", " sdf");
            }
                
        }
        private void Update() { 
            conn.Open();
            
        }
        Panel innerpanel = null;
        Panel outpanel = null;
        private int ProductsGeneration(int i,string[] panels,string photo,string productName,string productDescription,string productManufacturer, string cost,string stock) {
                
                innerpanel = new Panel();
                innerpanel.Name = panels[i].ToString();
                Label label1 = new Label();
                Label label2 = new Label();
                Label label3 = new Label();
                Label label4 = new Label();
                Label label5 = new Label();
                PictureBox pictureBox1 = new PictureBox();

                // Initialize the Panel control.
                innerpanel.Location = new Point(20, 20 + (i * 160));
                innerpanel.Size = new Size(600, 152);
                innerpanel.BackColor = Color.FromArgb(118, 227, 131);
            // Set the Borderstyle for the Panel to three-dimensional.
            innerpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Initialize the Label and TextBox controls.

                pictureBox1.Size = new Size(123, 84);
                pictureBox1.Location = new Point(20, 20);
                pictureBox1.Image = Image.FromFile("E:/демо/приложение/ООО «Столовые приборы»/ООО «Столовые приборы»/IMAGES/picture.png");
            label1.Location = new Point(149, 15);
                label1.Text = productName;
                label1.Size = new Size(104, 16);
                label1.Font = new Font("Arial", 12);

                label2.Location = new Point(311, 15);
                label2.Text = productDescription;
                label2.Size = new Size(104, 16);
                label2.Font = new Font("Arial", 12);

                label3.Location = new Point(149, 47);
                label3.Text = productManufacturer;
                label3.Size = new Size(233, 20);
                label3.Font = new Font("Arial", 12);

                label4.Location = new Point(388, 47);
                label4.Text = cost;
                label4.Size = new Size(33, 20);
                label4.Font = new Font("Arial", 12);

                label5.Location = new Point(149, 79);
                label5.Text = stock;
                label5.Size = new Size(119, 20);
                label5.Font = new Font("Arial", 12);


                // Add the Panel control to the form.
                this.Controls.Add(innerpanel);
            // Add the Label and TextBox controls to the Panel.
                innerpanel.Controls.Add(pictureBox1);
                innerpanel.Controls.Add(label5);
                innerpanel.Controls.Add(label4);
                innerpanel.Controls.Add(label3);
                innerpanel.Controls.Add(label2);
                innerpanel.Controls.Add(label1);
                flowLayoutPanel1.Controls.Add(innerpanel);
                return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COMPONENTS.Admin_products Ap = new Admin_products();
            Ap.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Authorization au = new Authorization();
            au.Show();
            ООО__Столовые_приборы_.CLASSES.UserData.UserRole = "0";
        }
    }
}
