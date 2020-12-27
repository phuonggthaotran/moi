using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DA3Last.Models
{
    public partial class Users
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Active { get; set; }

        public Users() { }

        public Users(int userID, string userName, string passWord, string role, string active)
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Pass = passWord;
            this.Role = role;
            this.Active = active;
        }
    }
}