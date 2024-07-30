using RadMangerForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadMangerForm
{
    public interface IDetailView
    {
        event EventHandler<EventArgs> AddButtonClicked;
        event EventHandler<EventArgs> EditButtonClicked;
        event EventHandler<EventArgs> DeleteButtonClicked;
        event EventHandler<EventArgs> BelagEditButtonClicked;
        event EventHandler<EventArgs> CloseButtonClicked;



        Trinkbrunnen GetSelectedTrinkbrunnen();
       

        void DisplayBelagDetails(Belag belag);
        void DisplayStreckeDetails(Strecke strecke);       
        void DisplayTrinkbrunnenDetails(IEnumerable<Trinkbrunnen> trinkbrunnen);
        void ShowDialog();
        void Close();
        void DisplayBundesländer(Bundesland bundesländer);


    } 
}
