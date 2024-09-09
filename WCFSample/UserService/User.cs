using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember] 
        public string Name { get; set; }

        public string Password { get; set; }

        [DataMember] 
        public bool IsActive { get; set; }
    }
}
