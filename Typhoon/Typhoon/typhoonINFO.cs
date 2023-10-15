using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Typhoon
{
    public partial class typhoonINFO : Form
    {
        IFeature pfeature;
        public string bname;
        Dictionary<string, string> dict = new Dictionary<string, string>();

        public typhoonINFO()
        {
            InitializeComponent();
        }


        public void showDetails(IFeature pFeature)
        {
            pfeature = pFeature;
            ArrayList arrlist = new ArrayList();

            for (int i = 0; i < pfeature.Fields.FieldCount; i++)
            {
                arrlist.Add(pfeature.get_Value(i));
            }

            label6.Text = arrlist[8].ToString() + "级" + arrlist[9].ToString();
            label7.Text = arrlist[5].ToString()+"m/s";
            label8.Text = arrlist[4].ToString() + "百帕";
            label9.Text = arrlist[6].ToString();

        }




    }
}
