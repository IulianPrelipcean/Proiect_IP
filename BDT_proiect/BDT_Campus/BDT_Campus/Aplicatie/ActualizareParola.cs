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
    /// Clasa ActualizareParola a fost utilizata pentru implementarea functionalitatii de actualizare a parolei utilizatorului.
    /// </summary> 
    public partial class ActualizareParola : Form
    {
        private ConexiuneBD.ConexiuneBD _conexiune;
        private string _username;
        private int _flag;
        public ActualizareParola()
        {
            InitializeComponent();
        }
        public ActualizareParola(string name, int flag)
        {
            InitializeComponent();
            _username = name;
            _flag = flag;
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
        }

        /// <summary> 
        /// Functia actualizeaza parola utilizatorului la mivel de baza de date si il redirectioneaza catre interfaza Log_bloc pentru relogare
        /// </summary> 
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(textBoxNPW.Text.ToString() != "")
            {
                if (!(textBoxCPW.Text.ToString() == ""))
                {
                    if(textBoxNPW.Text.ToString() == textBoxCPW.Text.ToString())
                    {
                        //fac update
                        OleDbCommand cmd = new OleDbCommand("UPDATE IP_Proiect.dbo.login SET pass='" + textBoxNPW.Text +
                                                            "' WHERE user_tip = '" + _username + "'" , _conexiune.getConnection());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea parolei s-a realizat cu succes!");
                        this.Hide();
                        Log_bloc intf = new Log_bloc();
                        intf.Show();
                        _conexiune.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Confirmați noua parolă!");
                }
            }
            else
            {
                MessageBox.Show("Introduceți noua parolă!");
            }
        }
        /// <summary> 
        /// Functia intoarce utilizatorul in interfata Log_bloc sau interfata Cont_info, in functie de unde a fost facut accesul initial
        /// </summary> 
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(_flag == 0)
            {
                this.Hide();
                Log_bloc intf = new Log_bloc();
                intf.Show();
            }
            else if(_flag == 1)
            {
                this.Hide();
                Cont_info intf = new Cont_info(_username);
                intf.Show();
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
