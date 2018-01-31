using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repository.Context;
using Repository.Contract;

namespace Repository.Repositories
{

    public class Usuarios : IUsuarios
    {

        #region IUsuarios Members

        public void CreateUser(User oUser)
        {
            try
            {
                int _edad = 0;
                int.TryParse(oUser.edad, out _edad);

                bool _crearTarea = false;
                bool.TryParse(oUser.crearTarea, out _crearTarea);

                tblUsers otblUsers = new tblUsers()
                {
                    us_UserName = oUser.userName,
                    us_Age = _edad,
                    us_Name = oUser.nombre,
                    us_LastName = oUser.apellido,
                    us_Password = oUser.password,
                    us_Estado = true,
                    us_CreateTask = _crearTarea
                };
                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    ctx.tblUsers.Add(otblUsers);
                    ctx.SaveChanges();
                }

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
                int _edad = 0;
                int.TryParse(oUser.edad, out _edad);

                bool _state = false;
                bool.TryParse(oUser.estado, out _state);

                bool _crearTarea = false;
                bool.TryParse(oUser.crearTarea, out _crearTarea);

                tblUsers otblUsers = new tblUsers();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblUsers = ctx.tblUsers.Where(u => u.us_UserName == oUser.userName).FirstOrDefault();

                    otblUsers.us_Age = _edad;
                    otblUsers.us_Name = oUser.nombre;
                    otblUsers.us_LastName = oUser.apellido;
                    otblUsers.us_Estado = _state;
                    otblUsers.us_CreateTask = _crearTarea;

                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.User GetUse(User oUser)
        {
            try
            {
                tblUsers otblUsers = new tblUsers();
                List<tblTask> listTask = new List<tblTask>();
                List<Entities.Task> _listTarea = new List<Entities.Task>();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblUsers = ctx.tblUsers.Where(u => u.us_UserName == oUser.userName).FirstOrDefault();

                    if (otblUsers != null)
                    {
                        listTask = ctx.tblTask.Where(o => o.te_UsuarioFk == otblUsers.us_Users_Pk).ToList();

                        oUser.id = otblUsers.us_Users_Pk.ToString();
                        oUser.nombre = otblUsers.us_Name;
                        oUser.apellido = otblUsers.us_LastName;
                        oUser.userName = otblUsers.us_UserName;
                        oUser.edad = otblUsers.us_Age.ToString();
                        oUser.estado = otblUsers.us_Estado.ToString();
                        oUser.crearTarea = otblUsers.us_CreateTask.ToString();

                        if (listTask.Count > 0 && listTask != null)
                        {
                            foreach (var item in listTask)
                            {
                                _listTarea.Add(new Entities.Task()
                                {
                                    id = item.ta_TareaPk.ToString(),
                                    nombre = item.ta_Nombre,
                                    descripcion = item.te_Descripcion,
                                    estado = item.te_Estado.ToString(),
                                    fechaCreacion = (item.te_FechaCreacion == null) ? DateTime.Now.ToString() : item.te_FechaCreacion.ToString(),
                                    fechaVencimiento = (item.te_FechaVencimiento == null) ? DateTime.Now.ToString() : item.te_FechaVencimiento.ToString()
                                });
                            }

                            oUser.listTask = _listTarea;
                        }
                    }

                }

                return oUser;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.User GetUserLogin(User oUser)
        {
            try
            {
                tblUsers otblUsers = new tblUsers();
                List<tblTask> listTask = new List<tblTask>();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblUsers = ctx.tblUsers.Where(u => u.us_UserName == oUser.userName && u.us_Password == oUser.password && u.us_Estado == true).FirstOrDefault();

                    if (otblUsers != null)
                    {
                        oUser.id = otblUsers.us_Users_Pk.ToString();
                        oUser.nombre = otblUsers.us_Name;
                        oUser.apellido = otblUsers.us_LastName;
                        oUser.userName = otblUsers.us_UserName;
                        oUser.estado = otblUsers.us_Estado.ToString();
                        oUser.crearTarea = otblUsers.us_CreateTask.ToString();

                    }
                    else
                        oUser = new User();
                }

                return oUser;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Entities.User> ListUsers()
        {
            try
            {
                List<User> listUser = new List<User>();
                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    listUser = (from u in ctx.tblUsers
                                where u.us_Estado == true
                                select new User()
                                {
                                    id = u.us_Users_Pk.ToString(),
                                    nombre = u.us_Name,
                                    apellido = u.us_LastName,
                                    edad = u.us_Age.ToString(),
                                    userName = u.us_UserName,
                                    estado = u.us_Estado.ToString(),
                                    crearTarea = u.us_CreateTask.ToString()
                                }).ToList();
                }

                return listUser;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(User oUser)
        {
            try
            {
                tblUsers otblUsers = new tblUsers();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblUsers = ctx.tblUsers.Where(u => u.us_UserName == oUser.userName).FirstOrDefault();
                    otblUsers.us_Estado = false;
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
