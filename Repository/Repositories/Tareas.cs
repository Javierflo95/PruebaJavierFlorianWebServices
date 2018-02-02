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

        /// <summary>
        /// Crea la tarea
        /// </summary>
        /// <param name="oTask">Objeto tarea</param>
        /// <param name="oUser">Objeto usaurio</param>
        public Entities.Task CreateTask(Entities.Task oTask, Entities.User oUser)
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
                    var _tareaNueva = ctx.tblTask.Add(otblTask);
                    ctx.SaveChanges();
                    oTask.id = _tareaNueva.ta_TareaPk.ToString();
                    return oTask;
                }

            }
            catch (Exception ex)
            {
                return oTask;
            }
        }

        /// <summary>
        /// Actualiza 
        /// </summary>
        /// <param name="oTask"></param>
        public Entities.Task EditTask(Entities.Task oTask)
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

                    return oTask;
                }

            }
            catch (Exception ex)
            {
                return oTask;
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

        /// <summary>
        /// Metodo en cargado de la consulta de las tareas por usuario, y estado de finalizacion
        /// </summary>
        /// <param name="oTask"></param>
        /// <returns></returns>
        public List<Entities.Task> ListTaskbyState(Entities.Task oTask)
        {
            int idTarea = 0;
            bool _finalizada = false;
            int _idUser = 0;
           

            tblUsers otblUsers = new tblUsers();
            List<tblTask> listtblTask = new List<tblTask>();
            List<Entities.Task> listTareas = new List<Entities.Task>();

            if (oTask != null)
            {
                int.TryParse(oTask.user.id, out _idUser);
                int.TryParse(oTask.id, out idTarea);
                bool.TryParse(oTask.finalizada, out _finalizada);
            }

            try
            {

                using (PruebaTecnicaJavierFlorianEntities ctx = new PruebaTecnicaJavierFlorianEntities())
                {
                    //Trae el listado de tareas por usduario (Mis tareas)
                    if (oTask.id != null && oTask.user != null)
                    {
                        #region listado de tareas por usduario
                        var user = ctx.tblUsers.Where(u => u.us_UserName == oTask.user.userName).FirstOrDefault();

                        listtblTask = ctx.tblTask.Where(u => u.te_UsuarioFk == user.us_Users_Pk).OrderBy(f => f.te_FechaVencimiento).ToList();

                        if (listtblTask != null || listtblTask.Count() > 0)
                        {
                            foreach (var tarea in listtblTask)
                            {
                                listTareas.Add(new Entities.Task()
                                {
                                    id = tarea.ta_TareaPk.ToString(),
                                    nombre = tarea.ta_Nombre,
                                    descripcion = tarea.te_Descripcion,
                                    fechaCreacion = (tarea.te_FechaCreacion == null) ? DateTime.Now.ToString() : tarea.te_FechaCreacion.ToString(),
                                    fechaVencimiento = (tarea.te_FechaVencimiento == null) ? DateTime.Now.ToString() : tarea.te_FechaVencimiento.ToString(),
                                    estado = tarea.te_Estado.ToString()
                                });
                            }

                        }
                        #endregion
                    }
                    else if (oTask.id != null)
                    {
                        //Trae las tareas segun el estado de finalizacion 
                        listtblTask = ctx.tblTask.Where(u => u.te_Finalizada == _finalizada).ToList();

                        if (listtblTask != null || listtblTask.Count() > 0)
                        {
                            foreach (var tarea in listtblTask)
                            {
                                listTareas.Add(new Entities.Task()
                                {
                                    id = tarea.ta_TareaPk.ToString(),
                                    nombre = tarea.ta_Nombre,
                                    descripcion = tarea.te_Descripcion,
                                    fechaCreacion = (tarea.te_FechaCreacion == null) ? DateTime.Now.ToString() : tarea.te_FechaCreacion.ToString(),
                                    fechaVencimiento = (tarea.te_FechaVencimiento == null) ? DateTime.Now.ToString() : tarea.te_FechaVencimiento.ToString(),
                                    estado = tarea.te_Estado.ToString()
                                });
                            }

                        }
                    }
                    else
                    {
                        //Trae todas las tareas que esten activas 
                        listtblTask = ctx.tblTask.Where(u => u.te_Estado == true).ToList();

                        if (listtblTask != null || listtblTask.Count() > 0)
                        {
                            foreach (var tarea in listtblTask)
                            {
                                var usuario = ctx.tblUsers.Where(u => u.us_Users_Pk == tarea.te_UsuarioFk).FirstOrDefault();

                                listTareas.Add(new Entities.Task()
                                {
                                    id = tarea.ta_TareaPk.ToString(),
                                    nombre = tarea.ta_Nombre,
                                    descripcion = tarea.te_Descripcion,
                                    fechaCreacion = (tarea.te_FechaCreacion == null) ? DateTime.Now.ToString() : tarea.te_FechaCreacion.ToString(),
                                    fechaVencimiento = (tarea.te_FechaVencimiento == null) ? DateTime.Now.ToString() : tarea.te_FechaVencimiento.ToString(),
                                    estado = tarea.te_Estado.ToString(),
                                    user = new Entities.User() { userName = usuario.us_UserName, id = usuario.us_Users_Pk.ToString() }
                                });
                            }

                        }
                    }
                }

                return listTareas;

            }
            catch (Exception ex)
            {
                return listTareas;
            }
        }

        /// <summary>
        /// Eliminar Tarea
        /// </summary>
        /// <param name="oTask">Objeto Task</param>
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
