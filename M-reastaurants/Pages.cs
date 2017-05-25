using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_reastaurants
{
    class Pages
    {
        private static MainPage _mainPage = new MainPage();
        private static LoginPage _loginPage = new LoginPage();
        private static EditingPage _editingPage = new EditingPage();
        private static DeletePage _deletePage = new DeletePage();

        public static LoginPage LoginPage
        {
            get
            {
                return _loginPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

        public static EditingPage EditingPage
        {
            get
            {
                return _editingPage;
            }
        }
        public static DeletePage DeletePage
        {
            get
            {
                return _deletePage;
            }
        }
    }
}
