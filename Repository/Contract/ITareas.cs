using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contract
{
    public interface ITareas
    {
        Entities.Task CreateTask(Entities.Task oTask, User oUser);
        Entities.Task EditTask(Entities.Task oTask);
        Entities.Task GetTask(Entities.Task oTask);
        List<Entities.Task> ListTaskbyState(Entities.Task oTask);
        void DeleteTask(Entities.Task oTask);      
    }
}

