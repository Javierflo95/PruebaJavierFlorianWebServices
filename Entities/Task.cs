using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class Task
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public string fechaCreacion { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string fechaVencimiento { get; set; }
        [DataMember]
        public User user { get; set; }

    }
}
