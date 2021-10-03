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
    /// Clasa RecuperareParola a fost utilizata pentru implementarea logicii de verificare a informatiilor personale ale unui user 
    /// si redirectionarea catre interfata ActualizareParola
    /// </summary> 
    ///
    public partial class RecuperareParola : Form
    {
        private ConexiuneBD.ConexiuneBD _conexiune;
        public RecuperareParola()
        {
            InitializeComponent();
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
        }

        /// <summary> 
        /// Functia preia din baza de date CNP-ul utilizatorului introdus in campurile prezente 
        /// si verifica daca ultimele 6 cifre ale acestuia corespund cu cifrele  introduse in interfata
        /// </summary> 
        private void buttonNext_Click(object sender, EventArgs e)
        {
            String cnp = "";
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT cnp FROM IP_Proiect.dbo.login " +
                                                        "WHERE user_tip = '" + textBoxUser.Text + "'" , _conexiune.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cnp = dr["CNP"].ToString();
            }

            if (cnp.Substring(cnp.Length-6) == textBoxCnp.Text.ToString())
            {
                //MessageBox.Show("merge");
                this.Hide();
                ActualizareParola intf = new ActualizareParola(textBoxUser.Text, 0);
                intf.Show();
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
