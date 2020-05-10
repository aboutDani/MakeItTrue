using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakeItTrue.View;
using System.Windows.Forms;

namespace MakeItTrue.Controller
{
    class MenuController
    {
        private MenuPrincipale start;

        public MenuController()
        {
            this.start = new MenuPrincipale();
            InizializzaEventi();
        }
        public void InizializzaEventi()
        {
            this.start.mateLvl1Button.MouseClick += new MouseEventHandler(this.Mate1Click);
            this.start.mateLvl2Button.MouseClick += new MouseEventHandler(this.Mate2Click);
            this.start.mateLvl3Button.MouseClick += new MouseEventHandler(this.Mate3Click);

            this.start.logicLvl1Button.MouseClick += new MouseEventHandler(this.Logica1Click);
            this.start.logicLvl2Button.MouseClick += new MouseEventHandler(this.Logica2Click);
            this.start.logicLvl3Button.MouseClick += new MouseEventHandler(this.Logica3Click);
        }
        // Mostrare il Form MenuPrincipale
        public void ShowMenu()
        {
            this.start.ShowDialog();
        }
        // 3 livelli di matematica
        public void Mate1Click(object sender, EventArgs e)
        {
            MatematicaController controller = new MatematicaController(true, 0);
            controller.EsporreMate();
        }
        public void Mate2Click(object sender, EventArgs e)
        {
            MatematicaController controller = new MatematicaController(true, 1);
            controller.EsporreMate();
        }
        public void Mate3Click(object sender, EventArgs e)
        {
            MatematicaController controller = new MatematicaController(true, 2);
            controller.EsporreMate();
        }
        // 3 livelli di logica
        public void Logica1Click(object sender, EventArgs e)
        {
            LogicaController controller = new LogicaController(false, 0);
            controller.EsporreLogica();
        }
        public void Logica2Click(object sender, EventArgs e)
        {
            LogicaController controller = new LogicaController(false, 1);
            controller.EsporreLogica();
        }
        public void Logica3Click(object sender, EventArgs e)
        {
            LogicaController controller = new LogicaController(false, 2);
            controller.EsporreLogica();
        }
    }
}
