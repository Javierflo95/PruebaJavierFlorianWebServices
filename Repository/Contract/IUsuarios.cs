using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository.Contract
{
    public interface IUsuarios
    {
        void CreateUser(User oUser);
        void EditUser(User oUser);
        User GetUse(User oUser);
        User GetUserLogin(User oUser);
        List<User> ListUsers();
        void DeleteUser(User oUser);
    }
}
