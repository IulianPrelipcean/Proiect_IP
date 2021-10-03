/**************************************************************************
 *                                                                        *
 *  File:        Administrator.cs                                         *
 *  Copyright:   (c) 2021, Mihaela PAVĂL, Iulian PRELIPCEAN, Claudiu ȚAGA *
 *  E-mail:      mihaela-irina.paval@student.tuiasi.ro                    *
 *  Description: Interface Administrator for administrator users.         *
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
    /// Clasa Administrator a fost utilizata pentru implementarea functionalitatilor atribute utilizatorilor cu rol de administrator.
    /// </summary>  
    public partial class Administrator : Form
    {
        /// <summary> 
        /// Interfata curenta permite doar afisarea si posibilitatea modificarii informatiilor referitoare la camerele si  
        /// studentii cazati in acestea
        /// </summary>

        int ID = 0;

        private readonly ConexiuneBD.ConexiuneBD _conexiune;
        private readonly string _username;

        /// <summary> 
        /// Clasa prezinta 2 constructori care permit initializarea interfetei dar si implementarea 
        /// functinalitatii de tip ,,Logat ca"
        /// </summary> 
        /// 
        public Administrator()
        {
            InitializeComponent();
            
        }
        public Administrator(string name)
        {
            InitializeComponent();
            _username = name;
            labelUser.Text = name;
            _conexiune = ConexiuneBD.ConexiuneBD.Instance();
        }

        /// <summary> 
        /// La incarcarea interfetei(e.i.conectarea unui utilizator cu rol de administrator)
        /// se face initializarea elementelor grafice prezente de tip comboBox si/sau 
        /// stabilirea valorii atributului enabled pentru groupBox-uri si/sau alte elemente
        /// care, dupa logica de implementare, trebuie definit.
        /// </summary>
        private void Admin_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("Select * FROM IP_Proiect.dbo.user_tables  WHERE table_name!='CONDUCERE' AND table_name!='CAMINE' AND table_name!='LOGIN' ",
                _conexiune.getConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxTabele.Items.Add(dr["table_name"].ToString());
            }

            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT c.nume_camin FROM IP_Proiect.dbo.camine c JOIN IP_Proiect.dbo.conducere co ON co.id_conducere = c.id_conducere  WHERE co.nume_administrator = '" + _username + "'", _conexiune.getConnection());
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBoxCamin.Items.Add(dr["nume_camin"].ToString());
            }
            
            groupBoxCamere.Enabled = false;
            groupBoxStudenti.Enabled = false;
            groupBoxDateStudenti.Enabled = false;
            groupBoxDosare.Enabled = false;
            groupBoxRegistre.Enabled = false;
            textBoxNrReferate.Enabled = false;
            comboBoxStatus.Enabled = false;
            //incarcare tarif in combo, conform bazei de date
            comboBoxTarif.Items.Add("120");
            comboBoxTarif.Items.Add("130");
            comboBoxTarif.Items.Add("135");
            comboBoxTarif.Items.Add("150");
            comboBoxTarif.Items.Add("200");
            comboBoxTarif.Items.Add("270");
            //incarcare tip_camera in combo, conform bazei de date
            comboBoxTipCamera.Items.Add("Cvadubla");
            comboBoxTipCamera.Items.Add("Dubla");
            comboBoxTipCamera.Items.Add("Tripla");
            comboBoxTipCamera.Items.Add("Single");
            comboBoxTipCamera.Items.Add("Oficiu");
            comboBoxTipCamera.Items.Add("Garsoniera");
            //incarcare tip_baie in combo, conform bazei de date
            comboBoxTipBaie.Items.Add("Comuna");
            comboBoxTipBaie.Items.Add("Modul");
            comboBoxTipBaie.Items.Add("Proprie");
            //incarcare facultate in combo, conform bazei de date
            comboBoxFacultate.Items.Add("Facultatea de Arhitectura");
            comboBoxFacultate.Items.Add("Facultatea de Automatica si Calculatoare");
            comboBoxFacultate.Items.Add("Facultatea de Constructii de Masini si Management Industrial");
            comboBoxFacultate.Items.Add("Facultatea de Constructii si Instalatii");
            comboBoxFacultate.Items.Add("Facultatea de Design Industrial si Managementul Afacerilor");
            comboBoxFacultate.Items.Add("Facultatea de Electronica, Telecomunicatii si Tehnologia Informatiei");
            comboBoxFacultate.Items.Add("Facultatea de Inginerie Chimica si Protectia Mediului");
            comboBoxFacultate.Items.Add("Facultatea de Inginerie Electrica, Energetica si Informatica Aplicata");
            comboBoxFacultate.Items.Add("Facultatea de Mecanica");
            comboBoxFacultate.Items.Add("Facultatea de Stiinta si Ingineria Materialelor");
            //incarcare an_studiu in combo, conform bazei de date
            comboBoxAnStudiu.Items.Add("I");
            comboBoxAnStudiu.Items.Add("II");
            comboBoxAnStudiu.Items.Add("III");
            comboBoxAnStudiu.Items.Add("IV");
            comboBoxAnStudiu.Items.Add("V");
            comboBoxAnStudiu.Items.Add("VI");
            comboBoxAnStudiu.Items.Add("Master I");
            comboBoxAnStudiu.Items.Add("Master II");
            comboBoxAnStudiu.Items.Add("Doctorat I");
            comboBoxAnStudiu.Items.Add("Doctorat II");
            //incarcare status in combo, conform bazei de date
            comboBoxStatus.Items.Add("Cazat");
            comboBoxStatus.Items.Add("Decazat");
            //incarcare combobox_luna
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
            //incarcare combobox_cazati_decazati
            comboBoxCazatiDecazati.Items.Add("Cazat");
            comboBoxCazatiDecazati.Items.Add("Decazat");
        }

        /// <summary>
        /// Preia camerele libere din caminul selectat si le adauga intr-un combobox
        /// </summary>
        void AfisareCamereLibere()
        {
            int id_camera = 0;
            int nr_studenti = 0;
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
                                                                  + "FROM IP_Proiect.dbo.camere a, nr_total b "
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
        /// <summary>
        /// Functia implementeaza posibilitatea de modificare a tabelelor la care administratorul are drept de acces 
        /// </summary>
        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            if(comboBoxCamin.Text.ToString() != "")
            {
                if(comboBoxTabele.Text.ToString() != "")
                {
                    int flag = 0;
                    switch (comboBoxTabele.Text)
                    {
                        case "CAMERE":

                            try
                            {
                                OleDbCommand insert = new OleDbCommand
                                {
                                    Connection = _conexiune.getConnection()
                                }; //numarul de camere deja inserate in caminul x

                                int camere_total = 0;
                                int camere = 0;
                                int capacitate_camera = 0;
                                OleDbDataAdapter camere1 = new OleDbDataAdapter("SELECT nr_camere FROM IP_Proiect.dbo.camine  WHERE id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE nume_camin = '" + comboBoxCamin.Text + "')", _conexiune.getConnection());
                                OleDbDataAdapter camere2 = new OleDbDataAdapter("SELECT count(id_camera) as NUMAR_CAMERE FROM IP_Proiect.dbo.camere  WHERE id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE nume_camin = '" + comboBoxCamin.Text + "') group by id_camin", _conexiune.getConnection());
                                OleDbDataAdapter capacitate = new OleDbDataAdapter("SELECT capacitate_camere FROM IP_Proiect.dbo.camine WHERE nume_camin = '" + comboBoxCamin.Text + "'", _conexiune.getConnection());
                                DataTable dt1 = new DataTable();
                                DataTable dt2 = new DataTable();
                                DataTable dt3 = new DataTable();
                                camere1.Fill(dt1);
                                camere2.Fill(dt2);
                                capacitate.Fill(dt3);

                                foreach (DataRow dr in dt1.Rows)
                                {
                                    camere_total = Convert.ToInt32(dr["nr_camere"].ToString());

                                }
                                foreach (DataRow dr in dt2.Rows)
                                {
                                    camere = Convert.ToInt32(dr["numar_camere"].ToString());
                                }

                                foreach (DataRow dr in dt3.Rows)
                                {
                                    capacitate_camera = Convert.ToInt32(dr["capacitate_camere"].ToString());
                                }

                                if (camere < camere_total)
                                {
                                    if (Convert.ToInt32(textBoxNrStudenti.Text.ToString()) <= capacitate_camera)
                                    {
                                        insert.CommandText = "INSERT into IP_Proiect.dbo.camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, id_camin)" +
                                                       "VALUES('"
                                                       + textBoxNrCamera.Text + "', "
                                                       + textBoxNrStudenti.Text + ", "
                                                       + comboBoxTarif.Text + ", '"
                                                       + comboBoxTipCamera.Text + "', '"
                                                       + comboBoxTipBaie.Text + "', "
                                                       + "(SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE nume_camin = '" + comboBoxCamin.Text + "')" +
                                                       ")";
                                        insert.ExecuteNonQuery();

                                        MessageBox.Show("ACȚIUNE INCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                        AfisareEntitateCamere();
                                    }
                                    else
                                    {
                                        MessageBox.Show("ERR! În căminul " + comboBoxCamin.Text + " pot fi inserate doar camere \na caror număr de studenți este mai mic sau egal cu " + capacitate_camera + "!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ERR: Nu mai pot fi adăugate camere în acest cămin!");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reintroduceți!");
                            }
                            break;

                        case "STUDENTI":
                            try
                            {
                                OleDbCommand insert = new OleDbCommand
                                {
                                    Connection = _conexiune.getConnection()
                                };
                                int studenti_maxim = 0;
                                int studenti_total = 0;
                                string decazare_maxim = "";

                                OleDbDataAdapter studenti1 = new OleDbDataAdapter("SELECT nr_studenti FROM IP_Proiect.dbo.camere "
                                                                                 + "WHERE id_camera = " + textBoxCameraStudenti.Text
                                                                                 + " AND id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE  nume_camin = '" + comboBoxCamin.Text + "')",
                                                                                 _conexiune.getConnection());
                                OleDbDataAdapter studenti2 = new OleDbDataAdapter("SELECT COUNT(d.id_student) AS NUMAR_STUDENTI "
                                                                                  + "FROM IP_Proiect.dbo.dosare d "
                                                                                  + "JOIN IP_Proiect.dbo.studenti s on s.id_student = d.id_student "
                                                                                  + "JOIN IP_Proiect.dbo.camere cam on s.id_camera = cam.id_camera "
                                                                                  + "JOIN IP_Proiect.dbo.camine c on cam.id_camin = c.id_camin "
                                                                                  + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBoxCamin.Text
                                                                                  + "' AND cam.id_camera = " + textBoxCameraStudenti.Text, 
                                                                                  _conexiune.getConnection());
                                OleDbDataAdapter maxim = new OleDbDataAdapter("SELECT MAX(data_decazare)AS MAXIM " +
                                                                            "FROM IP_Proiect.dbo.studenti s " +
                                                                            "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                                            "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                                            "WHERE cam.id_camera = "+ textBoxCameraStudenti.Text + " AND c.nume_camin = '"+ comboBoxCamin.Text + "'",
                                                                            _conexiune.getConnection());
                                DataTable dt3 = new DataTable();
                                DataTable dt4 = new DataTable();
                                DataTable dtdecazare = new DataTable();
                                studenti1.Fill(dt3);
                                studenti2.Fill(dt4);
                                maxim.Fill(dtdecazare);
                                foreach (DataRow dr in dt3.Rows)
                                {
                                    studenti_maxim = Convert.ToInt32(dr["nr_studenti"].ToString());

                                }
                                foreach (DataRow dr in dt4.Rows)
                                {
                                    studenti_total = Convert.ToInt32(dr["numar_studenti"].ToString());
                                }
                                foreach (DataRow dr in dtdecazare.Rows)
                                {
                                    if(dr["maxim"].ToString() == "")
                                    {
                                        decazare_maxim = "00/00/0000";
                                    }
                                    else
                                    {
                                        decazare_maxim = dr["maxim"].ToString();
                                    }
                                }
                                

                                string[] data_cazare = textBoxDataCazare.Text.Split('/');
                                string[] data_decazare = decazare_maxim.Split('/');
                                string[] an_data_decazare = data_decazare[2].Split(' ');
                                if (Convert.ToInt32(an_data_decazare[0].ToString()) < Convert.ToInt32(data_cazare[2].ToString()))
                                {
                                    flag = 1;
                                }
                                if (Convert.ToInt32(an_data_decazare[0].ToString()) == Convert.ToInt32(data_cazare[2].ToString()))
                                {
                                    if (Convert.ToInt32(data_decazare[0].ToString()) < Convert.ToInt32(data_cazare[0].ToString()))
                                    {
                                        flag = 1;
                                    }
                                    if (Convert.ToInt32(data_cazare[0].ToString()) == Convert.ToInt32(data_decazare[0].ToString()))
                                    {
                                        if (Convert.ToInt32(data_decazare[1].ToString()) <= Convert.ToInt32(data_cazare[1].ToString()))
                                        {
                                            flag = 1;
                                        }
                                    }
                                }
                                if(flag == 1)
                                {
                                    if (studenti_total < studenti_maxim)
                                    {
                                        insert.CommandText = "INSERT INTO IP_Proiect.dbo.Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, id_camera) "
                                                         + "VALUES('"
                                                         + textBoxNumeStudent.Text + "', '"
                                                         + comboBoxFacultate.Text + "', '"
                                                         + comboBoxAnStudiu.Text + "', '"
                                                         + textBoxNrTelefon.Text + "', '"
                                                         + textBoxAdresaEmail.Text + "', '"
                                                         + textBoxContBancar.Text + "', "
                                                         + "TO_DATE('" + textBoxDataCazare.Text + "', 'MM/DD/YYYY'), "
                                                         //+ "TO_DATE('" + aux.ToString() + "', 'MM/DD/YYYY'), "
                                                         + textBoxCameraStudenti.Text
                                                         + ")";

                                        insert.ExecuteNonQuery();
                                        OleDbCommand new_registru = new OleDbCommand("INSERT INTO IP_Proiect.dbo.registre (octombrie, noiembrie, decembrie, ianuarie, februarie, martie, aprilie, mai, iunie, iulie, id_student) " +
                                                                                     "VALUES(0,0,0,0,0,0,0,0,0,0,(SELECT id_student FROM IP_Proiect.dbo.studenti WHERE nume_student='" + textBoxNumeStudent.Text + "'))",
                                                                                     _conexiune.getConnection());
                                        new_registru.ExecuteNonQuery();
                                        OleDbCommand new_dosar = new OleDbCommand("INSERT into IP_Proiect.dbo.dosare (nr_avertismente, nr_referate, status, id_student) " +
                                                                                  "VALUES(0, 0, 'Cazat', (SELECT id_student FROM IP_Proiect.dbo.studenti WHERE nume_student='" + textBoxNumeStudent.Text + "'))", 
                                                                                  _conexiune.getConnection());
                                        new_dosar.ExecuteNonQuery();

                                        MessageBox.Show("ACȚIUNE ÎNCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                        MessageBox.Show("NU UITAȚI SĂ INTRODUCEȚI ȘI DATELE STUDENTULUI " + textBoxNumeStudent.Text + "!");

                                        AfisareEntitateStudenti();
                                    }
                                    else
                                    {
                                        comboBoxLiber.Enabled = true;
                                        MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");

                                        AfisareCamereLibere();
                                    }
                                }
                                else
                                {
                                    comboBoxLiber.Enabled = true;
                                    MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");

                                    AfisareCamereLibere();
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reîntroduceți!");
                            }
                            break;

                        case "DATE_STUDENTI":
                            try
                            {
                                OleDbCommand insert = new OleDbCommand
                                {
                                    Connection = _conexiune.getConnection(),

                                    CommandText = "insert into IP_Proiect.dbo.DATE_STUDENTI values('"
                                    + textBoxCnp.Text + "', '"
                                    + textBoxCiSerie.Text + "','"
                                    + textBoxCiNumar.Text + "','"
                                    + textBoxAdresa.Text + "',"
                                    + textBoxNumeDateStudent.Text
                                    + ")"
                                };

                                insert.ExecuteNonQuery();
                               
                                MessageBox.Show("ACȚIUNE ÎNCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                AfisareEntitateDateStudenti();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reintroduceți!");
                            }
                            break;


                        case "DOSARE":
                        case "REGISTRE":
                            MessageBox.Show("ERR! \n NU se poate realiza inserarea pentru aceste tipuri de entități! \n Inserarea în aceste entități este asigurată de Baza de Date \n Puteți selecta una din următoarele \n CAMERE\nSTUDENTI\nDATE_STUDENTI.");
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }

        /// <summary>
        /// Preia datele referitoare la tabela Camere din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void AfisareEntitateCamere()
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM IP_Proiect.dbo.camere WHERE id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine WHERE nume_camin = '" + comboBoxCamin.Text + "')", 
                _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Preia datele referitoare la tabela Studenti din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void AfisareEntitateStudenti()
        {
            comboBoxLiber.Enabled = false;
            comboBoxNeachitat.Enabled = false;
            
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT s.id_student, s.id_camera, s.nume_student, s.facultate, s.an_studiu, s.nr_telefon, s.adresa_email, s.cont_banca, s.data_cazare, s.data_decazare, cam.nr_camera " +
                                                        "FROM IP_Proiect.dbo.studenti s " +
                                                        "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' " +
                                                        "ORDER BY cam.id_camera", 
                                                        _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Preia datele referitoare la tabela DateStudenti din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void AfisareEntitateDateStudenti()
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT d.id_student, s.nume_student, d.CNP, d.seria_CI, d.nr_CI, d.adresa_domiciliu " +
                                                        "FROM IP_Proiect.dbo.date_studenti d " +
                                                        "JOIN IP_Proiect.dbo.studenti s ON d.id_student = s.id_student " +
                                                        "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' " +
                                                        "ORDER BY cam.id_camera", 
                                                        _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Preia datele referitoare la tabela Dosare din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void AfisareEntitateDosare()
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT d.id_student,s.nume_student, d.nr_avertismente, d.nr_referate, d.status " +
                                                        "FROM IP_Proiect.dbo.dosare d " +
                                                        "JOIN IP_Proiect.dbo.studenti s ON d.id_student = s.id_student " +
                                                        "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' " +
                                                        "ORDER BY cam.id_camera", 
                                                        _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Preia datele referitoare la tabela Registre din baza de date si le afiseaza sub forma tabelara intr-un dataGridView
        /// </summary>
        void AfisareEntitateRegistre()
        {
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT r.id_student, s.nume_student, r.octombrie, r.noiembrie, r.noiembrie, r.decembrie, r.ianuarie, r.februarie, r.martie, r.aprilie, r.mai, r.iunie, r.iulie " +
                                                        "FROM IP_Proiect.dbo.registre r " +
                                                        "JOIN IP_Proiect.dbo.studenti s ON r.id_student = s.id_student " +
                                                        "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBoxCamin.Text + "' " +
                                                        "ORDER BY cam.id_camera", _conexiune.getConnection());
            DataSet ds = new DataSet();
            ds.Tables.Add(comboBoxTabele.Text);
            sda.Fill(ds, comboBoxTabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
        }

        /// <summary>
        /// Functia selecteaza tabela din care se vor prelua datele in continuare
        /// </summary>
        private void buttonAfiseaza_Click(object sender, EventArgs e)
        {
            if (comboBoxCamin.Text.ToString() != "")
            {
                if (comboBoxTabele.Text.ToString() != "")
                {
                    switch (comboBoxTabele.Text)
                    {
                        case "CAMERE":
                            groupBoxCamere.Enabled = true;
                            groupBoxStudenti.Enabled = false;
                            groupBoxDateStudenti.Enabled = false;
                            groupBoxDosare.Enabled = false;
                            groupBoxRegistre.Enabled = false;
                            AfisareEntitateCamere();
                            break;

                        case "STUDENTI":
                            groupBoxCamere.Enabled = false;
                            groupBoxStudenti.Enabled = true;
                            groupBoxDateStudenti.Enabled = false;
                            groupBoxDosare.Enabled = false;
                            groupBoxRegistre.Enabled = false;
                            AfisareEntitateStudenti();
                            break;

                        case "DATE_STUDENTI":
                            groupBoxCamere.Enabled = false;
                            groupBoxStudenti.Enabled = false;
                            groupBoxDateStudenti.Enabled = true;
                            groupBoxDosare.Enabled = false;
                            groupBoxRegistre.Enabled = false;
                            AfisareEntitateDateStudenti();
                            break;

                        case "DOSARE":
                            groupBoxCamere.Enabled = false;
                            groupBoxStudenti.Enabled = false;
                            groupBoxDateStudenti.Enabled = false;
                            groupBoxDosare.Enabled = true;
                            groupBoxRegistre.Enabled = false;
                            AfisareEntitateDosare();
                            break;

                        case "REGISTRE":
                            groupBoxCamere.Enabled = false;
                            groupBoxStudenti.Enabled = false;
                            groupBoxDateStudenti.Enabled = false;
                            groupBoxDosare.Enabled = false;
                            groupBoxRegistre.Enabled = true;
                            AfisareEntitateRegistre();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }

        }

        private void buttonDeconectare_Click(object sender, EventArgs e)
        {
            Log_bloc log = new Log_bloc();
            log.Show();
            this.Hide();
        }

        /// <summary>
        /// Functia sterge  textbox-urile de pe interfata dupa utilizare. 
        /// </summary>
        private void ClearData()
        {
            switch (comboBoxTabele.Text)
            {
                case "COMISIEADMITERE":
                case "CAMERE":
                    textBoxNrCamera.Text = "";
                    textBoxNrStudenti.Text = "";
                    comboBoxTarif.Text = "";
                    comboBoxTipCamera.Text = "";
                    comboBoxTipBaie.Text = "";
                    break;

                case "STUDENTI":
                    textBoxNumeStudent.Text = "";
                    comboBoxFacultate.Text = "";
                    comboBoxAnStudiu.Text = "";
                    textBoxNrTelefon.Text = "";
                    textBoxAdresaEmail.Text = "";
                    textBoxContBancar.Text = "";
                    textBoxDataCazare.Text = "";
                    textBoxCameraStudenti.Text = "";
                    break;
                case "DATE_STUDENTI":
                    textBoxNumeDateStudent.Text = "";
                    textBoxCnp.Text = "";
                    textBoxCiSerie.Text = "";
                    textBoxCiNumar.Text = "";
                    textBoxAdresa.Text = "";
                    break;
                case "DOSARE":
                    textBoxNumeDosare.Text = "";
                    textBoxNrAvertismente.Text = "";
                    textBoxNrReferate.Text = "";
                    comboBoxStatus.Text = "";
                    break;
                case "REGISTRE":
                    textBoxNumeRegistre.Text = "";
                    break;
            }
        }

        /// <summary>
        /// Functia implemneteaza logica de crestere a numarului de avertismente si implicit a numarului de referate
        /// </summary>
        void UpdateAvertismenteReferate()
        {
            int nr_avertismente = 0;
            int nr_referate = 0;
            OleDbDataAdapter avertismente = new OleDbDataAdapter("SELECT nr_avertismente FROM IP_Proiect.dbo.dosare  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
            OleDbDataAdapter referate = new OleDbDataAdapter("SELECT nr_referate FROM IP_Proiect.dbo.dosare  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            avertismente.Fill(dt1);
            referate.Fill(dt2);

            foreach (DataRow dr in dt1.Rows)
            {
                nr_avertismente = Convert.ToInt32(dr["nr_avertismente"].ToString());

            }
            foreach (DataRow dr in dt2.Rows)
            {
                nr_referate = Convert.ToInt32(dr["nr_referate"].ToString());
            }
            if (nr_avertismente < 3)
            {
                nr_avertismente++;
                OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_avertismente= " + nr_avertismente +
                                                                    "  WHERE id_student = " + textBoxNumeRegistre.Text,
                                                                    _conexiune.getConnection());
                UPDATE_avertismente.ExecuteNonQuery();
            }

            if (nr_avertismente == 3) //daca numarul de avertismente este egal cu 3
            {
                nr_referate++;
                //fac UPDATE la numarul de referate 
                OleDbCommand UPDATE_referate = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_referate=" + nr_referate +
                                                                "  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                UPDATE_referate.ExecuteNonQuery();

                OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_avertismente= 0" +
                                                                "  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                UPDATE_avertismente.ExecuteNonQuery();

                if (nr_referate == 3) //daca numarul de referate este egal cu 3
                {
                    //fac UPDATE la statusul studentului ca fiind decazat
                    OleDbCommand status = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set status= 'Decazat'" +
                                                           "  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                    //fac UPDATE la data decazarii studentului
                    OleDbCommand decazare = new OleDbCommand("UPDATE IP_Proiect.dbo.STUDENTI set data_decazare = SYSDATE" +
                                                             "  WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());

                    status.ExecuteNonQuery();
                    decazare.ExecuteNonQuery();
                    textBoxNrReferate.Enabled = false;
                    textBoxNrAvertismente.Enabled = false;
                }

            }

            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DOSARE s-a realizat cu succes!");
            AfisareEntitateDosare();

        }

        /// <summary>
        /// Functia modifica datelor, in general dupa cheia primara existenta in fiecare tabela din baza de date.
        /// </summary>
        private void buttonModifica_Click(object sender, EventArgs e)
        {
            if (comboBoxCamin.Text.ToString() != "")
            {
                if (comboBoxTabele.Text.ToString() != "")
                {
                    if(ID != 0)
                    {
                        switch (comboBoxTabele.Text)
                        {
                            case "CAMERE":
                                groupBoxCamere.Enabled = true;
                                groupBoxStudenti.Enabled = false;
                                groupBoxDateStudenti.Enabled = false;
                                groupBoxDosare.Enabled = false;
                                groupBoxRegistre.Enabled = false;

                                //fac UPDATE
                                OleDbCommand cmd = new OleDbCommand("UPDATE IP_Proiect.dbo.CAMERE set nr_studenti= " + textBoxNrStudenti.Text +
                                                                                   ", tarif= " + comboBoxTarif.Text +
                                                                                   ", tip_camera ='" + comboBoxTipCamera.Text +
                                                                                   "', tip_baie= '" + comboBoxTipBaie.Text +
                                                                                   "'  WHERE id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE nume_camin= '" + comboBoxCamin.Text +
                                                                                   "' AND id_camera = '" + ID + "')", _conexiune.getConnection());
                               
                                cmd.Parameters.AddWithValue("@ID_CAMERA", ID);

                                int capacitate_camera = 0; OleDbDataAdapter capacitate = new OleDbDataAdapter("SELECT capacitate_camere FROM IP_Proiect.dbo.camine WHERE nume_camin = '" + comboBoxCamin.Text + "'", _conexiune.getConnection());
                                DataTable dt = new DataTable();

                                capacitate.Fill(dt);

                                foreach (DataRow dr in dt.Rows)
                                {
                                    capacitate_camera = Convert.ToInt32(dr["capacitate_camere"].ToString());
                                }

                                if (Convert.ToInt32(textBoxNrStudenti.Text.ToString()) <= capacitate_camera)
                                {
                                    cmd.ExecuteNonQuery();
                                    
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei CAMERE s-a realizat cu succes!");

                                    AfisareEntitateCamere();
                                }
                                else
                                {
                                    MessageBox.Show("ERR! În căminul " + comboBoxCamin.Text + " pot fi inserate doar camere \na caror număr de studenți este mai mic sau egal cu " + capacitate_camera + "!");
                                }


                                break;

                            case "STUDENTI":
                                groupBoxCamere.Enabled = false;
                                groupBoxStudenti.Enabled = true;
                                groupBoxDateStudenti.Enabled = false;
                                groupBoxDosare.Enabled = false;
                                groupBoxRegistre.Enabled = false;
                                //fac UPDATE
                                try
                                {
                                    OleDbCommand update = new OleDbCommand("UPDATE IP_Proiect.dbo.Studenti set nume_student = '" + textBoxNumeStudent.Text +
                                                                                             "', facultate = '" + comboBoxFacultate.Text +
                                                                                             "', an_studiu = '" + comboBoxAnStudiu.Text +
                                                                                             "', nr_telefon = '" + textBoxNrTelefon.Text +
                                                                                             "', adresa_email = '" + textBoxAdresaEmail.Text +
                                                                                             "', cont_banca = '" + textBoxContBancar.Text +
                                                                                             "', data_cazare = TO_DATE('" + textBoxDataCazare.Text + "', 'MM/DD/YYYY')" +
                                                                                             ", id_camera = " + textBoxCameraStudenti.Text +
                                                                                             " WHERE id_student = " + ID, _conexiune.getConnection());
                                   
                                    update.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    
                                    int studenti_maxim = 0;
                                    int studenti_total = 0;

                                    OleDbDataAdapter studenti1 = new OleDbDataAdapter("SELECT nr_studenti FROM IP_Proiect.dbo.camere "
                                                                                     + "WHERE id_camera = " + textBoxCameraStudenti.Text
                                                                                     + " AND id_camin = (SELECT id_camin FROM IP_Proiect.dbo.camine  WHERE  nume_camin = '" + comboBoxCamin.Text + "')", _conexiune.getConnection());
                                    OleDbDataAdapter studenti2 = new OleDbDataAdapter("SELECT COUNT(d.id_student) AS NUMAR_STUDENTI "
                                                                                      + "FROM IP_Proiect.dbo.dosare d "
                                                                                      + "JOIN IP_Proiect.dbo.studenti s on s.id_student = d.id_student "
                                                                                      + "JOIN IP_Proiect.dbo.camere cam on s.id_camera = cam.id_camera "
                                                                                      + "JOIN IP_Proiect.dbo.camine c on cam.id_camin = c.id_camin "
                                                                                      + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBoxCamin.Text
                                                                                      + "' AND cam.id_camera = " + textBoxCameraStudenti.Text, _conexiune.getConnection());
                                    DataTable dt3 = new DataTable();
                                    DataTable dt4 = new DataTable();
                                    studenti1.Fill(dt3);
                                    studenti2.Fill(dt4);

                                    foreach (DataRow dr in dt3.Rows)
                                    {
                                        studenti_maxim = Convert.ToInt32(dr["nr_studenti"].ToString());

                                    }
                                    foreach (DataRow dr in dt4.Rows)
                                    {
                                        studenti_total = Convert.ToInt32(dr["numar_studenti"].ToString());
                                    }

                                    if (studenti_total < studenti_maxim)
                                    {
                                        
                                        update.ExecuteNonQuery();
                                        AfisareEntitateStudenti();

                                    }
                                    else
                                    {
                                        comboBoxLiber.Enabled = true;
                                        MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");
                                        AfisareCamereLibere();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("ERR: Încercare de modificare invalidă! Reintroduceți!");
                                }
                                break;

                            case "DATE_STUDENTI":
                                groupBoxCamere.Enabled = false;
                                groupBoxStudenti.Enabled = false;
                                groupBoxDateStudenti.Enabled = true;
                                groupBoxDosare.Enabled = false;
                                groupBoxRegistre.Enabled = false;

                                //fac UPDATE
                                OleDbCommand cmd2 = new OleDbCommand("UPDATE IP_Proiect.dbo.DATE_STUDENTI set seria_CI='" + textBoxCiSerie.Text +
                                                                                       "', nr_CI='" + textBoxCiNumar.Text +
                                                                                       "', adresa_domiciliu ='" + textBoxAdresa.Text +
                                                                                       "'  WHERE id_student = " + ID +
                                                                                       "AND CNP = '" + textBoxCnp.Text + "'", _conexiune.getConnection());
                                
                                cmd2.Parameters.AddWithValue("@ID_STUDENT", ID); //refera id_comisie
                                cmd2.ExecuteNonQuery();
                                
                                MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DATE_STUDENTI s-a realizat cu succes!");
                                AfisareEntitateDateStudenti();
                                break;

                            case "DOSARE":
                                groupBoxCamere.Enabled = false;
                                groupBoxStudenti.Enabled = false;
                                groupBoxDateStudenti.Enabled = false;
                                groupBoxDosare.Enabled = true;
                                groupBoxRegistre.Enabled = false;

                                if (Convert.ToInt32(textBoxNrAvertismente.Text) <= 3)
                                {
                                    //UPDATE nr_avertismente pentru student
                                    OleDbCommand UPDATE_dosar = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_avertismente= " + textBoxNrAvertismente.Text +
                                                                                 "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                    UPDATE_dosar.ExecuteNonQuery();
                                    int nr_avertismente = 0;
                                    int nr_referate = 0;
                                    OleDbDataAdapter avertismente = new OleDbDataAdapter("SELECT nr_avertismente FROM IP_Proiect.dbo.dosare  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                    OleDbDataAdapter referate = new OleDbDataAdapter("SELECT nr_referate FROM IP_Proiect.dbo.dosare  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                    DataTable dt1 = new DataTable();
                                    DataTable dt2 = new DataTable();
                                    avertismente.Fill(dt1);
                                    referate.Fill(dt2);

                                    foreach (DataRow dr in dt1.Rows)
                                    {
                                        nr_avertismente = Convert.ToInt32(dr["nr_avertismente"].ToString());

                                    }
                                    foreach (DataRow dr in dt2.Rows)
                                    {
                                        nr_referate = Convert.ToInt32(dr["nr_referate"].ToString());
                                    }

                                    if (nr_avertismente == 3) //daca numarul de avertismente este egal cu 3
                                    {
                                        nr_referate++;
                                        //fac UPDATE la numarul de referate 
                                        OleDbCommand UPDATE_referate = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_referate=" + nr_referate +
                                                                                        "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                        UPDATE_referate.ExecuteNonQuery();

                                        OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set nr_avertismente= 0" +
                                                                                        "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                        UPDATE_avertismente.ExecuteNonQuery();

                                        if (nr_referate == 3) //daca numarul de referate este egal cu 3
                                        {
                                            //fac UPDATE la statusul studentului ca fiind decazat
                                            OleDbCommand status = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set status= 'Decazat'" +
                                                                                   "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                            //fac UPDATE la data decazarii studentului
                                            OleDbCommand decazare = new OleDbCommand("UPDATE IP_Proiect.dbo.STUDENTI set data_decazare = SYSDATE" +
                                                                                     "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                            textBoxNrReferate.Enabled = false;
                                            textBoxNrAvertismente.Enabled = false;

                                            status.ExecuteNonQuery();
                                            decazare.ExecuteNonQuery();

                                        }

                                    }
                                    //update la status decazat/cazat
                                    if (textBoxDecazare.Text.ToString() != "")
                                    {
                                            
                                            OleDbCommand status1 = new OleDbCommand("UPDATE IP_Proiect.dbo.DOSARE set status= 'Decazat'" +
                                                                                  "  WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                            //fac UPDATE la data decazarii studentului
                                            OleDbCommand decazare1 = new OleDbCommand("UPDATE IP_Proiect.dbo.STUDENTI set data_decazare = TO_DATE('" + textBoxDecazare.Text + "', 'MM/DD/YYYY') " +
                                                                    "WHERE id_student = " + textBoxNumeDosare.Text, _conexiune.getConnection());
                                            status1.ExecuteNonQuery();
                                            decazare1.ExecuteNonQuery();
                                    }
                                    
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DOSARE s-a realizat cu succes!");
                                    AfisareEntitateDosare();

                                }
                                else
                                {
                                    MessageBox.Show("Trebuie să introduceți o valoare mai mică sau egală cu 3 \n pentru numărul de avertismente!");
                                    groupBoxCamere.Enabled = false;
                                    groupBoxStudenti.Enabled = false;
                                    groupBoxDateStudenti.Enabled = false;
                                    groupBoxDosare.Enabled = false;
                                    groupBoxRegistre.Enabled = false;
                                }
                                break;

                            case "REGISTRE":
                                groupBoxCamere.Enabled = false;
                                groupBoxStudenti.Enabled = false;
                                groupBoxDateStudenti.Enabled = false;
                                groupBoxDosare.Enabled = false;
                                groupBoxRegistre.Enabled = true;

                                //fac UPDATE in functie de luna selectata
                                switch (comboBoxLuna.Text)
                                {
                                    case "octombrie":
                                        OleDbCommand octombrie = new OleDbCommand(" UPDATE IP_Proiect.dbo.registre set octombrie = 1 " +
                                                                                   " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        octombrie.ExecuteNonQuery();
                                        MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        break;
                                    case "noiembrie":
                                        int val_octombrie = 0;
                                        OleDbDataAdapter precedent_oct = new OleDbDataAdapter("SELECT octombrie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt1 = new DataTable();
                                        precedent_oct.Fill(dt1);
                                        foreach (DataRow dr in dt1.Rows)
                                        {
                                            val_octombrie = Convert.ToInt32(dr["octombrie"].ToString());

                                        }
                                        if (val_octombrie == 1)
                                        {
                                            OleDbCommand noiembrie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            noiembrie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "decembrie":
                                        int val_noiembrie = 0;
                                        OleDbDataAdapter precedent_noi = new OleDbDataAdapter("SELECT noiembrie FROM IP_Proiect.dbo.registre" +
                                                                                             " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt2 = new DataTable();
                                        precedent_noi.Fill(dt2);
                                        foreach (DataRow dr in dt2.Rows)
                                        {
                                            val_noiembrie = Convert.ToInt32(dr["noiembrie"].ToString());

                                        }
                                        if (val_noiembrie == 1)
                                        {
                                            OleDbCommand decembrie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            decembrie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "ianuarie":
                                        int val_decembrie = 0;
                                        OleDbDataAdapter precedent_dec = new OleDbDataAdapter("SELECT decembrie FROM IP_Proiect.dbo.registre" +
                                                                                              " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt3 = new DataTable();
                                        precedent_dec.Fill(dt3);
                                        foreach (DataRow dr in dt3.Rows)
                                        {
                                            val_decembrie = Convert.ToInt32(dr["decembrie"].ToString());

                                        }
                                        if (val_decembrie == 1)
                                        {
                                            OleDbCommand ianuarie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            ianuarie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "februarie":
                                        int val_ianuarie = 0;
                                        OleDbDataAdapter precedent_ian = new OleDbDataAdapter("SELECT ianuarie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt4 = new DataTable();
                                        precedent_ian.Fill(dt4);
                                        foreach (DataRow dr in dt4.Rows)
                                        {
                                            val_ianuarie = Convert.ToInt32(dr["ianuarie"].ToString());

                                        }
                                        if (val_ianuarie == 1)
                                        {
                                            OleDbCommand februarie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            februarie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "martie":
                                        int val_februarie = 0;
                                        OleDbDataAdapter precedent_feb = new OleDbDataAdapter("SELECT februarie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt5 = new DataTable();
                                        precedent_feb.Fill(dt5);
                                        foreach (DataRow dr in dt5.Rows)
                                        {
                                            val_februarie = Convert.ToInt32(dr["februarie"].ToString());

                                        }
                                        if (val_februarie == 1)
                                        {
                                            OleDbCommand martie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            martie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "aprilie":
                                        int val_martie = 0;
                                        OleDbDataAdapter precedent_mar = new OleDbDataAdapter("SELECT martie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt6 = new DataTable();
                                        precedent_mar.Fill(dt6);
                                        foreach (DataRow dr in dt6.Rows)
                                        {
                                            val_martie = Convert.ToInt32(dr["martie"].ToString());

                                        }
                                        if (val_martie == 1)
                                        {
                                            OleDbCommand aprilie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            aprilie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "mai":
                                        int val_aprilie = 0;
                                        OleDbDataAdapter precedent_apr = new OleDbDataAdapter("SELECT aprilie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt7 = new DataTable();
                                        precedent_apr.Fill(dt7);
                                        foreach (DataRow dr in dt7.Rows)
                                        {
                                            val_aprilie = Convert.ToInt32(dr["aprilie"].ToString());

                                        }
                                        if (val_aprilie == 1)
                                        {
                                            OleDbCommand mai = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            mai.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;

                                    case "iunie":
                                        int val_mai = 0;
                                        OleDbDataAdapter precedent_mai = new OleDbDataAdapter("SELECT mai FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt8 = new DataTable();
                                        precedent_mai.Fill(dt8);
                                        foreach (DataRow dr in dt8.Rows)
                                        {
                                            val_mai = Convert.ToInt32(dr["mai"].ToString());

                                        }
                                        if (val_mai == 1)
                                        {
                                            OleDbCommand iunie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            iunie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;
                                    case "iulie":
                                        int val_iunie = 0;
                                        OleDbDataAdapter precedent_iun = new OleDbDataAdapter("SELECT iunie FROM IP_Proiect.dbo.registre" +
                                                                                        " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                        DataTable dt9 = new DataTable();
                                        precedent_iun.Fill(dt9);
                                        foreach (DataRow dr in dt9.Rows)
                                        {
                                            val_octombrie = Convert.ToInt32(dr["iunie"].ToString());

                                        }
                                        if (val_iunie == 1)
                                        {
                                            OleDbCommand iulie = new OleDbCommand("UPDATE IP_Proiect.dbo.registre set " + comboBoxLuna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBoxNumeRegistre.Text, _conexiune.getConnection());
                                            iulie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            UpdateAvertismenteReferate();
                                        }
                                        break;
                                }

                                MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea REGISTRE s-a realizat cu succes!");
                                AfisareEntitateRegistre();
                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Selectați un rând pentru modificare!");

                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }

        /// <summary>
        /// Functia permite stergerea datelor din baza de date doar din interioru tabelelor CAMERE si STUDENTI
        /// </summary>
        private void buttonSterge_Click(object sender, EventArgs e)
        {
            if (comboBoxCamin.Text.ToString() != "")
            {
                if (comboBoxTabele.Text.ToString() != "")
                {
                    if (MessageBox.Show("Doriți continuarea acestei operațiuni? \n ESTE POSIBILĂ PIERDEREA UNUI NUMĂR MARE DE DATE DIN BAZA DE DATE", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ID != 0)
                        {
                            switch (comboBoxTabele.Text)
                            {
                                case "CAMERE":
                                    OleDbCommand sters_camera = new OleDbCommand("DELETE FROM IP_Proiect.dbo.CAMERE  WHERE id_camera= " + ID, _conexiune.getConnection());
                                    sters_camera.Parameters.AddWithValue("@ID_CAMERA", ID);
                                    sters_camera.ExecuteNonQuery();
                                    
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Ștergerea CAMEREI s-a realizat cu succes!");
                                    AfisareEntitateCamere();
                                    ClearData(); //goleste campuri 
                                    break;

                                case "STUDENTI":
                                    _conexiune.getConnection();

                                    OleDbCommand sters_registru1 = new OleDbCommand("DELETE FROM IP_Proiect.dbo.REGISTRE  WHERE id_student = " + ID, _conexiune.getConnection());
                                    sters_registru1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_registru1.ExecuteNonQuery();

                                    OleDbCommand sters_dosar1 = new OleDbCommand("DELETE FROM IP_Proiect.dbo.DOSARE  WHERE id_student = " + ID, _conexiune.getConnection());
                                    sters_dosar1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_dosar1.ExecuteNonQuery();

                                    OleDbCommand sters_date_student1 = new OleDbCommand("DELETE FROM IP_Proiect.dbo.DATE_STUDENTI  WHERE id_student = " + ID, _conexiune.getConnection());
                                    sters_date_student1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_date_student1.ExecuteNonQuery();

                                    OleDbCommand sters_student1 = new OleDbCommand("DELETE FROM IP_Proiect.dbo.STUDENTI  WHERE id_student = " + ID, _conexiune.getConnection());
                                    sters_student1.Parameters.AddWithValue("@ID_STUDENT", ID); //refera id_voluntar
                                    sters_student1.ExecuteNonQuery();

                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Ștergerea STUDENTULUI s-a realizat cu succes!");
                                    AfisareEntitateStudenti();
                                    ClearData(); //goleste campuri 
                                    break;

                                case "DOSARE":
                                case "DATE_STUDENTI":
                                case "REGISTRE":
                                    MessageBox.Show("ERR! \n NU se poate realiza ștergerea pentru aceste tipuri de entități! \n Ștergerea din aceste entități este asigurată de Baza de Date \n Puteți selecta una din următoarele \n CAMERE\nSTUDENTI.");
                                    ClearData();
                                    break;

                            }
                        }
                        else
                        {
                            MessageBox.Show("ERR! \n Selectați un rând pentru ștergere!");
                            groupBoxCamere.Enabled = false;
                            groupBoxStudenti.Enabled = false;
                            groupBoxDateStudenti.Enabled = false;
                            groupBoxDosare.Enabled = false;
                            groupBoxRegistre.Enabled = false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }

        /// <summary>
        /// Actionarea functiei aduce interfata la starea initiala
        /// </summary>
        private void buttonCurataInterfata_Click(object sender, EventArgs e)
        {
            textBoxNrCamera.Text = "";
            textBoxNrStudenti.Text = "";
            comboBoxTarif.Text = "";
            comboBoxTipCamera.Text = "";
            comboBoxTipBaie.Text = "";

            textBoxNumeStudent.Text = "";
            comboBoxFacultate.Text = "";
            comboBoxAnStudiu.Text = "";
            textBoxNrTelefon.Text = "";
            textBoxAdresaEmail.Text = "";
            textBoxContBancar.Text = "";
            textBoxDataCazare.Text = "";
            textBoxCameraStudenti.Text = "";

            textBoxNumeDateStudent.Text = "";
            textBoxCnp.Text = "";
            textBoxCiSerie.Text = "";
            textBoxCiNumar.Text = "";
            textBoxAdresa.Text = "";

            textBoxNumeDosare.Text = "";
            textBoxNrAvertismente.Text = "";
            textBoxNrReferate.Text = "";
            comboBoxStatus.Text = "";

            textBoxNumeRegistre.Text = "";
            comboBoxLuna.Text = "";

            groupBoxCamere.Enabled = false;
            groupBoxStudenti.Enabled = false;
            groupBoxDateStudenti.Enabled = false;
            groupBoxDosare.Enabled = false;
            groupBoxRegistre.Enabled = false;
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
        /// Pentru automatizarea completarii campurilor necesare insert-urilor/update-urilor/delete pentru fiecare 
        /// tabela in parte, se implementeaza o selectie automata din dataGridView care face posibil autocompletarea textbox-urilor
        /// in cauza.
        /// </summary>
        private void dataGridViewAdministrator_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAdministrator.Rows[e.RowIndex];
                switch (comboBoxTabele.Text)
                {
                    case "CAMERE":
                        textBoxNrCamera.Text = row.Cells["NR_CAMERA"].Value.ToString();
                        textBoxNrStudenti.Text = row.Cells["NR_STUDENTI"].Value.ToString();
                        comboBoxTarif.Text = row.Cells["TARIF"].Value.ToString();
                        comboBoxTipCamera.Text = row.Cells["TIP_CAMERA"].Value.ToString();
                        comboBoxTipBaie.Text = row.Cells["TIP_BAIE"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_CAMERA"].Value.ToString());
                        break;

                    case "STUDENTI":
                        textBoxNumeStudent.Text = row.Cells["NUME_STUDENT"].Value.ToString();
                        comboBoxFacultate.Text = row.Cells["FACULTATE"].Value.ToString();
                        comboBoxAnStudiu.Text = row.Cells["AN_STUDIU"].Value.ToString();
                        textBoxNrTelefon.Text = row.Cells["NR_TELEFON"].Value.ToString();
                        textBoxAdresaEmail.Text = row.Cells["ADRESA_EMAIL"].Value.ToString();
                        textBoxContBancar.Text = row.Cells["CONT_BANCA"].Value.ToString();
                        textBoxDataCazare.Text = row.Cells["DATA_CAZARE"].Value.ToString();
                        textBoxCameraStudenti.Text = row.Cells["ID_CAMERA"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;

                    case "DATE_STUDENTI":
                        textBoxNumeDateStudent.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        textBoxCnp.Text = row.Cells["CNP"].Value.ToString();
                        textBoxCiSerie.Text = row.Cells["SERIA_CI"].Value.ToString();
                        textBoxCiNumar.Text = row.Cells["NR_CI"].Value.ToString();
                        textBoxAdresa.Text = row.Cells["ADRESA_DOMICILIU"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;

                    case "DOSARE":
                        textBoxNumeDosare.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        textBoxNrAvertismente.Text = row.Cells["NR_AVERTISMENTE"].Value.ToString();
                        textBoxNrReferate.Text = row.Cells["NR_REFERATE"].Value.ToString();
                        comboBoxStatus.Text = row.Cells["STATUS"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;
                    case "REGISTRE":
                        textBoxNumeRegistre.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;
                }
            }
        }

        /// <summary>
        /// Functia selecteaza studentii ce au plata caminului restanta pentru o luna indicata si ii afiseaza sub forma tabelara intr-un dataGrid
        /// </summary>
        private void buttonRestant_Click(object sender, EventArgs e)
        {
            if (comboBoxLuna.Text.ToString() != "")
            {
               OleDbDataAdapter sda = new OleDbDataAdapter("SELECT stud.id_student, stud.nume_student, cam.nr_camera " +
                                                            "FROM IP_Proiect.dbo.studenti stud " +
                                                            "JOIN IP_Proiect.dbo.camere cam ON cam.id_camera = stud.id_camera " +
                                                            "JOIN IP_Proiect.dbo.camine c ON c.id_camin = cam.id_camin " +
                                                            "JOIN IP_Proiect.dbo.registre r ON r.id_student = stud.id_student " +
                                                            "JOIN IP_Proiect.dbo.dosare d ON d.id_student = stud.id_student " +
                                                            "WHERE d.status = 'Cazat' and c.nume_camin = '" + comboBoxCamin.Text +
                                                            "' and r." + comboBoxLuna.Text + "= 0 " +
                                                            "ORDER BY cam.nr_camera", _conexiune.getConnection());
                DataSet ds = new DataSet();
                ds.Tables.Add(comboBoxTabele.Text);
                sda.Fill(ds, comboBoxTabele.Text);
                this.dataGridViewAdministrator.DataSource = ds;
                this.dataGridViewAdministrator.DataMember = comboBoxTabele.Text;
            }
            else
            {
                MessageBox.Show("ERR! \n Selectați o lună pentru afișare!");
            }
        }

        /// <summary>
        /// Functia selecteaza lunile neachitate ale studentului si le adauga intr-un comboBox
        /// </summary>
        private void buttonNeachitat_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                comboBoxNeachitat.Enabled = true;
                string[] luni_an = { "octombrie", "noiembrie", "decembrie", "ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie" };
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM IP_Proiect.dbo.registre WHERE id_student = " + ID, _conexiune.getConnection());

                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int idx = 0; idx < luni_an.Length; idx++)
                    {
                        if (Convert.ToInt32(dr[luni_an[idx]].ToString()) == 0)
                        {
                            comboBoxNeachitat.Items.Add(luni_an[idx]);
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("ERR! \n Selectați un rând pentru afișare!");

            }
        }
        /// <summary>
        /// Functia selecteaza studentii cazati/decazati (in functie de optiunea selectata din comboBox)
        /// si ii afiseaza sub forma tabelara prin intermediul unui dataGrid
        /// </summary>
        private void buttonCazati_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                if (comboBoxCazatiDecazati.Text.ToString() != "")
                {
                    OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * " +
                                                                "FROM IP_Proiect.dbo.studenti s " +
                                                                "JOIN IP_Proiect.dbo.dosare d ON s.id_student = d.id_student " +
                                                                "JOIN IP_Proiect.dbo.camere cam ON s.id_camera = cam.id_camera " +
                                                                "JOIN IP_Proiect.dbo.camine c ON cam.id_camin = c.id_camin " +
                                                                "WHERE d.status = '"+ comboBoxCazatiDecazati.Text +"' AND c.nume_camin = '" + comboBoxCamin.Text + "' AND cam.id_camera = '" + ID + "' ", _conexiune.getConnection());

                    DataSet ds = new DataSet();
                    ds.Tables.Add("studenti");
                    sda.Fill(ds, "studenti");
                    this.dataGridViewAdministrator.DataSource = ds;
                    this.dataGridViewAdministrator.DataMember = "studenti";
                }
                else
                {
                    MessageBox.Show("Selectați statusul studenților pe care doriți să ii vizionați!");
                }
            }
            else
            {
                MessageBox.Show("ERR! \n Selectați un rând pentru afișare!");

            }
        }

        /// <summary>
        /// Functia redirectioneaza utilizatorul catre interfata Cont_info unde poate vizualiza informatii contului
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

