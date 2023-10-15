using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.DataSourcesFile;
using System.Data.SqlClient;


namespace Typhoon
{
    public partial class Form1 : Form
    {
        int flagPage = 0;
        public TxtLoader DataHead = new TxtLoader();  //链表头


        public Form1()
        {
            InitializeComponent();
            loadInitialMap();
            loadInitialRainMap();
            SynchronizeEagleEye();

            DataLoad dataLoad = new DataLoad();
            //从远程数据库读取并创建站点数据shp
            RefreshStands(dataLoad);
            rainMapControl.AddShapeFile("..\\..\\..\\" + "ShapefileWorkspace", "ShapefileSample");
            rainMapControl.Refresh();
        }

        #region reload_txtdata(string filepath)读取台风中心点txt数据，存入TxtLoader链表（链表头为DataHead）
        private void reload_txtdata(string filepath)
        {

            StreamReader sr = new StreamReader(filepath, Encoding.Default);
            string line;
            line = sr.ReadLine();
            string[] a = line.Split(',');
            DataHead.time = a[0];
            DataHead.lat = a[1];
            DataHead.lon = a[2];
            DataHead.pressure = a[3];
            DataHead.wind = a[4];
            DataHead.direction = a[5];
            DataHead.futurespd = a[6];
            DataHead.level = a[7];
            DataHead.classes = a[8];
            TxtLoader p = DataHead;

            while ((line = sr.ReadLine()) != null)
            {
                p.Next = new TxtLoader();
                p = p.Next;
                a = line.Split(',');
                p.time = a[0];
                p.lat = a[1];
                p.lon = a[2];
                p.pressure = a[3];
                p.wind = a[4];
                p.direction = a[5];
                p.futurespd = a[6];
                p.level = a[7];
                p.classes = a[8];
            }
            p.Next = null;
        }
        #endregion

        #region RefreshCenture()刷新测站点数据
        public void RefreshCenture()
        {
            //创建空测站点数据shp 
            //首先创建含基本空间信息和OID字段的shp
            IFeatureClass featureClass = DataHead.CreateShapefile(mainMapControl.Map, "..\\..\\..\\", "ShapeFile", "centuralpoint");
            if (featureClass == null)
            {
                MessageBox.Show("创建shape文件失败");
                return;
            }

            //给创建的shp添加各字段
            IFieldEdit fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "time";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "pressure";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "wind";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "direction";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "futurespd";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "level";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "classes";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);

            //读取链表，添加所有台风中心数据
            TxtLoader p = DataHead;
            while (p.Next != null) //当没有遍历到最后一个时继续
            {
                IFeature feature = featureClass.CreateFeature();
                string time = p.time;
                string pressure = p.pressure;
                string wind = p.wind;
                string direction = p.direction;
                string futurespd = p.futurespd;
                string level = p.level;
                string classes = p.classes;
                double lat = Convert.ToDouble(p.lat);
                double lon = Convert.ToDouble(p.lon);
                IPoint point = new ESRI.ArcGIS.Geometry.Point();
                //添加形状（含坐标信息）
                point.PutCoords(lat, lon);
                feature.Shape = point;
                //获取各属性的index后插入记录属性值
                int index = feature.Fields.FindField("time");
                feature.set_Value(index, time);
                index = feature.Fields.FindField("pressure");
                feature.set_Value(index, pressure);
                index = feature.Fields.FindField("wind");
                feature.set_Value(index, wind);
                index = feature.Fields.FindField("direction");
                feature.set_Value(index, direction);
                index = feature.Fields.FindField("futurespd");
                feature.set_Value(index, futurespd);
                index = feature.Fields.FindField("level");
                feature.set_Value(index, level);
                index = feature.Fields.FindField("classes");
                feature.set_Value(index, classes);
                feature.Store();
                p = p.Next;
                //Marshal.ReleaseComObject(feature);
            }
            MessageBox.Show("刷新数据成功！");
        }
        #endregion


        private void mainMapControl_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //点击高亮
            IGeometry g = null;
            IEnvelope pEnv;
            IActiveView pActiveView = mainMapControl.ActiveView;
            IMap pMap = mainMapControl.Map;
            pEnv = mainMapControl.TrackRectangle();
            if (pEnv.IsEmpty == true)
            {
                tagRECT r;
                r.bottom = e.y + (int)mainMapControl.ActiveView.FullExtent.Width;
                r.top = e.y - (int)mainMapControl.ActiveView.FullExtent.Width;
                r.left = e.x - (int)mainMapControl.ActiveView.FullExtent.Width;
                r.right = e.x + (int)mainMapControl.ActiveView.FullExtent.Width;
                pActiveView.ScreenDisplay.DisplayTransformation.TransformRect(pEnv, ref r, 4);
                pEnv.SpatialReference = pActiveView.FocusMap.SpatialReference;
            }
            g = pEnv as IGeometry;
            mainMapControl.Map.SelectByShape(g, null, false);
            mainMapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            typhoonINFO frmdetail1 = new typhoonINFO();

            //IFeatureLayer pFeatureLayer = mainMapControl.get_Layer(0) as IFeatureLayer;
            //IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            //IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, true);
            //IFeature pFeature = pFeatureCursor.NextFeature();

            IMap map = mainMapControl.Map;
            ISelection selection = map.FeatureSelection;
            IEnumFeatureSetup iEnumFeatureSetup = (IEnumFeatureSetup)selection;
            iEnumFeatureSetup.AllFields = true;
            IEnumFeature pEnumFeature = (IEnumFeature)iEnumFeatureSetup;
            pEnumFeature.Reset();
            IFeature pFeature = pEnumFeature.Next();



            if (pFeature != null && pFeature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
            {
                frmdetail1.showDetails(pFeature);
                frmdetail1.ShowDialog();
                frmdetail1.TopMost = true;
                
                // 调用缓冲区相关函数
                drawBuffer(pFeature);
            }





        }

        private void ShowByFilter(AxMapControl sMapCtr, IFeatureLayer sFlyr, string sFilter)//根据要求筛选图层数据并显示
        {

            ESRI.ArcGIS.Carto.IFeatureLayerDefinition pDef = (ESRI.ArcGIS.Carto.IFeatureLayerDefinition)sFlyr;
            pDef.DefinitionExpression = sFilter;
            sMapCtr.ActiveView.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //mainMapControl.ClearLayers();
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "centuralpoint") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                    break;
                }
            }
            mainMapControl.AddShapeFile("..\\..\\..\\" + "ShapeFile", "centuralpoint");
            mainMapControl.Refresh();
            ILayer layer = null;
            for (int i = 0; i<mainMapControl.LayerCount;i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "centuralpoint") == 0 ) //只针对需要的这一层筛选
                {
                    layer = mainMapControl.Map.get_Layer(i);
                    break;
                }
            }           
            IFeatureLayer timefli = layer as IFeatureLayer;

            // 符号化
            GraduatedColors(timefli, "wind", 4, mainMapControl);

            string fliter = "time >= " + "'" + dateTimePicker1.Text + "时" + "'" + " and " + "time <= " + "'" + dateTimePicker2.Text + "时" + "'";
            ShowByFilter(mainMapControl, timefli, fliter);
            SynchronizeEagleEye();


        }

        private void 更新台风中心数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainMapControl.ClearLayers();//先清空图层，防止读取错误
            eagleMapControl.ClearLayers();
            MessageBox.Show("刷新中心点数据要较长时间，请耐心等待直至弹出成功提示！");
;            string fileName = "centuralpoint";//shp文件名
            string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
            //IWorkspaceFactory pWorkspaceFactory = new AccessWorkspaceFactoryClass();//Access格式的个人地理数据库
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
            IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);//fileName为文件名(不包含路径)
            IDataset pFeaDataset = pFeatureClass as IDataset;
            pFeaDataset.Delete();
            loadInitialMap(); // 加载底图
            reload_txtdata("..\\..\\typhondata.txt");
            RefreshCenture();
            SynchronizeEagleEye(); // 同步鹰眼
        }

        private void mainMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {


            IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(0) as IFeatureLayer;
            pFeatureLayer.DisplayField = "Name";
            pFeatureLayer.ShowTips = true;
            string pTip;
            pTip = pFeatureLayer.get_TipText(e.mapX, e.mapY, mainMapControl.ActiveView.FullExtent.Width / 500);
            if (pTip != null)
            {
                Cursor = Cursors.Hand;
            }
            else           //当 ToolTip 空间显示的内容为 null 的时候，就不会显示了！相当于隐藏了！
            {
                Cursor = Cursors.Default;
            }
        }


        #region 通过图层名获取图层
        private ILayer getLayerFromName(string layerName)
        {
            ILayer layer;
            IMap map = rainMapControl.Map;
            for (int i = 0; i < map.LayerCount; i++)
            {
                layer = map.get_Layer(i);
                if (layerName == layer.Name)
                    return layer;
            }
            return null;
        }
        #endregion

        #region 分级符号化
        private void GraduatedColors(IFeatureLayer pFeatureLayer, string pFieldName, int numClass, AxMapControl axMapControl)
        {
            IGeoFeatureLayer pGeoFeatureLayer = pFeatureLayer as IGeoFeatureLayer;
            object dataFrequency;
            object dataValues;
            bool ok;
            int breakIndex;
            ITable pTable = pGeoFeatureLayer.FeatureClass as ITable;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pBasicHistogram = (IBasicHistogram)pTableHistogram;
            pTableHistogram.Field = pFieldName;
            pTableHistogram.Table = pTable;

            // 获取渲染字段的值和出现频率
            pBasicHistogram.GetHistogram(out dataValues, out dataFrequency);
            IClassifyGEN pClassify = new EqualIntervalClass();
            try
            {
                // 进行等级划分
                pClassify.Classify(dataValues, dataFrequency, ref numClass);
            }
            catch (Exception ex) { }

            // 生成断点数组
            double[] Classes = pClassify.ClassBreaks as double[];
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pClassBreaksRenderer = new ClassBreaksRendererClass();

            // 设置分级的字段、数目、排序方式
            pClassBreaksRenderer.Field = pFieldName;
            pClassBreaksRenderer.BreakCount = ClassesCount;
            pClassBreaksRenderer.SortClassesAscending = true;

            // 设置色带
            IHsvColor pFromColor = new HsvColorClass();
            pFromColor.Hue = 0;
            pFromColor.Saturation = 50;
            pFromColor.Value = 96;
            IHsvColor pToColor = new HsvColorClass();
            pToColor.Hue = 80;
            pToColor.Saturation = 100;
            pToColor.Value = 96;

            // 产生色带对象
            IAlgorithmicColorRamp pAlgorithmicColorRamp = new AlgorithmicColorRampClass();
            pAlgorithmicColorRamp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            pAlgorithmicColorRamp.FromColor = pFromColor;
            pAlgorithmicColorRamp.ToColor = pToColor;
            pAlgorithmicColorRamp.Size = ClassesCount;
            pAlgorithmicColorRamp.CreateRamp(out ok);

            // 获得颜色
            IEnumColors pEnumColors = pAlgorithmicColorRamp.Colors;
            for (breakIndex = 0; breakIndex <= ClassesCount - 1; breakIndex++)
            {
                IColor pColor = pEnumColors.Next();
                switch (pGeoFeatureLayer.FeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
                        pSimpleFillSymbol.Color = pColor;
                        pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                        // 设置填充符号
                        pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleFillSymbol);
                        // 设置分级断点
                        pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);
                        break;
                    case esriGeometryType.esriGeometryPoint:
                        ISimpleMarkerSymbol pSimpleMarketSymbol = new SimpleMarkerSymbolClass();
                        pSimpleMarketSymbol.Color = pColor;
                        pClassBreaksRenderer.set_Symbol(breakIndex, (ISymbol)pSimpleMarketSymbol);
                        pClassBreaksRenderer.set_Break(breakIndex, Classes[breakIndex + 1]);
                        break;
                    default:
                        break;
                }
            }
            pGeoFeatureLayer.Renderer = (IFeatureRenderer)pClassBreaksRenderer;
            axMapControl.Refresh();
            SynchronizeEagleEye();
        }
        #endregion

        #region 缓冲区分析
        // 绘制缓冲区
        private void drawBuffer(IFeature pFeature)
        {
            IActiveView pActiveView = mainMapControl.ActiveView;
            IGraphicsContainer pGraCont = (IGraphicsContainer)pActiveView;
            IGeometry pGeometry = pFeature.Shape as IGeometry;
            ITopologicalOperator pTopoOpe = (ITopologicalOperator)pGeometry;
            pTopoOpe.Simplify();

            //删除地图上添加的所有Element
            pGraCont.DeleteAllElements();

            // 创建缓冲区 设置缓冲区宽度
            IGeometry pBufferGeo = pTopoOpe.Buffer(0.3);

            // 创建多边形符号样式、
            IScreenDisplay pdisplay = pActiveView.ScreenDisplay;
            ISimpleFillSymbol pSymbol = new SimpleFillSymbolClass();
            pSymbol.Style = esriSimpleFillStyle.esriSFSDiagonalCross;

            // 设置缓冲区颜色
            RgbColor pColor = new RgbColorClass();
            pColor.Blue = 200;
            pColor.Red = 200;
            pColor.Green = 100;
            pSymbol.Color = (IColor)pColor;

            // 渲染
            IFillShapeElement pFillShapeElm = new PolygonElementClass();
            IElement pElm = (IElement)pFillShapeElm;
            pElm.Geometry = pBufferGeo;
            pFillShapeElm.Symbol = pSymbol;

            // 添加到地图
            pGraCont.AddElement((IElement)pFillShapeElm, 0);

            // 对缓冲区内的行政区进行高亮
            mainMapControl.Map.SelectByShape(pGeometry, null, false);
            mainMapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            // 刷新地图
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics,null,null);

            SynchronizeEagleEye();
        }

        // 对缓冲区内的行政区进行高亮
        private void districtHighlight(IGeometry pBufferGeo)
        {
            // 设置空间过滤器
            ISpatialFilter pSpatialfilter = new SpatialFilterClass();
            pSpatialfilter.Geometry = pBufferGeo;

            // 遍历图层
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                IFeatureLayer pFeatureLayer = mainMapControl.get_Layer(i) as IFeatureLayer;
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                switch (pFeatureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPolygon:
                        {
                            pSpatialfilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                            break;
                        }
                    default:
                        break;
                }
                pSpatialfilter.GeometryField = pFeatureClass.ShapeFieldName;
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(pSpatialfilter, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                mainMapControl.FlashShape(pFeature.Shape);
                /*
                while (pFeatureCursor != null)
                {
                    IFeature pFeature = pFeatureCursor.NextFeature();
                    IActiveView pActiveView = mainMapControl.ActiveView;
                    IFeatureIdentifyObj featureIdentify = new FeatureIdentifyObject();
                    featureIdentify.Feature = pFeature;
                    IIdentifyObj identify = featureIdentify as IIdentifyObj;
                    identify.Flash(pActiveView.ScreenDisplay);
                }
                */
            }
        }
        #endregion

        #region 鹰眼的实现及同步
        // 变量定义
        private bool bCanDrag;              //鹰眼地图上的矩形框可移动的标志
        private IPoint pMoveRectPoint;      //记录在移动鹰眼地图上的矩形框时鼠标的位置
        private IEnvelope pEnv;             //记录数据视图的Extent
        private bool tab = true;            //控制与main、rain相符
        
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)//也可以判断tabControl1.SelectedTab.Text的值
            {

                tab = true; ; //执行相应的操作
                SynchronizeEagleEye();

            }
            else if (tabControl1.SelectedIndex == 1)
            {

                tab = false;//执行相应的操作
                SynchronizeEagleEye();
            }
        }

        private void mainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
        }

        private void rainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            SynchronizeEagleEye();
        }

        // 鹰眼同步
        private void SynchronizeEagleEye()
        {
            
            if (eagleMapControl.LayerCount > 0)
            {
                eagleMapControl.ClearLayers();
            }
            if (tab)// 主地图
            {
                //设置鹰眼和主地图的坐标系统一致
                eagleMapControl.SpatialReference = mainMapControl.SpatialReference;
                for (int i = mainMapControl.LayerCount - 1; i >= 0; i--)
                {
                    //使鹰眼视图与数据视图的图层上下顺序保持一致
                    ILayer pLayer = mainMapControl.get_Layer(i);
                    if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                    {
                        ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                        for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                        {
                            ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                            IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                            if (pFeatureLayer != null)
                            {
                                eagleMapControl.AddLayer(pLayer);
                            }
                        }
                    }
                    else
                    {
                        IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            eagleMapControl.AddLayer(pLayer);
                        }
                    }
                    //设置鹰眼地图全图显示  
                    eagleMapControl.Extent = mainMapControl.FullExtent;
                    pEnv = mainMapControl.Extent as IEnvelope;
                    DrawRectangle(pEnv);
                    eagleMapControl.ActiveView.Refresh();
                }
            }
            else
            {
                eagleMapControl.SpatialReference = rainMapControl.SpatialReference;
                for (int i = rainMapControl.LayerCount - 1; i >= 0; i--)
                {
                    //使鹰眼视图与数据视图的图层上下顺序保持一致
                    ILayer pLayer = rainMapControl.get_Layer(i);
                    if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                    {
                        ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                        for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                        {
                            ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                            IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                            if (pFeatureLayer != null)
                            {
                                if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint &&
                                    pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint) {
                                        eagleMapControl.AddLayer(pLayer);
                                }
                            }
                        }
                    }
                    else
                    {
                        IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint &&
                                    pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                eagleMapControl.AddLayer(pLayer);
                            }
                        }
                    }
                    //设置鹰眼地图全图显示  
                    eagleMapControl.Extent = rainMapControl.FullExtent;
                    pEnv = rainMapControl.Extent as IEnvelope;
                    DrawRectangle(pEnv);
                    eagleMapControl.ActiveView.Refresh();
                }
            }
        }

        // 鹰眼视图鼠标按下事件
        private void eagleMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (eagleMapControl.Map.LayerCount > 0)
            {
                //按下鼠标左键移动矩形框
                if (e.button == 1)
                {
                    //如果指针落在鹰眼的矩形框中，标记可移动
                    if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
                    {
                        bCanDrag = true;
                    }
                    pMoveRectPoint = new PointClass();
                    pMoveRectPoint.PutCoords(e.mapX, e.mapY);  //记录点击的第一个点的坐标
                }
                //按下鼠标右键绘制矩形框
                else if (e.button == 2)
                {
                    IEnvelope pEnvelope = eagleMapControl.TrackRectangle();

                    IPoint pTempPoint = new PointClass();
                    pTempPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                    mainMapControl.Extent = pEnvelope;
                    //矩形框的高宽和数据试图的高宽不一定成正比，这里做一个中心调整
                    mainMapControl.CenterAt(pTempPoint);
                }
            }
        }

        //移动矩形框
        private void eagleMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
            {
                //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
                eagleMapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
                if (e.button == 2)  //如果在内部按下鼠标右键，将鼠标演示设置为默认样式
                {
                    eagleMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
            }
            else
            {
                //在其他位置将鼠标设为默认的样式
                eagleMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }

            if (bCanDrag)
            {
                double Dx, Dy;  //记录鼠标移动的距离
                Dx = e.mapX - pMoveRectPoint.X;
                Dy = e.mapY - pMoveRectPoint.Y;
                pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
                pMoveRectPoint.PutCoords(e.mapX, e.mapY);
                DrawRectangle(pEnv);
                mainMapControl.Extent = pEnv;
            }
        }

        // 鹰眼视图鼠标弹起事件
        private void eagleMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    mainMapControl.CenterAt(pMoveRectPoint);
                }
                bCanDrag = false;
            }
        }

        //绘制矩形框
        private void mainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        private void rainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        //在鹰眼地图上面画矩形框
        private void DrawRectangle(IEnvelope pEnvelope)
        {
            //在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = eagleMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            //设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = 255;
            pColor.Green = 0;
            pColor.Blue = 0;
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 2;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            //向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 初始底图加载
        
        private void loadInitialMap()
        {

            try
            {
                IWorkspaceFactory pWorkspaceFactory;
                IFeatureWorkspace pFeatureWorkspace;
                IFeatureLayer pFeatureLayer;

                string pFullPath = "../../../ShapeFile/zhejiang.shp";
                int pIndex = pFullPath.LastIndexOf(@"/");
                string pFilePath = pFullPath.Substring(0, pIndex); //文件路径
                string pFileName = pFullPath.Substring(pIndex + 1); //文件名

                // 定义FC 实例化ShapefileWorkspaceFactory工作空间，打开Shape文件
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                // 定义FL 创建并实例化要素集
                pFeatureLayer = new FeatureLayer();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;

                // mainMapControl加载显示
                mainMapControl.Map.AddLayer(pFeatureLayer);
                mainMapControl.ActiveView.Refresh();

                // 同步鹰眼
                SynchronizeEagleEye();
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }
        private void loadInitialRainMap()
        {
            try
            {
                IWorkspaceFactory pWorkspaceFactory;
                IFeatureWorkspace pFeatureWorkspace;
                IFeatureLayer pFeatureLayer;

                string pFullPath = "../../../ShapeFile/zhejiang.shp";
                int pIndex = pFullPath.LastIndexOf(@"/");
                string pFilePath = pFullPath.Substring(0, pIndex); //文件路径
                string pFileName = pFullPath.Substring(pIndex + 1); //文件名

                // 定义FC 实例化ShapefileWorkspaceFactory工作空间，打开Shape文件
                pWorkspaceFactory = new ShapefileWorkspaceFactory();
                pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                // 定义FL 创建并实例化要素集
                pFeatureLayer = new FeatureLayer();
                pFeatureLayer.FeatureClass = pFeatureClass;
                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;

                // rainMapControl加载显示
                rainMapControl.Map.AddLayer(pFeatureLayer);
                rainMapControl.ActiveView.Refresh();

                //// rainMapControl加载测站点
                //pFullPath = "../../../ShapeFile/测站点.shp";
                //pIndex = pFullPath.LastIndexOf(@"/");
                //pFilePath = pFullPath.Substring(0, pIndex); //文件路径
                //pFileName = pFullPath.Substring(pIndex + 1); //文件名

                //// 定义FC 实例化ShapefileWorkspaceFactory工作空间，打开Shape文件
                //pWorkspaceFactory = new ShapefileWorkspaceFactory();
                //pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(pFilePath, 0);
                //pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                //// 定义FL 创建并实例化要素集
                //pFeatureLayer = new FeatureLayer();
                //pFeatureLayer.FeatureClass = pFeatureClass;
                //pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                //// rainMapControl加载显示
                //rainMapControl.Map.AddLayer(pFeatureLayer);
                //rainMapControl.ActiveView.Refresh();

                // 同步鹰眼
                SynchronizeEagleEye();
            }
            catch (Exception ex)
            {
                MessageBox.Show("图层加载失败！" + ex.Message);
            }
        }
        #endregion

        #region 导出图像
        private void 导出图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog exportJPGDialog = new SaveFileDialog();
                exportJPGDialog.Title = "导出JPEG图像";
                exportJPGDialog.Filter = "Jpeg Files(*.jpg,*.jpeg)|*.jpg,*.jpeg";
                exportJPGDialog.RestoreDirectory = true;
                exportJPGDialog.ValidateNames = true;
                exportJPGDialog.OverwritePrompt = true;
                exportJPGDialog.DefaultExt = "jpg";

                if (exportJPGDialog.ShowDialog() == DialogResult.OK)
                {
                    double lScreenResolution;
                    lScreenResolution = mainMapControl.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;

                    IExport pExporter = new ExportJPEGClass() as IExport;
                    //IExport pExporter = new ExportPDFClass() as IExport;//直接可以用！！
                    pExporter.ExportFileName = exportJPGDialog.FileName;
                    pExporter.Resolution = lScreenResolution;

                    tagRECT deviceRECT;
                    
                    deviceRECT = mainMapControl.ActiveView.ExportFrame;

                    IEnvelope pDriverBounds = new EnvelopeClass();

                    pDriverBounds.PutCoords(deviceRECT.left, deviceRECT.bottom, deviceRECT.right, deviceRECT.top);

                    pExporter.PixelBounds = pDriverBounds;

                    ITrackCancel pCancel = new CancelTrackerClass();
                    mainMapControl.ActiveView.Output(pExporter.StartExporting(), (int)lScreenResolution, ref deviceRECT, mainMapControl.ActiveView.Extent, pCancel);
                    pExporter.FinishExporting();
                    pExporter.Cleanup();
                    MessageBox.Show("导出图像成功!", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); return; }
        }
        #endregion

        private void 台风生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "forming") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            mainMapControl.AddLayerFromFile("..\\..\\..\\LayerFile\\forming.lyr");
            //修复shp路径
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "forming") == 0) //只针对需要的这一层筛选
                {
                    IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(i) as IFeatureLayer;

                    string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass("forming");
                }
            }
            mainMapControl.Refresh();
        }

        private void 台风级别升降ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "uppoint") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "downpoint") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            mainMapControl.AddLayerFromFile("..\\..\\..\\LayerFile\\uppoint.lyr");
            mainMapControl.AddLayerFromFile("..\\..\\..\\LayerFile\\downpoint.lyr");
            //修复shp路径
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "uppoint") == 0) //只针对需要的这一层筛选
                {
                    IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(i) as IFeatureLayer;

                    string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass("uppoint");
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "downpoint") == 0) //只针对需要的这一层筛选
                {
                    IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(i) as IFeatureLayer;

                    string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass("downpoint");
                }
            }
            mainMapControl.Refresh();
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "landing") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            mainMapControl.AddLayerFromFile("..\\..\\..\\LayerFile\\landing.lyr");
            //修复shp路径
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "landing") == 0) //只针对需要的这一层筛选
                {
                    IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(i) as IFeatureLayer;

                    string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass("landing");
                }
            }
            mainMapControl.Refresh();
        }

        private void 离开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "leaving") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            mainMapControl.AddLayerFromFile("..\\..\\..\\LayerFile\\leaving.lyr");
            //修复shp路径
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "leaving") == 0) //只针对需要的这一层筛选
                {
                    IFeatureLayer pFeatureLayer = mainMapControl.Map.get_Layer(i) as IFeatureLayer;

                    string filePath = "..\\..\\..\\" + "ShapeFile";//shp文件位置
                    IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();//文件夹
                    IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePath, 0);
                    IFeatureWorkspace pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass("leaving");
                }
            }
            mainMapControl.Refresh();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "forming") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "uppoint") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "downpoint") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "landing") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
            for (int i = 0; i < mainMapControl.LayerCount; i++)
            {
                if (String.Compare(mainMapControl.Map.get_Layer(i).Name.ToString(), "leaving") == 0) //只针对需要的这一层筛选
                {
                    mainMapControl.Map.DeleteLayer(mainMapControl.Map.get_Layer(i));
                }
            }
        }

        #region 属性查询的按钮事件
        private void 台风属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //创建新建属性查询窗体
              FormQueryByAttribute frmQureyByAttribute = new FormQueryByAttribute();
              //将当前主窗体的MapControl控件中的Map对象赋值给FormQueryByAttribute窗体的CurrentMap属性
              if (tabControl1.SelectedIndex == 0)
              {
                  frmQureyByAttribute.CurrentMap = mainMapControl.Map;
              }
              else if (tabControl1.SelectedIndex == 1)
              {
                  frmQureyByAttribute.CurrentMap = rainMapControl.Map;
              }


                //显示属性查询窗体
              frmQureyByAttribute.Show();


        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void 测站点显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //连接远程数据库
            DataLoad dataLoad = new DataLoad();
            //从远程数据库读取并创建站点数据shp
            RefreshStands(dataLoad);
            MessageBox.Show("更新成功");
        }

        public void RefreshStands(DataLoad dataLoad)
        {
            //创建空测站点数据shp 
            //首先创建含基本空间信息和OID字段的shp
            DataOperator dataOperator = new DataOperator(rainMapControl.Map);
            IFeatureClass featureClass = dataOperator.CreateShapefile("..\\..\\..\\", "ShapefileWorkspace", "ShapefileSample");
            if (featureClass == null)
            {
                MessageBox.Show("创建shape文件失败");
                return;
            }

            //给创建的shp添加站名等字段
            IFieldEdit fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "站码";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "站名";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            featureClass.AddField(fieldEdit as IField);
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "降水";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
            featureClass.AddField(fieldEdit as IField);

            //连接数据库，添加所有站点数据

            SqlDataReader stands = dataLoad.ExecuteSQL("select*from 黑格比测站");
            while (stands.Read())
            {

                IFeature feature = featureClass.CreateFeature();
                string stcd = stands["站码"].ToString().Trim();
                string stnm = stands["站名"].ToString().Trim();
                double lat = Convert.ToDouble(stands["经度"].ToString().Trim());
                double lon = Convert.ToDouble(stands["纬度"].ToString().Trim());
                IPoint point = new ESRI.ArcGIS.Geometry.Point();
                //添加形状（含坐标信息）
                point.PutCoords(lat, lon);
                feature.Shape = point;
                //获取各属性的index后插入记录属性值
                int index = feature.Fields.FindField("站码");
                feature.set_Value(index, stcd);
                index = feature.Fields.FindField("站名");
                feature.set_Value(index, stnm);

                //index = feature.Fields.FindField("降水");
                //feature.set_Value(index, stcd);
                //string a=feature.get_Value(3);
                //string b=feature.get_Value(4);
                feature.Store();
            }
            stands.Close();
        }


        private void GetPrecipitation(string s)
        {
            Cursor = Cursors.WaitCursor;

            DataLoad dataLoad = new DataLoad();
            DataOperator dataOperator = new DataOperator(rainMapControl.Map);
            IGeoFeatureLayer geoFeatureLayer = dataOperator.GetLayerByName("ShapefileSample") as IGeoFeatureLayer;
            //定义一循环游标
            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;
            if (featureCursor != null)
            {

                //查找降水字段、站点编号字段的索引号
                int fieldIndexp = geoFeatureLayer.FeatureClass.Fields.FindField("降水");
                int fieldIndexs = geoFeatureLayer.FeatureClass.Fields.FindField("站码");
                //遍历
                while ((feature = featureCursor.NextFeature()) != null)
                {
                    feature.set_Value(fieldIndexp, 0);
                    string ID = feature.Value[fieldIndexs].ToString();
                    SqlDataReader dataReader = dataLoad.ExecuteSQL(s + " and 站码='" + ID + "'");
                    while (dataReader.Read())
                    {
                        string temp_p = dataReader["雨量"].ToString().Trim();
                        if (temp_p == "")
                            continue;
                        double p = Convert.ToDouble(temp_p);
                        double current = (double)feature.get_Value(fieldIndexp);
                        if (current == 0)
                            feature.set_Value(fieldIndexp, p);
                        else
                            feature.set_Value(fieldIndexp, p + current);
                        feature.Store();
                        
                    }
                    dataReader.Close();
                }
            }
        }

        private void 渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer layer = null;
            layer = getLayerFromName("ShapefileSample");
            IFeatureLayer timefli = layer as IFeatureLayer;

            GraduatedColors(timefli, "降水", 6, rainMapControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "select * from 黑格比雨量 where 时间>='" + dateTimePicker1.Text + ":00:00.000'" + " and 时间<'" + dateTimePicker2.Text + ":00:00.000'";
            GetPrecipitation(s);
            MessageBox.Show("添加完成");
            Cursor = Cursors.Default;
        }

        private void 雨量分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RainIsoline rainFrm = new RainIsoline();
            rainFrm.Show();
        }

        private void 行政单元雨量分布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RainByDistrict rainDisFrm = new RainByDistrict();
            rainDisFrm.Show();
        }

        private void 当前时间降水等值线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Dengzhixian jiangshui = new Dengzhixian();
            ILayer layer = null;
            layer = getLayerFromName("ShapefileSample");
            jiangshui.DrawDZX(rainMapControl, layer);
            
            
        }
    }
}