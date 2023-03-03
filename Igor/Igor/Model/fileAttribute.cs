using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igor.Model
{
    public class fileAttribute
    {
        public int fileAttributeId { get; set; }
        public string fileName { get; set; }
        public string fileAuthor { get; set; }
        public Company oCompany { get; set; }
        public DateTime uploadDate { get; set; }
    }
}
