using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeItTrue.View;
using System.Windows.Forms;

namespace MakeItTrue.Controller
{
    class BenvenutoController
    {
        private Benvenuto benvenuto;
        public BenvenutoController()
        {
            this.benvenuto = new Benvenuto();
            InizializzaEventi();
        }
        public void InizializzaEventi()
        {
            this.benvenuto.menuButton.MouseClick += new MouseEventHandler(this.BenvenutoClick);
        }
        // Mostrare il Form benvenuto
        public void EsporreBenvenuto()
        {
            this.benvenuto.ShowDialog();
        }
        public void BenvenutoClick(object sender, EventArgs e)
        {
            MenuController controller = new MenuController();
            controller.ShowMenu();
        }
    }
}
