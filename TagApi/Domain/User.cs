using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagApi.Domain
{
    public sealed class User
    {
        public long? id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cnpj { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
