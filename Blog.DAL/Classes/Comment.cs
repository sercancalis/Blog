using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Classes
{
    public class Comment
    {
        public int ID { get; set; }
 
        public string Content { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        //Mapping
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    
        public int? ChildID { get; set; }
        public virtual Comment Child { get; set; }


    }
}
