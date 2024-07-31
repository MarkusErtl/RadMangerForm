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
            // Set the view and model
            _mainView = mainView;
            _mainModel = mainModel;

            // Subscribe to the events of the view
            _mainView.LoadButtonClicked += OnLoadButtonClicked;
            _mainView.SearchButtonClicked += OnSearchButtonClicked;
            _mainView.DetailButtonClicked += OnDetailsButtonClicked;

            _mainView.AddButtonClicked += OnAddButtonClicked;

             _mainView.EditButtonClicked += OnEditButtonClicked;
             _mainView.DeleteButtonClicked += OnDeleteButtonClicked;
        }

        /// <summary>
        /// Es wurde auf den Löschen-Button geklickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteButtonClicked(object? sender, EventArgs e)
        {
            Strecke selectedStrecke = _mainView.GetSelectedStrecke();
           

            if (selectedStrecke != null)
            {
                _mainModel.DeleteStrecke(selectedStrecke.StreckenID);
                OnLoadButtonClicked(this, EventArgs.Empty);
            }
            
        }

        /// <summary>
        /// Es wurde auf den Details-Button geklickt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDetailsButtonClicked(object? sender, EventArgs e)
        {

            Strecke selectedStrecke = _mainView.GetSelectedStrecke();
            if(selectedStrecke != null)
            {
                Strecke streckeAllData = _mainModel.LoadStreckeById(selectedStrecke.StreckenID);

                if (streckeAllData != null)
                {
                    DetailPresenter detailPresenter = new DetailPresenter(streckeAllData);
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Strecke aus.");
                }
            }
                  
        }

        /// <summary>
        /// Der Search -Button wurde geklickt um nach einer Strecke zu suchen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearchButtonClicked(object sender, EventArgs e)
        {  

            string userInput = _mainView.GetUserInput();
            List<Strecke> strecke = _mainModel.SearchButtonClicked( userInput);
            _mainView.UpdateStreckenList(strecke);
        }


        /// <summary>
        /// Der Load -Button wurde geklickt um alle Strecken zu laden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadButtonClicked(object sender, EventArgs e)
        {
            // Laden aller Daten zum Hineinladen in die ListBox
            List<Strecke> strecken = _mainModel.LoadButtonClicked();
            _mainView.UpdateStreckenList(strecken);
        }


        /// <summary>
        /// Der Add -Button wurde geklickt um eine neue Strecke hinzuzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            //Liste von Bundesländern laden
            List<Bundesland> bundesländer = _mainModel.GetBundesländer();

            AddView addView = new AddView(bundesländer);
            addView.SaveButtonClicked += OnSaveButtonClicked;
            addView.ShowDialog();
        }

        /// <summary>
        /// Der Edit -Button wurde geklickt um eine Strecke zu bearbeiten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditButtonClicked(object sender, EventArgs e)
        {

            // Angenommen, Sie haben eine Möglichkeit, die ID der ausgewählten Strecke zu erhalten
            Strecke selectedStrecke = _mainView.GetSelectedStrecke();
            if(selectedStrecke != null)
            {
                Strecke streckeAllData = _mainModel.LoadStreckeById(selectedStrecke.StreckenID);


                if (streckeAllData != null)
                {
                    List<Bundesland> bundesländer = _mainModel.GetBundesländer();

                    AddView addView = new AddView(bundesländer)
                    {
                        selectedStrecke = streckeAllData
                    };
                    addView.SaveButtonClicked += OnSaveButtonClicked;
                    addView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Strecke aus.");
                }
            } 
        }

        /// <summary>
        /// Speichert die Änderungen an der Strecke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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