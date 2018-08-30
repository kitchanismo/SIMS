using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class User : Person
    {
        public int UserID { get; set; } 

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        
    }
}
