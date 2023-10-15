using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;


namespace Typhoon
{
    class DataOperator
    {
        private IMap m_map;

        public DataOperator(IMap map)
        {
            // TODO: Complete member initialization
            this.m_map = map;
        }

        public ILayer GetLayerByName(String sLayerName)
        {
            if (sLayerName == "" || m_map == null)
                return null;
            for (int i = 0; i < m_map.LayerCount; i++)
                if (m_map.get_Layer(i).Name == sLayerName)
                    return m_map.get_Layer(i);
            return null;
        }

        public IFeatureClass GetFeatureClass(
            String shpPath,
            String shpName)
        {
            IWorkspaceFactory WorkspaceFactory;//using ESRI.ArcGIS.Geodatabase;
            IFeatureWorkspace FeatureWorkspace;
            //实例化ShapefileWorkspaceFactory工作空间，打开Shape文件
            WorkspaceFactory = new ShapefileWorkspaceFactory();//using ESRI.ArcGIS.DataSourcesFile;
            FeatureWorkspace = (IFeatureWorkspace)WorkspaceFactory.OpenFromFile(shpPath, 0);
            //创建并实例化要素集
            IFeatureClass FeatureClass = FeatureWorkspace.OpenFeatureClass(shpName);
            return FeatureClass;
        }

        public IFeatureClass CreateShapefile(
            String sParentDirectory, //上级路径
            String sWorkspaceName, // 包含Shape文件的文件夹名
            String sFileName) //Shape文件名
        {
            //如果路径文件已经存在，则删除
            if (System.IO.Directory.Exists(sParentDirectory + sWorkspaceName))
            {
                System.IO.Directory.Delete(sParentDirectory + sWorkspaceName, true);
            }
            //通过接口创建针对Shape文件的工作空间
            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspaceName workspaceName = workspaceFactory.Create(sParentDirectory, sWorkspaceName, null, 0);
            ESRI.ArcGIS.esriSystem.IName name = workspaceName as ESRI.ArcGIS.esriSystem.IName;

            //打开并访问新建的工作空间
            IWorkspace workspace = (IWorkspace)name.Open();
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            //创建字段集
            IFields fields = new FieldsClass();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;

            //创建序号列
            IFieldEdit fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "OID";
            fieldEdit.AliasName_2 = "序号";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建名字列
            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Name";
            fieldEdit.AliasName_2 = "名称";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建地理定义,设置空间参考和几何类型
            IGeometryDefEdit geoDefEdit = new GeometryDefClass();
            ISpatialReference spatialReference = m_map.SpatialReference;//????
            geoDefEdit.SpatialReference_2 = spatialReference;
            geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;

            //创建并编辑形状字段
            fieldEdit = new FieldClass();
            fieldEdit.Name_2 = "Shape";
            fieldEdit.AliasName_2 = "形状";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geoDefEdit;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建要素类
            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(sFileName,
                fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            if (featureClass == null)
            {
                return null;
            }

            return featureClass;

        }

        public bool AddFeatureClassToMap(
            IFeatureClass featureClass,
            String sLayerName,
            IFeatureRenderer renderer)
        {
            if (featureClass == null || sLayerName == null || m_map == null)
            {
                return false;
            }
            //创建要素图层对象
            IFeatureLayer featureLayer = new FeatureLayerClass();
            featureLayer.FeatureClass = featureClass;
            featureLayer.Name = sLayerName;

            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            geoFeatureLayer.Renderer = renderer;
            //将要素图层转换为一般图层
            ILayer layer = featureLayer as ILayer;
            if (layer == null)
            {
                return false;
            }

            //转换为活动视图
            m_map.AddLayer(layer);
            IActiveView activeView = m_map as IActiveView;
            if (activeView == null)
            {
                return false;
            }

            activeView.Refresh();
            return true;

        }



    }
}
