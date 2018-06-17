using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumModels
{
    public class Type
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
