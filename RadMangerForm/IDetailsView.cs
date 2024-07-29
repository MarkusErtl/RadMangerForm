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
            void DisplayStreckeDetails(Strecke strecke);
            void DisplayBelagDetails(Belag belag);
            void DisplayTrinkbrunnenDetails(IEnumerable<Trinkbrunnen> trinkbrunnen);
            void ShowDialog();
        }   
}
