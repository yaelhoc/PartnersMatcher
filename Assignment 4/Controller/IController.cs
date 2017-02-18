using Assignment_4.Model;
using Assignment_4.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4.Controller
{
    public interface IController
    {
        void setModel(IModel m);

        void setView(IView v);

        IModel getModel();

        IView getView();
    }
}
