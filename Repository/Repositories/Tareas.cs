using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Context;
using Repository.Contract;

namespace Repository.Repositories
{
    public class Tareas : ITareas
    {
        #region ITareas Members

        public void CreateTask(Entities.Task oTask, Entities.User oUser)
        {
            try
            {
                int idUser = 0;
                int.TryParse(oUser.id, out idUser);

                DateTime _dateStart = DateTime.Now;
                DateTime.TryParse(oTask.fechaCreacion, out _dateStart);

                DateTime _dateEnd = DateTime.Now;
                DateTime.TryParse(oTask.fechaVencimiento, out _dateEnd);


                tblTask otblTask = new tblTask()
                {
                    ta_Nombre = oTask.nombre,
                    te_Descripcion = oTask.descripcion,
                    te_Estado = true,
                    te_FechaCreacion = _dateStart,
                    te_FechaVencimiento = _dateEnd,
                    te_UsuarioFk = idUser
                };
                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    ctx.tblTask.Add(otblTask);
                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditTask(Entities.Task oTask)
        {
            try
            {
                int idTarea = 0;
                int.TryParse(oTask.id, out idTarea);

                bool stateTask = false;
                bool.TryParse(oTask.estado, out stateTask);

                DateTime _dateStart = DateTime.Now;
                DateTime.TryParse(oTask.fechaCreacion, out _dateStart);

                DateTime _dateEnd = DateTime.Now;
                DateTime.TryParse(oTask.fechaVencimiento, out _dateEnd);

                tblTask otblTask = new tblTask();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblTask = ctx.tblTask.Where(u => u.ta_TareaPk == idTarea).FirstOrDefault();
                    otblTask.ta_Nombre = oTask.nombre;
                    otblTask.te_Descripcion = oTask.descripcion;
                    otblTask.te_Estado = stateTask;
                    otblTask.te_FechaCreacion = _dateStart;
                    otblTask.te_FechaVencimiento = _dateEnd;

                    ctx.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.Task GetTask(Entities.Task oTask)
        {
            try
            {
                int idTarea = 0;
                int.TryParse(oTask.id, out idTarea);

                tblUsers otblUsers = new tblUsers();
                tblTask otblTask = new tblTask();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblTask = ctx.tblTask.Where(u => u.ta_TareaPk == idTarea).FirstOrDefault();

                    if (otblTask != null)
                    {
                        otblUsers = ctx.tblUsers.Where(o => o.us_Users_Pk == otblTask.te_UsuarioFk).FirstOrDefault();

                        oTask.id = otblTask.ta_TareaPk.ToString();
                        oTask.nombre = otblTask.ta_Nombre;
                        oTask.descripcion = otblTask.te_Descripcion;
                        oTask.fechaCreacion = (otblTask.te_FechaCreacion == null) ? DateTime.Now.ToString() : otblTask.te_FechaCreacion.ToString();
                        oTask.fechaVencimiento = (otblTask.te_FechaVencimiento == null) ? DateTime.Now.ToString() : otblTask.te_FechaVencimiento.ToString();
                        oTask.estado = otblTask.te_Estado.ToString();

                        if (otblUsers != null)
                        {
                            oTask.user = new Entities.User()
                            {
                                id = otblUsers.us_Users_Pk.ToString(),
                                nombre = otblUsers.us_Name,
                                apellido = otblUsers.us_LastName,
                                userName = otblUsers.us_UserName
                            };

                        }
                    }

                }

                return oTask;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Entities.Task> ListTasks()
        {
            try
            {
                List<Entities.Task> listTasks = new List<Entities.Task>();
                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    listTasks = (from t in ctx.tblTask
                                 join u in ctx.tblUsers on t.te_UsuarioFk equals u.us_Users_Pk
                                 where t.te_Estado == true
                                 select new Entities.Task()
                                 {
                                     id = t.ta_TareaPk.ToString(),
                                     nombre = t.ta_Nombre,
                                     descripcion = t.te_Descripcion,
                                     estado = t.te_Estado.ToString(),
                                     fechaCreacion = t.te_FechaCreacion.ToString(),
                                     fechaVencimiento = t.te_FechaVencimiento.ToString(),
                                     user = new Entities.User() 
                                     {
                                         id = u.us_Users_Pk.ToString(),
                                         userName  = u.us_UserName
                                     }
                                 }).ToList();
                }

                return listTasks;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteTask(Entities.Task oTask)
        {
            try
            {
                int idTarea = 0;
                int.TryParse(oTask.id, out idTarea);

                tblTask otblTask = new tblTask();

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    otblTask = ctx.tblTask.Where(u => u.ta_TareaPk == idTarea).FirstOrDefault();
                    otblTask.te_Estado = false;
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
