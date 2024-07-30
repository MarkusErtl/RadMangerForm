﻿using RadMangerForm.Model;
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

            _streckeDetailsView.AddButtonClicked += OnAddButtonClicked;
            _streckeDetailsView.EditButtonClicked += OnEditButtonClicked;
            _streckeDetailsView.DeleteButtonClicked += OnDeleteButtonClicked;
            _streckeDetailsView.BelagEditButtonClicked += OnBelagEditButtonClicked;

            _streckeDetailsView.CloseButtonClicked += OnCloseButtonClicked;


            LoadDetails();

            ////direkt methode im Model die die Daten holt
            //GetStreckeDetails(selectedStrecke.StreckenID);
           
            //GetTrinkbrunnenDetails(selectedStrecke.TrinkbrunnenID);

           

        }
        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            _streckeDetailsView.Close();
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            Trink_editAdd trink_EditAdd = new Trink_editAdd()
            {
                _selectedStrecke = _selectedStrecke,
                _trinkbrunnen = null
            };

            trink_EditAdd.SaveButtonClicked += OnSaveButtonClicked;
            trink_EditAdd.ShowDialog();

        }

        private void OnEditButtonClicked(object sender, EventArgs e)
        {
            Trinkbrunnen selcetedTrinkbrunnen = _streckeDetailsView.GetSelectedTrinkbrunnen();
            if (selcetedTrinkbrunnen != null)
            {
                Trink_editAdd trink_EditAdd = new Trink_editAdd()
                {
                    _selectedStrecke = _selectedStrecke,
                    _trinkbrunnen = selcetedTrinkbrunnen
                };

                trink_EditAdd.SaveButtonClicked += OnSaveButtonClicked;
                trink_EditAdd.ShowDialog();



            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Trinkbrunnen aus.");
            }

        }

        private void OnSaveButtonClicked (object sender, EventArgs e)
        {
            Trink_editAdd trink_EditAdd = (Trink_editAdd)sender;

            Trinkbrunnen trinkbrunnen = trink_EditAdd.GetTrinkbrunnenDetails();
        

            if (trinkbrunnen != null)
            {
                _detailModel.UpdateTrinkbrunnen(trinkbrunnen, _selectedStrecke);    
            }
            else
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
            }

            trink_EditAdd.Close();
            LoadDetails();
        }

        private void OnBelagEditButtonClicked(object sender, EventArgs e)
        {
            Belag_edit belag_Edit = new Belag_edit()
            {               
            };

            belag_Edit.SaveButtonClickedBelag += onBelagSaveButtonClicked;
            belag_Edit.ShowDialog(); 
        }

        private void onBelagSaveButtonClicked(object sender, EventArgs e)
        {
            var belagDetails = _detailModel.GetBelagDetails(_selectedStrecke.BelagID);

            Belag_edit belag_Edit = (Belag_edit)sender;


            Belag belag = belag_Edit.GetBelagDetails();
           belag.BelagID = belagDetails.BelagID; //die BelagID wird wieder überschrieben von dem alten Belag

            if (belag != null)
            {
                _detailModel.UpdateBelag(belag, _selectedStrecke);
            }
            else
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus.");
            }

            belag_Edit.Close();
            LoadDetails();
        }   


        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Trinkbrunnen selcetedTrinkbrunnen = _streckeDetailsView.GetSelectedTrinkbrunnen();
            if (selcetedTrinkbrunnen != null)
            {
               _detailModel.DeleteTrinkbrunnen(selcetedTrinkbrunnen.TrinkbrunnenID);
                LoadDetails();



            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Trinkbrunnen aus.");
            }

        }

        private void LoadDetails()
        {
            var streckeDetails = _detailModel.GetStreckeDetails(_selectedStrecke.StreckenID);
            var belagDetails = _detailModel.GetBelagDetails(_selectedStrecke.BelagID);
            var trinkbrunnenDetails = new List<Trinkbrunnen>();
            var bundesländer = _detailModel.GetBundesländerByID(_selectedStrecke.StreckenID);

            if (_selectedStrecke.TrinkbrunnenID != null)
            {
                trinkbrunnenDetails = _detailModel.GetTrinkbrunnenDetails(_selectedStrecke.TrinkbrunnenID, _selectedStrecke.StreckenID);                
            }

            if (streckeDetails != null )
            {
                _streckeDetailsView.DisplayStreckeDetails(streckeDetails);

                if(belagDetails != null)
                {
                    _streckeDetailsView.DisplayBelagDetails(belagDetails);
                }   
                _streckeDetailsView.DisplayBundesländer(bundesländer);
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
                List<Trinkbrunnen> trinkbrunnenDetails = _detailModel.GetTrinkbrunnenDetails(trinkbrunnenId, _selectedStrecke.StreckenID);

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
