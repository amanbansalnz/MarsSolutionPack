using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskPart1.TestModel
{
    public class LoginModel
    {
        private String email;
        private String password;
        private String firstName;
        public void setEmail(String email)
        {
            this.email = email;
        }
        public String getEmail()
        {
            return email;
        }
        public void setPassword(String password)
        {
            this.password = password;
        }
        public String getPassword()
        {
            return password;
        }
        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }
        public String getUserName()
        {
            return firstName;
        }
    }
}
