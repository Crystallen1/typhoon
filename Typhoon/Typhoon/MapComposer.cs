using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace Typhoon
{
    class MapComposer
    {
        public static String GetRendererTypeByLayer(ILayer layer)
        {
            if (layer == null)
                return ("获取图层失败");
            IGeoFeatureLayer GeoFeatureLayer = layer as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = GeoFeatureLayer.Renderer;
            if (featureRenderer is ISimpleRenderer)
            {
                return ("SimpleRenderer");
            }
            return ("not coded yet");
        }

        //用于获取指定图层的符号信息
        public static ISymbol GetSymbolFromLayer(ILayer layer)
        {
            if (layer == null)
                return null;
            //利用ifeaturelayer访问指定图层，获取其是否有要素，若失败，返回空
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureCursor featureCursor = featureLayer.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            if (feature == null)
                return null;
            //利用IGeoFeatureLayer访问指定图层，获取其渲染器，并判断是否成功
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            IFeatureRenderer featureRenderer = geoFeatureLayer.Renderer;
            if (featureRenderer == null)
                return null;
            ISymbol symbol = featureRenderer.get_SymbolByFeature(feature);
            return symbol;
        }



        //用于统一设置指定图层符号的颜色，并进行简单渲染
        public static bool RenderSimply(ILayer layer, IColor color)
        {
            if (layer == null || color == null)
                return false;
            ISymbol symbol = GetSymbolFromLayer(layer);
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureClass featureClass = featureLayer.FeatureClass;
            if (featureClass == null)
                return false;
            //根据不同形状设置颜色
            esriGeometryType geometryType = featureClass.ShapeType;
            switch (geometryType)
            {
                case esriGeometryType.esriGeometryPolyline:
                    {
                        ISimpleLineSymbol simpleLineSymbol = symbol as ISimpleLineSymbol;
                        simpleLineSymbol.Color = color;
                        break;
                    }
                default:
                    return false;
            }

            //创建简单渲染器，设置其符号，实现渲染
            ISimpleRenderer simpleRenderer = new SimpleRenderer();
            simpleRenderer.Symbol = symbol;
            IFeatureRenderer featureRenderer = simpleRenderer as IFeatureRenderer;
            IGeoFeatureLayer geoFeatureLayer = featureLayer as IGeoFeatureLayer;
            geoFeatureLayer.Renderer = featureRenderer;
            return true;
        }
    }
}
