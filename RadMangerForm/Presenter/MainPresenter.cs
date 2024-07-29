using RadMangerForm.Model;
using RadMangerForm.View;
using System;
using System.Collections.Generic;

namespace RadMangerForm.Presenter
{
    public class MainPresenter
    {
        private MainView _mainView;
        private MainModel _mainModel;

        public MainPresenter(MainView mainView, MainModel mainModel)
        {
            _mainView = mainView;
            _mainModel = mainModel;

            _mainView.LoadButtonClicked += OnLoadButtonClicked;
            _mainView.SearchButtonClicked += OnSearchButtonClicked;
            _mainView.DetailButtonClicked += OnDetailsButtonClicked;

            _mainView.AddButtonClicked += OnAddButtonClicked;

             _mainView.EditButtonClicked += OnEditButtonClicked;
             _mainView.DeleteButtonClicked += OnDeleteButtonClicked;
        }

        private void OnDeleteButtonClicked(object? sender, EventArgs e)
        {
            Strecke selectedStrecke = _mainView.GetSelectedStrecke();

            if (selectedStrecke != null)
            {
                _mainModel.DeleteStrecke(selectedStrecke.StreckenID);
                OnLoadButtonClicked(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Strecke aus.");
            }
        }

        private void OnDetailsButtonClicked(object? sender, EventArgs e)
        {

            Strecke selectedStrecke = _mainView.GetSelectedStrecke();            

            if(selectedStrecke != null)
            {
                DetailPresenter detailPresenter = new DetailPresenter(selectedStrecke);
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Strecke aus.");
            }          
        }

        private void OnSearchButtonClicked(object sender, EventArgs e)
        {
            // Do something
            _mainModel.SearchButtonClicked();
        }

        private void OnLoadButtonClicked(object sender, EventArgs e)
        {
            // Laden aller Daten zum Hineinladen in die ListBox
            List<Strecke> strecken = _mainModel.LoadButtonClicked();
            _mainView.UpdateStreckenList(strecken);
        }


        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            //Liste von Bundesländern laden
            List<Bundesland> bundesländer = _mainModel.GetBundesländer();

            AddView addView = new AddView(bundesländer);
            addView.SaveButtonClicked += OnSaveButtonClicked;
            addView.ShowDialog();

        }
        private void OnEditButtonClicked(object sender, EventArgs e)
        {

            // Angenommen, Sie haben eine Möglichkeit, die ID der ausgewählten Strecke zu erhalten
            Strecke selectedStrecke = _mainView.GetSelectedStrecke();

           

            if(selectedStrecke != null)
            {

                int? selectedStreckeId = selectedStrecke.StreckenID;

                List<Bundesland> bundesländer = _mainModel.GetBundesländer();

                AddView addView = new AddView(bundesländer)
                {
                    selectedStrecke = selectedStrecke
                };
                addView.SaveButtonClicked += OnSaveButtonClicked;
                addView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Strecke aus.");
            }

        }

        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            AddView addView = sender as AddView;
            if (addView != null)
            {
                Strecke neueStrecke = addView.GetStreckeDetails();
                Strecke alteStrecke = addView.selectedStrecke;
                if (neueStrecke != null)
                {
                    _mainModel.AddStrecke(neueStrecke);
                    if(alteStrecke != null)
                    {
                        _mainModel.DeleteStrecke(alteStrecke.StreckenID);
                    }                  
                    //MessageBox.Show("Neue Strecke erfolgreich hinzugefügt.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addView.Close();
                    // Optionally reload the strecken list
                    OnLoadButtonClicked(this, EventArgs.Empty);
                }
            }
        }


    }
}