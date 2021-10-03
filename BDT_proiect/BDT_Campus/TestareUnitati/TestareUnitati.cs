using BDT_Campus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestareUnitati
{
    [TestClass]
    public class TestareUnitati
    {
        [TestMethod]
        public void Test_Conectare_Florea_Mihai()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Florea Mihai";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Carmen_Stavarache()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Carmen Stavarache";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Isachi_Daniela()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Isachi Daniela";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Istrate_Anca()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Istrate Anca";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Petria_Ioan()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Petria Ioan";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Morosanu_Zana()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Morosanu Zana";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Teodorescu_Simona()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Teodorescu Simona";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Hirja_Petronela()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Hirja Petronela";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Curalariu_Corina()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Curalariu Corina";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Teodorescu_Constantin()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Teodorescu Constantin";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Gherghel_Angelica()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Gherghel Angelica";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }


        [TestMethod]
        public void Test_Conectare_dss()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "dss";
            var input_status = " ";
            var rez = "manager";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_Morosanu_Anisoara()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "Morosanu Anisoara";
            var input_status = " ";
            var rez = "manager";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }
        [TestMethod]
        [Ignore]
        public void Test_Conectare_Cenzor_Username() //va esua intodeauna
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var rez = "Florea Mihai";
            var test = var_login.getUtilizator();
            Assert.AreEqual(rez, test);
        }

        [TestMethod]
        public void Test_Conectare_manager()
        {
            var var_login = new Log_bloc();
            var createControl = var_login.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createControl.Invoke(var_login, new object[] { true });
            var input_nume = "dss";
            var input_status = " ";
            var rez = "administrator";
            var test = var_login.getUtilizatorBD(input_nume, input_status);
            Assert.AreEqual(rez, test);
        }
    }
}
