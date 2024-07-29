using RadMangerForm.Model;
using RadMangerForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using RadMangerForm.View;


namespace RadMangerForm.Presenter
{
    
    public class DetailPresenter
    {
        private DetailModel _detailModel;
        private IDetailView _streckeDetailsView;
        private Strecke _selectedStrecke;

        public DetailPresenter(Strecke selectedStrecke)
        {
            DetailModel detailModel = new DetailModel();
            StreckeDetailsView streckeDetailsView = new StreckeDetailsView(selectedStrecke);

            _streckeDetailsView = streckeDetailsView;
            _detailModel = detailModel;
            
            _selectedStrecke = selectedStrecke;

            LoadDetails();

            ////direkt methode im Model die die Daten holt
            //GetStreckeDetails(selectedStrecke.StreckenID);
           
            //GetTrinkbrunnenDetails(selectedStrecke.TrinkbrunnenID);


            
        }

        private void LoadDetails()
        {
            var streckeDetails = _detailModel.GetStreckeDetails(_selectedStrecke.StreckenID);
            var belagDetails = _detailModel.GetBelagDetails(_selectedStrecke.BelagID);
            var trinkbrunnenDetails = new List<Trinkbrunnen>();

            if (_selectedStrecke.TrinkbrunnenID != null)
            {
                trinkbrunnenDetails = _detailModel.GetTrinkbrunnenDetails(_selectedStrecke.TrinkbrunnenID);                
            }

            if (streckeDetails != null )
            {
                _streckeDetailsView.DisplayStreckeDetails(streckeDetails);

                if(belagDetails != null)
                {
                    _streckeDetailsView.DisplayBelagDetails(belagDetails);
                }               
                _streckeDetailsView.DisplayTrinkbrunnenDetails(trinkbrunnenDetails);
                _streckeDetailsView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Details für die ausgewählte Strecke konnten nicht abgerufen werden.");
            }
        }




        public void GetStreckeDetails(int streckenId)
        {
            Strecke streckeDetails = _detailModel.GetStreckeDetails(streckenId);

            if (streckeDetails != null)
            {
                _streckeDetailsView.DisplayStreckeDetails(streckeDetails);
                _streckeDetailsView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Details für die ausgewählte Strecke konnten nicht abgerufen werden.");
            }
        }

        public void GetTrinkbrunnenDetails(int trinkbrunnenId)
        {
            if(trinkbrunnenId != 0)
            {
                List<Trinkbrunnen> trinkbrunnenDetails = _detailModel.GetTrinkbrunnenDetails(trinkbrunnenId);

                if (trinkbrunnenDetails != null)
                {
                    _streckeDetailsView.DisplayTrinkbrunnenDetails(trinkbrunnenDetails);
                    _streckeDetailsView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Es wurden keine Informationen zum Trinkbrunnen gefunden");
                }
            }
            else
            {                 
                MessageBox.Show("Es gibt keine Trinkbrunnen für diese Strecke");
            }
          
        }






    }
}
