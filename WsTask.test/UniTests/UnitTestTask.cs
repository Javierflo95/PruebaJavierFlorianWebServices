using System;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WsTask.test.UniTests
{
    [TestClass]
    public class UnitTestTask
    {
        WsTareas oWsTareas = new WsTareas();
        UnitTestUser oUnitTestUser = new UnitTestUser();

        [TestMethod]
        public void CreateTask()
        {

            Task otblTask = new Task()
            {
                nombre = "Tarea Unit Test",
                descripcion = "Tarea desde prueba unitaria",
                estado = "true",
                fechaCreacion = DateTime.Today.ToString(),
                fechaVencimiento = DateTime.Today.AddDays(1).ToString(),
            };

            oWsTareas.CreateTask(otblTask, oUnitTestUser.TestGetUser());
        }
        //public void EditTask();
        //public void GetTask();
        //public void ListTasks();
        //public void DeleteTask();
    }
}
