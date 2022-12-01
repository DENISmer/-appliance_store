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


namespace ООО__Столовые_приборы_
{
    public partial class Authorization : Form
    {
        SqlConnection con1;
        public Authorization()
        {
            con1 = new SqlConnection("Data Source = REDISKINK; Database = D134_GolopapaDU; Integrated Security = true");
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            COMPONENTS.ProductsView pv = new COMPONENTS.ProductsView();
            this.Hide();
            pv.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("")) {
                COMPONENTS.Captcha captcha = new COMPONENTS.Captcha();
                captcha.Show();
                this.Hide();
            }
            else {
                CLASSES.UserData.UserName = textBox1.Text;
                CLASSES.UserData.UserPassword = textBox2.Text;
                if (UserRequest(textBox1.Text) == CLASSES.UserData.UserPassword)
                {
                    string sqlUserRole = "Select * from [User] where UserPassword ='" + textBox2.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlUserRole,con1);
                    DataTable dt2 = new DataTable();
                    adapter.Fill(dt2);

                    CLASSES.UserData.UserRole = dt2.Rows[0]["UserRole"].ToString();
                    this.Hide();
                    COMPONENTS.ProductsView PW = new COMPONENTS.ProductsView();
                    PW.Show();
                    
                }
                else {
                    COMPONENTS.Captcha captcha = new COMPONENTS.Captcha();
                    captcha.Show();
                    this.Hide();
                }
                

            }
            
            CLASSES.UserData.UserName = textBox1.Text;
            CLASSES.UserData.UserPassword = textBox2.Text;
            UserRequest(textBox1.Text);
            //if(true){
            //авторизация + переход как от пользователя
            //}
            //else{
            //  if(Captcha==true){
            //  авторизация
            //  else{
            //      captcha
            //}
            //}
            //}
        }
        private string UserRequest(string username) {
            string userRequest = "Select * from [User] where UserLogin = '" + username + "'";
            string userRole = null;
            string userPassword = null;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(userRequest, con1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                userPassword = dt.Rows[0]["UserPassword"].ToString();
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
            return userPassword;
        }
    }
}
