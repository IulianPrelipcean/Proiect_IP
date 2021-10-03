/**************************************************************************
 *                                                                        *
 *  File:        Log_verif.cs                                             *
 *  Copyright:   (c) 2021, Mihaela PAVĂL, Iulian PRELIPCEAN, Claudiu ȚAGA *
 *  E-mail:      mihaela-irina.paval@student.tuiasi.ro                    *
 *  Description: Interface Log_verif for user verification.               *
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
    public partial class Log_verif : Form
    {
        private ConexiuneBD.ConexiuneBD _conexiune;
        private string _username;

        public Log_verif()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Functia incarca lista rolurilor existente la nivelul bazei de date
        /// </summary> 
        
        public Log_verif(int rol, string name)
        {
            InitializeComponent();
            _username = name;
            labelUser.Text = name;
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();

            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT DISTINCT rol FROM IP_Proiect.dbo.login ", _conexiune.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxRol.Items.Add(dr["rol"].ToString());
            }
        }

        /// <summary>
        ///  Functia inchide interfata
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Se creaza conexiune cu baza de date si se citeste rolul din BD
        /// se testeaza rolul introdus si cu cea citita, daca corespund se face trimitere 
        /// la interfetele corespunzatoare prin intermediul constructorilor specifici, dupa caz
        /// </summary>
        private void buttonConfirmare_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            
            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT rol FROM IP_Proiect.dbo.login  WHERE user_tip ='" + _username +"'", _conexiune.getConnection());
            DataTable dt1 = new DataTable();
            
            sda1.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                string functieValida;
                foreach (DataRow dr in dt1.Rows)
                {
                    functieValida = dr["rol"].ToString();
                    if (comboBoxRol.Text == functieValida)
                    {
                        Flag = 1;
                    }
                }
                if (Flag == 1)
                {
                    switch (comboBoxRol.Text)
                    {
                        case "administrator":
                            this.Hide();
                            Administrator admin = new Administrator(_username);
                            admin.Show();
                            
                            break;
                        case "manager":
                            this.Hide();
                            Manager manager = new Manager(_username);
                            manager.Show();
                            break;
                      
                    }
                }
                else
                {
                    MessageBox.Show("ERR: Funcția introdusă nu corespunde cu atribuțiile dumneavoastră în cadrul campusului TUIASI! Reintroduceți!");
                }
            }
            else
            {
                MessageBox.Show("ERR: Funcția introdusă nu corespunde cu atribuțiile dumneavoastră în cadrul campusului TUIASI! Reintroduceți!");
            }
        }

        /// <summary>
        /// Functia inchide interfata
        /// </summary>
        private void buttonRefuz_Click(object sender, EventArgs e)
        {
            Log_bloc intf = new Log_bloc();
            intf.Show();
            this.Close();

            _conexiune.Close();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
