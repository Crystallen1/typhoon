using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

namespace Typhoon
{
    public partial class FormQueryByAttribute : Form
    {
        //变量定义
           private IMap currentMap;//当前MapControl控件的Map对象
          private IFeatureLayer currentFeatureLayer;//设置临时类变量来使用IFeatureLayer接口的当前图层对象
           private string currentFileName;//设置临时类变量来存储字段名称
           /// <summary>
           /// 获得当前MapControl控件中的对象
           /// </summary>
         public IMap CurrentMap
         {
             set
            {
                 currentMap = value;
             }
         }
         public FormQueryByAttribute()
        {
 
              InitializeComponent();
          }


         #region 各按钮的单击事件

         private void btnEqual_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnEqual.Text + " ";
         }

         private void btnOr_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnOr.Text + " ";
         }

         private void btnNoEqual_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnNoEqual.Text + " ";
         }

         private void btnDayu_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnDayu.Text + " ";
         }

         private void btnDayuEqual_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnDayuEqual.Text + " ";
         }

         private void btnAnd_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnAnd.Text + " ";
         }

         private void btnXiYu_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnXiYu.Text + " ";
         }

         private void btnXiaoyuEqual_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnXiaoyuEqual.Text + " ";
         }

         private void btnNot_Click(object sender, EventArgs e)
         {
             txtSelectResult.Text += " " + btnNot.Text + " ";
         }
         #endregion

         #region 定义执查询的方法
         private void SelectFeatureByAttribute()
         {
             //使用FeatureLayer对象的IFeatureSelection接口执行查询操作。进行接口的转换。
             IFeatureSelection featureSelection=currentFeatureLayer as IFeatureSelection;
             //新建IQueryFilter接口的对象来进行Where语句定义
             IQueryFilter queryFilter=new QueryFilterClass();
             //设置Where语句内容
             queryFilter.WhereClause=txtSelectResult.Text;
             //通过接口转换使用Map对象的IActiveView接口来部分刷新地图窗口，从而高亮显示查询结果
             IActiveView activeView =currentMap as IActiveView ;
             //根据查询选择方式的不同，得到不同的选择集
             switch(comBoxSelectMethod.SelectedIndex)
             {
                 //在新建选择集的情况下
                 case 0:
                     //首先使用IMap接口的ClearSelection()方法清空地图选择集
                     currentMap.ClearSelection();
                     //根据定义的where语句使用IFeatureSelection接口的SelectFeature方法选择要素，并将其添加到选择集中
                     featureSelection.SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
                     break;
                 case 1:
                    featureSelection .SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultAdd,false);
                     break;
                case 2:
                      featureSelection .SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultXOR,false);
                     break;
                 case 3:
                      featureSelection .SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultAdd,false);
                     break;
                     //默认为新建选择集的情况
                 default:
                      featureSelection .SelectFeatures(queryFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
                     break;
             }
             //部分刷新操作，只刷新地理选择集的内容
             activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection,null,activeView.Extent);
         }
         #endregion
         //确定按钮
         private void button3_Click(object sender, EventArgs e)
         {
             try
             {
                 SelectFeatureByAttribute();
                 this.Close();
             }
             catch { }
         }

         private void button1_Click(object sender, EventArgs e)
         {
             txtSelectResult.Clear();
         }

         private void button2_Click(object sender, EventArgs e)
         {
             this.Close();

         }

         private void FormQueryByAttribute_Load_1(object sender, EventArgs e)
         {
             try
             {
                 //将当前图层列表清空
                 comBoxLayerName.Items.Clear();
                 string layerName;//设置临时变量存储图层名称
                 //对Map中的每个图层进行判断并加载名称
                 for (int i = 0; i < currentMap.LayerCount; i++)
                 {
                     //如果该图层为图层组类型，则分别对所包含的每个图层进行操作
                     if (currentMap.get_Layer(i) is GroupLayer)
                     {
                         //使用ICompositeLayer接口进行遍历操作
                         ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                         for (int j = 0; j < compositeLayer.Count; j++)
                         {
                             //将图层的名称添加到comboxLayerName中
                             layerName = compositeLayer.get_Layer(j).Name;
                             comBoxLayerName.Items.Add(layerName);
                         }
                     }
                     //如果图层不是图层组类型，则直接添加名称
                     else
                     {
                         layerName = currentMap.get_Layer(i).Name;
                         comBoxLayerName.Items.Add(layerName);
                     }
                 }
                 //将comboxLayerName控件的默认选项设置为第一个图层名称
                 comBoxLayerName.SelectedIndex = 0;
                 //将comboxselectMethod控件的默认选项设置为第一种选择方式
                 comBoxSelectMethod.SelectedIndex = 0;
             }
             catch { }
         }

         private void comBoxLayerName_SelectedIndexChanged_1(object sender, EventArgs e)
         {
             //首先将字段列表和字段值列表清空
             ListBoxFields.Items.Clear();
             IField field;//设置临时变量存储使用的IField接口对象
             for (int i = 0; i < currentMap.LayerCount; i++)
             {
                 if (currentMap.get_Layer(i) is GroupLayer)
                 {
                     ICompositeLayer compositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                     for (int j = 0; i < compositeLayer.Count; j++)
                     {
                         //判断图层的名称是否与comBoxLayerName控件中选择的图层名称相同
                         if (compositeLayer.get_Layer(j).Name == comBoxLayerName.SelectedItem.ToString())
                         {
                             //如果相同则设置为整个窗体使用的IFeatureLayer接口对象
                             currentFeatureLayer = compositeLayer.get_Layer(j) as IFeatureLayer;
                             break;
                         }
                     }
                 }
                 else
                 {
                     //判断图层的名称是否与comboxLayerName控件中选择的图层名称相同
                     if (currentMap.get_Layer(i).Name == comBoxLayerName.SelectedItem.ToString())
                     {
                         //如果相同则设置为整个窗体所使用的IFeatureLayer接口对象
                         currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                         break;
                     }
                 }
             }
             //使用IFeatureClass接口对该图层的所有属性字段进行遍历，并填充listboxField控件
             for (int i = 0; i < currentFeatureLayer.FeatureClass.Fields.FieldCount; i++)
             {
                 //根据索引值获取图层的字段
                 field = currentFeatureLayer.FeatureClass.Fields.get_Field(i);
                 //排除SHAPE字段，并在其他字段名称前后添加字符“\”
                 if (field.Name.ToUpper() != "SHAPE"){
                     ListBoxFields.Items.Add("\"" + field.Name + "\"");
                 }
             }
             //更新labelSelectResult控件中的图层名称信息
             labSelectResult.Text = currentFeatureLayer.Name + "WHERE:";
             //将显示where语句的文本内容清除
             txtSelectResult.Clear();
         }

         private void comBoxSelectMethod_SelectedIndexChanged_1(object sender, EventArgs e)
         {

             if (ListBoxFields.SelectedItem == null)
             {
                 return;
             }
             else
             {
                 //设置窗体可用的字段名称
                 string str = ListBoxFields.SelectedItem.ToString();
                 str = str.Substring(1);
                 str = str.Substring(0, str.Length - 1);
                 currentFileName = str;
             }
         }

         //private void btnOnlyAttributeValue_Click_1(object sender, EventArgs e)
         //{
         //    //将图层的某个字段进行唯一值获取操作，并将所有的唯一值显示在listBoxValues控件中
         //    try
         //    {
         //        //使用FeatureClass对象的IDataset接口来获取dataset和workspace的信息
         //        IDataset dataset = (IDataset)currentFeatureLayer.FeatureClass;
         //        //使用IQueryDef接口的对象来定义和查询属性信息。通过IWorkspace接口的CreateQueryDef()方法创建该对象。
         //        IQueryDef queryDef = ((IFeatureWorkspace)dataset.Workspace).CreateQueryDef();
         //        //设置所需查询的表格名称为dataset的名称
         //        queryDef.Tables = dataset.Name;
         //        //设置查询的字段名称。可以联合使用SQL语言的关键字，如查询唯一值可以使用DISTINCT关键字。
         //        queryDef.SubFields = "DISTINCT (" + currentFileName + ")";
         //        //执行查询并返回ICursor接口的对象来访问整个结果的集合
         //        ICursor cursor = queryDef.Evaluate();
         //        //使用IField接口获取当前所需要使用的字段的信息
         //        IFields fields = currentFeatureLayer.FeatureClass.Fields;
         //        IField field = fields.get_Field(fields.FindField(currentFileName));

         //        //对整个结果集合进行遍历，从而添加所有的唯一值
         //        //使用IRow接口来操作结果集合。首先定位到第一个查询结果。
         //        IRow row = cursor.NextRow();
         //        //如果查询结果非空，则一直进行添加操作
         //        while (row != null)
         //        {
         //            //对String类型的字段，唯一值的前后添加'和'，以符合SQL语句的要求
         //            if (field.Type == esriFieldType.esriFieldTypeString)
         //            {
         //                ListBoxValues.Items.Add("\'" + row.get_Value(0).ToString() + "\'");
         //            }
         //            else
         //            {
         //                ListBoxValues.Items.Add(row.get_Value(0).ToString());
         //            }
         //            //继续执行下一个结果的添加
         //            row = cursor.NextRow();
         //        }
         //    }
         //    catch (Exception ex)
         //    {
         //        MessageBox.Show(ex.Message);

         //    }
         //}

         private void ListBoxFields_MouseDoubleClick_1(object sender, MouseEventArgs e)
         {
             //在结果中添加字段的名称
             txtSelectResult.Text += ListBoxFields.SelectedItem.ToString();
         }


    }
}
