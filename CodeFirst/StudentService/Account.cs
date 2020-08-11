using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    public partial class Account
    {
        //The ForeignKey need to have same name with property at virtual Student for Lazy loading 
        [ForeignKey("Students")]
        public long Id { get; set; }
        public string _userName { get; set; }
        public string _passWord { get; set; }
        public virtual Student Students { get; set; }
        partial void OnsettingUserName(string value);
        partial void OnsettingPassword(string value);
        public string UserName
        {
            get => _userName;
            set
            {
                OnsettingUserName(value);
                _userName = value;
            }
        }
        public string Password
        {
            get => _passWord;
            set
            {
                OnsettingPassword(value);
                _passWord = value;
            }
        }
    }
}
