/**************************************************************************
 *                                                                        *
 *  File:        Manager.cs                                               *
 *  Copyright:   (c) 2021, Mihaela PAVĂL, Iulian PRELIPCEAN, Claudiu ȚAGA *
 *  E-mail:      mihaela-irina.paval@student.tuiasi.ro                    *
 *  Description: Interface Manager for manager users.                     *
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
    /// Clasa Manager a fost utilizata pentru implementarea functionalitatilor atribuite utilizatorilor cu rol de manager.
    /// </summary> 
    ///
    public partial class Manager : Form
    {
        int ID = 0;
        private readonly ConexiuneBD.ConexiuneBD _conexiune;
        private readonly string _username;

        /// <summary> 
        /// Clasa prezinta 2 constructori care permit initializarea interfetei dar si implementarea 
        /// functinalitatii de tip ,,Logat ca"
        /// </summary> 
        public Manager()
        {
            InitializeComponent();
        }
        public Manager(string name)
        {
            InitializeComponent();
            _username = name;
            labelUser.Text = name;
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
        }

        /// <summary> 
        /// La incarcarea interfetei(e.i.conectarea unui utilizator cu rol de manager)
        /// se face initializarea elementelor grafice prezente de tip comboBox si/sau 
        /// stabilirea valorii atributului enabled pentru groupBox-uri si/sau alte elemente
        /// care, dupa logica de implementare, trebuie definit.
        /// </summary>
        private void Manager_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter sda1 = new OleDbDataAdapter("Select * FROM IP_Proiect.dbo.user_tables  WHERE table_name != 'LOGIN' AND table_name != 'REGISTRE' AND table_name != 'DATE_STUDENTI' AND table_name != 'DOSARE'", _conexiune.getConnection());
            DataTable dt1= new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBoxTabele.Items.Add(dr["table_name"].ToString());
            }

            OleDbDataAdapter sda2 = new OleDbDataAdapter("Select nume_camin FROM IP_Proiect.dbo.camine order by id_camin", _conexiune.getConnection());
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                comboBoxCamin.Items.Add(dr["nume_camin"].ToString());
            }

            groupBoxCamine.Enabled = false;
            groupBoxConducere.Enabled = false;

            //incarcare combobox luna
            comboBoxLuna.Items.Add("octombrie");
            comboBoxLuna.Items.Add("noiembrie");
            comboBoxLuna.Items.Add("decembrie");
            comboBoxLuna.Items.Add("ianuarie");
            comboBoxLuna.Items.Add("februarie");
            comboBoxLuna.Items.Add("martie");
            comboBoxLuna.Items.Add("aprilie");
            comboBoxLuna.Items.Add("mai");
            comboBoxLuna.Items.Add("iunie");
            comboBoxLuna.Items.Add("iulie");
        }

        /// <summary> 
        /// Pentru automatizarea completarii campurilor necesare insert-urilor/update-urilor/delete pentru fiecare 
        /// tabela in parte, se implementeaza o selectie automata din dataGridView care face posibil autocompletarea textbox-urilor
        /// in cauza.
        /// </summary>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewManager.Rows[e.RowIndex];
                switch (comboBoxTabele.Text)
                {
                    case "CONDUCERE":
                        textBoxAdmin.Text = row.Cells["NUME_ADMINISTRATOR"].Value.ToString();
                        textBoxProdecan.Text = row.Cells["NUME_PRODECAN"].Value.ToString();
                        textBoxPresedinte.Text = row.Cells["NUME_PRESEDINTE"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_CONDUCERE"].Value.ToString());
                        break;
                }
            }
        }

        /// <summary>
        /// Preia datele din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void afisareEntitate()
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM  IP_Proiect.dbo." + comboBoxTabele.Text, _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewManager.DataSource = ds;
            this.dataGridViewManager.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Functia selecteaza tabela din care se vor prelua datele in continuare
        /// </summary>
        private void buttonAfiseaza_Click(object sender, EventArgs e)
        {
            switch(comboBoxTabele.Text)
            {
                case "CAMERE":
                    groupBoxCamine.Enabled = false;
                    groupBoxConducere.Enabled = false;
                    afisareEntitate();
                    break;
                case "CAMINE":
                    groupBoxCamine.Enabled = true;
                    groupBoxConducere.Enabled = false;
                    comboBoxLiber.Enabled = false;
                    afisareEntitate();
                    break;
                case "CONDUCERE":
                    groupBoxCamine.Enabled = false;
                    groupBoxConducere.Enabled = true;
                    afisareEntitate();
                    break;
                case "STUDENTI":
                    groupBoxCamine.Enabled = false;
                    groupBoxConducere.Enabled = false;
                    afisareEntitate();
                    break;

            }
        }

        /// <summary>
        /// Actionarea functiei aduce interfata la starea initiala
        /// </summary>
        private void ClearData()
        {
            textBoxAdmin.Text = "";
            textBoxProdecan.Text = "";
            textBoxPresedinte.Text = "";

        }

        /// <summary>
        /// Functia modifica datele existente despre o conducere speficata
        /// </summary>
        private void buttonModifica_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE IP_Proiect.dbo.CONDUCERE set nume_prodecan ='" + textBoxProdecan.Text +
                                                               "', nume_administrator = '" + textBoxAdmin.Text +
                                                               "', nume_presedinte = '" + textBoxPresedinte.Text +
                                                               "'  WHERE id_conducere = " + ID , _conexiune.getConnection());

            cmd.Parameters.AddWithValue("@ID_CONDUCERE", ID);
            cmd.ExecuteNonQuery();
            //creare cont de administrator in cazul in care nu are
            creareCont(textBoxAdmin.Text.ToString());

            MessageBox.Show("ACTIVITATE INCHEIATĂ CU SUCCES! \n Modificarea tabelei CONDUCERE s-a realizat cu succes!");
            afisareEntitate();
        }

        /// <summary>
        /// Functia inchide programul
        /// </summary>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();

            _conexiune.Close();
        }

        /// <summary>
        /// Functia inchide meniul managerului si il redirectioneaza la pagina de autentificare
        /// </summary>
        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            Log_bloc log = new Log_bloc();
            log.Show();
            this.Hide();
        }


        /// <summary>
        /// Functia afiseaza suma totala incasata de caminul speficicat intr-o anumita luna speficicata de manager
        /// </summary>
        private void ButtonAfisareBani_Click(object sender, EventArgs e)
        {
            if(comboBoxCamin.Text.ToString() != "")
            {
                if (comboBoxLuna.Text.ToString() != "")
                {
                    OleDbDataAdapter sda = new OleDbDataAdapter("SELECT sum(cam.tarif) AS suma_incasata " +
                                                                "FROM IP_Proiect.dbo.registre r " +
                                                                "JOIN IP_Proiect.dbo.studenti s ON r.id_student = s.id_student " +
                                                                "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                                "JOIN IP_Proiect.dbo.camine c ON c.id_camin = cam.id_camin " +
                                                                "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' AND r." + comboBoxLuna.Text + " = 1 ",
                                                                _conexiune.getConnection());
                    DataSet ds = new DataSet();
                    ds.Tables.Add(comboBoxTabele.Text);
                    sda.Fill(ds, comboBoxTabele.Text);
                    this.dataGridViewManager.DataSource = ds;
                    this.dataGridViewManager.DataMember = comboBoxTabele.Text;
                }
                else
                {
                    MessageBox.Show("Selectați luna pentru care doriți să se efectueze calculele!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        }

        /// <summary>
        /// Functia afiseaza datele despre camere din caminul specificat
        /// </summary>
        int id_camera = 0;
        int nr_studenti = 0;
        private void buttonAfisareCamere_Click(object sender, EventArgs e)
        {
            if(comboBoxCamin.Text.ToString() != "")
            {
                comboBoxLiber.Enabled = true;
                int stud_maxim = 0;
                OleDbDataAdapter stud_total = new OleDbDataAdapter("SELECT cam.id_camera, COUNT(d.id_student) as STUDENTI_CAZATI "
                                                                               + "FROM IP_Proiect.dbo.dosare d "
                                                                               + "JOIN IP_Proiect.dbo.studenti s on s.id_student = d.id_student "
                                                                               + "JOIN IP_Proiect.dbo.camere cam on s.id_camera = cam.id_camera "
                                                                               + "JOIN IP_Proiect.dbo.camine c on cam.id_camin = c.id_camin "
                                                                               + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBoxCamin.Text + "' "
                                                                               + "group by cam.id_camera ", _conexiune.getConnection());
                DataTable dt5 = new DataTable();
                stud_total.Fill(dt5);

                foreach (DataRow dr in dt5.Rows)
                {
                    id_camera = Convert.ToInt32(dr["ID_CAMERA"].ToString());
                    nr_studenti = Convert.ToInt32(dr["STUDENTI_CAZATI"].ToString());
                    OleDbDataAdapter camere_libere = new OleDbDataAdapter("SELECT a.nr_camera, a.id_camera as CAMERA_LIBERA "
                                                                      + "FROM IP_Proiect.dbo.camere a, IP_Proiect.dbo.nr_total b "
                                                                      + "WHERE a.id_camera = b.id_camera AND a.nr_studenti > b.stud_total "
                                                                      + "order by b.stud_total ", _conexiune.getConnection());
                    OleDbDataAdapter stud_numar = new OleDbDataAdapter("SELECT nr_studenti, nr_camera FROM IP_Proiect.dbo.camere "
                                                                     + "WHERE id_camera = " + id_camera
                                                                     + " AND id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE  nume_camin = '" + comboBoxCamin.Text + "')",
                                                                     _conexiune.getConnection());

                    DataTable dt6 = new DataTable();
                    stud_numar.Fill(dt6);
                    foreach (DataRow dr1 in dt6.Rows)
                    {
                        stud_maxim = Convert.ToInt32(dr1["nr_studenti"].ToString());
                    }

                    if (nr_studenti < stud_maxim)
                    {
                        comboBoxLiber.Items.Add(id_camera);
                    }

                }
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        
        }

        /// <summary>
        /// Functia afiseaza datele despre camera specificata
        /// </summary>
        private void buttonDetalii_Click(object sender, EventArgs e)
        {
            if(comboBoxLiber.Text.ToString() != "")
            {
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM IP_Proiect.dbo.camere WHERE id_camera = " + comboBoxLiber.Text, _conexiune.getConnection());
                DataSet ds = new DataSet();
                ds.Tables.Add(comboBoxTabele.Text);
                sda.Fill(ds, comboBoxTabele.Text);
                this.dataGridViewManager.DataSource = ds;
                this.dataGridViewManager.DataMember = comboBoxTabele.Text;
            }
            else
            {
                MessageBox.Show("Selectați camera pentru care doriți să vizionați detaliile!");
            }
        }

        /// <summary>
        /// Functia afiseaza date ordonate despre studenti dintr-un anumit camin specificat
        /// </summary>
        private void buttonAfiseazaStudenti_Click(object sender, EventArgs e)
        {
            if(comboBoxCamin.Text.ToString() != "")
            {
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT s.id_student, s.nume_student, s.facultate, s.an_studiu, cam.nr_camera " +
                                                            "FROM IP_Proiect.dbo.studenti s " +
                                                            "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                            "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                            "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' " +
                                                            "ORDER BY cam.nr_camera, s.id_student", _conexiune.getConnection());
                DataSet ds = new DataSet();
                ds.Tables.Add(comboBoxTabele.Text);
                sda.Fill(ds, comboBoxTabele.Text);
                this.dataGridViewManager.DataSource = ds;
                this.dataGridViewManager.DataMember = comboBoxTabele.Text;
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        }

        /// <summary>
        /// Functia creaza un cont de administrator conform datelor introduse
        /// </summary>
        void creareCont(string admin)
        {
            string verif = "";
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * " +
                                                        "FROM IP_Proiect.dbo.login " +
                                                        "WHERE user_tip = '" + textBoxAdmin.Text + "'", _conexiune.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                verif = dr["user_tip"].ToString();
            }
            
            if (verif == "")
            {
                OleDbCommand cont = new OleDbCommand("INSERT INTO IP_Proiect.dbo.login (user_tip,pass,rol)  " +
                                                     "VALUES ('" + admin + "', 'administratie','administrator')", _conexiune.getConnection());
                cont.ExecuteNonQuery();
                MessageBox.Show("S-a creat un cont pentru acest administrator!");
            }
        }

        /// <summary>
        /// Functia reseteaza datele afisate conform optiunilor utilizatorului
        /// </summary>
        private void buttonCurataInterfata_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        /// <summary>
        /// Functia redirectioneaza utilizatorul catre interfata Cont_info unde poate vizualiza informatii legate de contul sau
        /// </summary>
        private void buttonCont_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cont_info cont = new Cont_info(_username);
            cont.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Gestiunea activitatii campusului Help.chm");
        }
    }
}
