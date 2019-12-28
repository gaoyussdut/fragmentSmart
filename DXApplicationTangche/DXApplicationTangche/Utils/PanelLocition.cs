using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mendian
{
    class PanelLocition
    {
        private int ucLeft;
        private int panelBottom;
        private int ucHeight;

        public int UcLeft
        {
            get
            {
                return ucLeft;
            }

            set
            {
                ucLeft = value;
            }
        }

        public int PanelBottom
        {
            get
            {
                return panelBottom;
            }

            set
            {
                panelBottom = value;
            }
        }

        public int UcHeight
        {
            get
            {
                return ucHeight;
            }

            set
            {
                ucHeight = value;
            }
        }
        public PanelLocition(int panelwidth, int panelheight, int amount)
        {
            if (amount <= 5)
            {
                getWHLess5(panelwidth, panelheight);

            }
            if (amount > 5)
            {
                getWHMore5(panelwidth, panelheight);
            }

        }

        private void getWHLess5(int panelWidth, int panelHeight)
        {
            ucLeft = 30;
            panelBottom = panelHeight - 100;
            ucHeight = 50;
        }
        private void getWHMore5(int panelWidth, int panelHeight)
        {
            ucLeft = 30;
            panelBottom = panelHeight - 100;
            ucHeight = 50;
        }

    }
}
