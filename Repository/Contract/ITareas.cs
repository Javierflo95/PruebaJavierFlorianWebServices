﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contract
{
    public interface ITareas
    {
        void CreateTask(Entities.Task oTask, User oUser);
        void EditTask(Entities.Task oTask);
        Entities.Task GetTask(Entities.Task oTask);
        List<Entities.Task> ListTasks();
        void DeleteTask(Entities.Task oTask);
    }
}