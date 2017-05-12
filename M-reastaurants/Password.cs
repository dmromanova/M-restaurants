using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_reastaurants
{
    class Password
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _psword;

        public string Psword
        {
            get { return _psword; }
            set { _psword = value; }
        }

        public Password(string login, string psword)
        {
            _login = login;
            _psword = psword;
        }
                
    }
}
