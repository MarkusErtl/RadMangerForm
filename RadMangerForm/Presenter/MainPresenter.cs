using RadMangerForm.Model;
using RadMangerForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm.Presenter
{
    public class MainPresenter
    {
        private MainView _mainView;
        private MainModel _mainModel;

        public MainPresenter()
        {
            _mainView = new MainView();
            _mainModel = new MainModel();

        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            // Do something
            _mainModel.SearchButtonClicked();

        }  
       
        private void OnLoadButtonClicked(object sender, EventArgs e)
        {
            //Laden aller Daten zum hineinladen in die ListBox
                       
             //  _mainModel.LoadButtonClicked();
        }   




    }
}
