using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string userName { get; set; }
        [DataMember]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombre { get; set; }
        [DataMember]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string apellido { get; set; }
        [DataMember]
        public string edad { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string crearTarea { get; set; }
        [DataMember]
        public List<Task> listTask { get; set; }
    }
}
