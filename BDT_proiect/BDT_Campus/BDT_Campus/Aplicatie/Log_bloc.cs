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
    public partial class Log_bloc : Form
    {
        private ConexiuneBD.ConexiuneBD _conexiune;
        public Log_bloc()
        {
            InitializeComponent();
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
        }
        public String getUtilizator() //return nume utilizator =>null
        {
            this.Invoke(new Action(() => { }));
            return textBoxUsername.Text;
        }
        public String getUtilizatorBD(String nume_utilizator, String func) //return parola
        {


            this.Invoke(new Action(() =>
            {
                OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT rol FROM IP_Proiect.dbo.login  WHERE user_tip ='" + nume_utilizator + "'", _conexiune.getConnection());
                DataTable dt1 = new DataTable();
                //se face difuzie la toate interfetele 
                sda1.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {

                        switch (dr["rol"].ToString())
                        {
                            case "administrator":
                                func = "administrator";
                                break;
                            case "manager":
                                func = "manager";
                                break;
                        }
                    }
                }
            }));
            return func;
        }

        /// <summary>
        ///  Functia inchide programul
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();

            _conexiune.Close();
        }

        /// <summary>
        ///  Se selecteaza campul rol din tabela login care retine rolul ficarui user.
        ///  Daca rolul pentru users introdus este valid se trece la identificarea indentitatii
        ///  in log_verif, altfel se intoarce eroare!
        /// </summary>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("Select rol FROM IP_Proiect.dbo.login  WHERE user_tip= '" + textBoxUsername.Text + "'AND pass='" + textBoxPassword.Text + "'", _conexiune.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt); //trimite la toate interfetele
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Log_verif intf = new Log_verif(0, textBoxUsername.Text);
                intf.Show();
            }
            else
            {
                MessageBox.Show("Va rugam verificati Username & Password");
            }
        }

        /// <summary>
        /// Functia redirectioneaza utilizatorul catre interfata RecuperareParola
        /// </summary>
        private void buttonRecuperare_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecuperareParola intf = new RecuperareParola();
            intf.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
