using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using System.Text.RegularExpressions;

namespace Typhoon
{
    public class TxtLoader
    {
        public string time;   //时间
        public string lat;      //经度
        public string lon;         //纬度
        public string pressure;        //大气压
        public string wind;           //风速
        public string direction;        //未来移向
        public string futurespd;      //未来移速
        public string level;           //风力等级
        public string classes;        //台风类型

        public TxtLoader Next;
        public TxtLoader()
        {
            time = null;
            lat = null;
            lon = null;
            pressure = null;
            wind = null;
            direction = null;
            futurespd = null;
            level = null;
            classes = null;
        }

        public IFeatureClass CreateShapefile(IMap m_map, string sParentDirecotry, string sWorkspaceName, string sFileName)
        {
            /*if (System.IO.Directory.Exists(sParentDirecotry + sWorkspaceName))
                DeleteDirectory(sParentDirecotry + sWorkspaceName);*/

            IWorkspaceFactory workspaceFactory = new ShapefileWorkspaceFactory();

            //原代码
            //IWorkspaceName workspaceName = workspaceFactory.Create(sParentDirecotry, sWorkspaceName, null, 0);
            //ESRI.ArcGIS.esriSystem.IName name = workspaceName as ESRI.ArcGIS.esriSystem.IName;
            //IWorkspace workspace = (IWorkspace)name.Open();

            //更改后的代码
            IWorkspace workspace = workspaceFactory.OpenFromFile(sParentDirecotry + sWorkspaceName, 0);
            IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;

            //OID字段
            IFields fields = new Fields();
            IFieldsEdit fieldsEdit = fields as IFieldsEdit;
            IFieldEdit fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "OID";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID;
            fieldsEdit.AddField((IField)fieldEdit);

            //创建地理定义,其中坐标系与map的坐标系统一
            IGeometryDefEdit geoDefEdit = (new GeometryDef()) as IGeometryDefEdit;
            ISpatialReference spatialReference = m_map.SpatialReference;
            geoDefEdit.SpatialReference_2 = spatialReference;
            geoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;

            //创建并编辑形状字段
            //OID字段
            fieldEdit = (IFieldEdit)new Field();
            fieldEdit.Name_2 = "Shape";
            fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            fieldEdit.GeometryDef_2 = geoDefEdit;
            fieldsEdit.AddField((IField)fieldEdit);

            IFeatureClass featureClass = featureWorkspace.CreateFeatureClass(sFileName, fields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            if (featureClass == null)
                return null;
            return featureClass;

        }

        public static void DeleteDirectory(string target_dir)      //删除已有工作空间中的内容和其本身
        {
            string[] files = Directory.GetFiles(target_dir);
            //string[] dirs = Directory.GetDirectories(target_dir);

            /*foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }*/
            for (int i = 0; i < files.Length; i++)
            {
                if (Regex.IsMatch(files[i], "centuralpoint"))
                {
                    string file = files[i];
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
            }
            /*foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }*/

            //Directory.Delete(target_dir, false);
        }
    }    
}
