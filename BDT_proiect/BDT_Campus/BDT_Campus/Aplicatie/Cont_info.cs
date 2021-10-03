/**************************************************************************
 *                                                                        *
 *  File:        Log_bloc.cs                                              *
 *  Copyright:   (c) 2021, Mihaela PAVĂL, Iulian PRELIPCEAN, Claudiu ȚAGA *
 *  E-mail:      mihaela-irina.paval@student.tuiasi.ro                    *
 *  Description: Interface Log_bloc for log in users.                     *
 *  (Software Engineering IP Project 2021)                                *
 *                                                                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BDT_Campus
{
    /// <summary> 
    /// Clasa Cont_info a fost utilizata pentru a  permite utilizatorului sa vizualizeze datele contului
    /// </summary> 
    public partial class Cont_info : Form
    {
        private ConexiuneBD.ConexiuneBD _conexiune;
        private string _username;
        public Cont_info()
        {
            InitializeComponent();
        }
        public Cont_info(String name)
        {
            InitializeComponent();
            _username = name;
            labelUser.Text = name;
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
            labelPass.Text = new string('*', preluareParola(name).Length);

        }

        private string preluareParola(String user)
        {
            String pass = "";
            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT pass FROM IP_Proiect.dbo.login WHERE user_tip = '" +  _username + "'", _conexiune.getConnection());
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                pass = dr["PASS"].ToString();
            }
            return pass;
        }

        /// <summary> 
        /// Functia face vizibila parola
        /// </summary> 
        private void buttonShow_Click(object sender, EventArgs e)
        {
            labelPass.Text = preluareParola(_username);
        }

        /// <summary> 
        /// Functia redirectioneaza utilizatorul catre interfata ActualizareParola
        /// </summary> 
        private void buttonChange_Click(object sender, EventArgs e)
        {
            this.Hide();
            ActualizareParola intf = new ActualizareParola(_username, 1);
            intf.Show();
        }

        /// <summary> 
        /// Functia redirectioneaza utilizatorul catre interfata Manager sau Administrator, in functie de rolul pe care il are utilizatorul conectat
        /// </summary> 
        private void buttonBack_Click(object sender, EventArgs e)
        {
            string rol = "";
            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT rol FROM IP_Proiect.dbo.login WHERE user_tip = '" + _username + "'", _conexiune.getConnection());
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                rol = dr["ROL"].ToString();
            }
            if(rol == "administrator")
            {
                this.Hide();
                Administrator admin = new Administrator(_username);
                admin.Show();
            }
            else if(rol == "manager")
            {
                this.Hide();
                Manager man = new Manager(_username);
                man.Show();
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
