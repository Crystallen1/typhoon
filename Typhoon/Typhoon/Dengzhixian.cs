using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Controls;
using System.IO;

namespace Typhoon
{
    class Dengzhixian
    {
         public void DrawDZX(AxMapControl mapControl, ILayer layer)
            {
                //定义等值线临时shapefile图层存放路径
                string ls_TempSavePath = @"C:\cem\dzx";

                if (!Directory.Exists(ls_TempSavePath))//如果不存在，则创建
                    Directory.CreateDirectory(ls_TempSavePath);

                DirectoryInfo di = new DirectoryInfo(ls_TempSavePath);
                FileInfo[] fi = null;
                fi = di.GetFiles();
                if (fi.Length != 0)//如果目录不为空，则删除目录，然后重建
                {
                    Directory.Delete(ls_TempSavePath, true);
                    Directory.CreateDirectory(ls_TempSavePath);
                }

                //获取地图实例
                IMap pMap = mapControl.Map;

                //提供访问成员，控制一个GeoDataset插值
                IInterpolationOp3 pInterpolationOp = new RasterInterpolationOpClass();

                IFeatureLayer pFeatLayer = layer as IFeatureLayer;
                // Calls function to open the point dataset from disk

                IFeatureClass pFeatCla = pFeatLayer.FeatureClass;


                // Create the input point object
                //创建输入点对象
                IGeoDataset pInputDataset = pFeatLayer as IGeoDataset;

                // Define the search radius
                //定义搜索半径，这个搜索是个什么搜索，尚未知。
                IRasterRadius pRadius = new RasterRadiusClass();
                object Missing = Type.Missing;
                //这个数值是设置搜索范围，7表示离该点最近的7个点为搜索范围
                pRadius.SetVariable(7, ref Missing);

                //Create FeatureClassDescriptor using a value field
                //根据数值字段创建一个FeatureClassDescriptor
                IFeatureClassDescriptor pFCDescriptor = new FeatureClassDescriptorClass();
                pFCDescriptor.Create(pFeatLayer.FeatureClass, null, "降水");

                //Set cellsize for output raster in the environment
                //设置栅格图像的单位大小，如果是以米为单位，大概就是25米，如果以度为单位就是0.001度
                object cellSizeProvider = 0.06;
                IRasterAnalysisEnvironment pEnv = pInterpolationOp as IRasterAnalysisEnvironment;
                pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);

                //Perform the interpolation
                //差值计算
                //出自帮助文档：指数距离。控制周围的意义插值后的价值点。不到一个百分点的影响力从遥远的高功率的结果。它可以是任何实数大于零，但最合理的结果将利用获得的0.5值3。一个常用的功率为2
                IRaster pOutRaster = pInterpolationOp.IDW(pFCDescriptor as IGeoDataset, 2, pRadius, ref Missing) as IRaster;

                //Add output into ArcMap as a raster layer   
                //IRasterLayer pOutRasLayer = new RasterLayerClass();
                //pOutRasLayer.CreateFromRaster(pOutRaster);
                //pOutRasLayer.Name = "栅格";
                //pMap.AddLayer(pOutRasLayer);

                IGeoDataset pGeoDataSet = pOutRaster as IGeoDataset;
                IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
                IWorkspace pShpWorkspace = pWorkspaceFactory.OpenFromFile(ls_TempSavePath, 0);
                ISurfaceOp2 pSurfaceOp2 = new RasterSurfaceOpClass();
                IRasterAnalysisEnvironment pRasterAnalysisEnvironment = pSurfaceOp2 as IRasterAnalysisEnvironment;

                pRasterAnalysisEnvironment.Reset();
                pRasterAnalysisEnvironment.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);
                pRasterAnalysisEnvironment.OutWorkspace = pShpWorkspace;
                double dInterval = 5; //间距
                IGeoDataset pOutputDataSet = pSurfaceOp2.Contour(pGeoDataSet, dInterval, ref Missing, ref Missing);


                IFeatureClass pFeatureClass = pOutputDataSet as IFeatureClass;
                IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                pFeatureLayer.FeatureClass = pFeatureClass;

                IGeoFeatureLayer pGeoFeatureLayer = pFeatureLayer as IGeoFeatureLayer;

                pGeoFeatureLayer.DisplayAnnotation = true;
                pGeoFeatureLayer.DisplayField = "Contour";
                pGeoFeatureLayer.Name = "等值线";

                pMap.AddLayer(pGeoFeatureLayer);
                mapControl.Refresh();
            }
        }
    }

