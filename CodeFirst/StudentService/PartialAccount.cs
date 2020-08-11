using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.StudentService
{
    public partial class Account
    {
        private void CheckName(string value)
        {
            var temp = value.Trim();
            if (string.IsNullOrEmpty(temp) || temp.Contains(" "))
                throw new System.Exception("Invalid Username and Password!");
        }

        partial void OnsettingPassword(string value)
        {
            CheckName(value);
        }

        partial void OnsettingUserName(string value)
        {
            CheckName(value);
        }
    }
}
