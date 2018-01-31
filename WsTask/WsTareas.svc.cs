using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;
using Repository.Contract;
using Repository.Repositories;


namespace WsTask
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WsTareas : IWsTareas
    {
        IUsuarios oIUsuarios;
        ITareas oITareas;


        #region IWsTareas Members User

        public void CreateUser(User oUser)
        {
            try
            {
                oIUsuarios = new Usuarios();
                oIUsuarios.CreateUser(oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteUser(User oUser)
        {

            try
            {
                oIUsuarios = new Usuarios();
                oIUsuarios.DeleteUser(oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditUser(User oUser)
        {
            try
            {
                oIUsuarios = new Usuarios();
                oIUsuarios.EditUser(oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUse(User oUser)
        {
            try
            {
                oIUsuarios = new Usuarios();
                return oIUsuarios.GetUse(oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUserLogin(User oUser)
        {
            try
            {
                oIUsuarios = new Usuarios();
                return oIUsuarios.GetUserLogin(oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> ListUsers()
        {
            try
            {
                oIUsuarios = new Usuarios();
                return oIUsuarios.ListUsers();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

        #region IWsTareas Members Task


        public void CreateTask(Task oTask, User oUser)
        {
            try
            {
                oITareas = new Tareas();
                oITareas.CreateTask(oTask, oUser);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditTask(Task oTask)
        {
            try
            {
                oITareas = new Tareas();
                oITareas.EditTask(oTask);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task GetTask(Task oTask)
        {
            try
            {
                oITareas = new Tareas();
                return oITareas.GetTask(oTask);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Task> ListTasks()
        {
            try
            {
                oITareas = new Tareas();
                return oITareas.ListTasks();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteTask(Task oTask)
        {
            try
            {
                oITareas = new Tareas();
                oITareas.DeleteTask(oTask);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
