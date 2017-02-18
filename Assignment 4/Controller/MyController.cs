using Assignment_4.Model;
using Assignment_4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Controller
{
    public class MyController : IController
    {
        private IModel _m;
        private IView _v;

        public MyController()
        {
        }

        public void setModel(IModel m)
        {
            this._m = m;
        }

        public void setView(IView v)
        {
            this._v = v;
        }

        public IModel getModel()
        {
            return this._m;
        }

        public IView getView()
        {
            return this._v;
        }
    }
}
