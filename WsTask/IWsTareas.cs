using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;

namespace WsTask
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWsTareas" in both code and config file together.
    [ServiceContract]
    public interface IWsTareas
    {
        [OperationContract]
        void CreateUser(User oUser);
        [OperationContract]
        void EditUser(User oUser);
        [OperationContract]
        User GetUse(User oUser);
        [OperationContract]
        User GetUserLogin(User oUser);
        [OperationContract]
        List<User> ListUsers();
        [OperationContract]
        void DeleteUser(User oUser);
        //Tasks
        [OperationContract]
        void CreateTask(Entities.Task oTask, Entities.User oUser);
        [OperationContract]
        void EditTask(Task oTask);
        [OperationContract]
        Task GetTask(Task oTask);
        [OperationContract]
        List<Task> ListTasks();
        [OperationContract]
        void DeleteTask(Task oTask);

    }

}
