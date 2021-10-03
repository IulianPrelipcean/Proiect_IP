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

using System.Data.OleDb;

namespace ConexiuneBD
{
    public class ConexiuneBD
    {
        private static ConexiuneBD _instance;
        private OleDbConnection con;

        private ConexiuneBD()
        {
            con = new OleDbConnection("Provider=MSOLEDBSQL;Data Source=(localdb)\\MSSQLLocalDB;Catalog=IP_Proiect;Persist Security Info=True;User ID=test;Password=test");
            con.Open();
        }

        public static ConexiuneBD Instance()
        {
            if (_instance == null)
                _instance = new ConexiuneBD();
            return _instance;
        }

        public void Close()
        {
            con.Close();
        }

        public OleDbConnection getConnection()
        {
            return con;
        }
    }


}
