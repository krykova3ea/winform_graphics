using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Lab3
{
    public partial class ColourForm : Form
    {
        Form1 parent;
        Color colour;
        Color PointSave;
        Color LineSave;
        bool bSave=true;
        public ColourForm(Form1 parentForm)
        {
            InitializeComponent();
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            domainUpDown1.Items.AddRange(colorsArray);
            domainUpDown1.TextChanged += domainUpDown_Select;
            parent = parentForm;
        }
        //присваеваем точке новый цвет с помощью ColorDialog
        private void PointColour_Click(object sender, EventArgs e)
        {
            
            parent.PointColor = colour;
            parent.Refresh();
        }
        //присваеваем линии новый цвет с помощью ColorDialog
        private void LineColour_Click(object sender, EventArgs e)
        {
            parent.LineColor = colour;
            parent.Refresh();
        }
        private void domainUpDown_Select(object sender, EventArgs e)
        {
            if (bSave)
            {
                PointSave = parent.PointColor;
                LineSave = parent.LineColor;
                bSave = false;
            }
            colour = Color.FromName(domainUpDown1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!bSave)
            {
                parent.PointColor = PointSave;
                parent.LineColor = LineSave;
                parent.Refresh();
            }
        }
    }
}
