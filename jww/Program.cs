using System;
using System.IO;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

class Program
{
    static void Main(string[] args)
    {
        // 定义左下角坐标和比例尺
        double minX = 117;
        double minY = 34;
        double scale = 1000; // 1:1000

        // 创建 GeometryFactory 对象，指定坐标系统（SRID）
        GeometryFactory geometryFactory = new GeometryFactory(new PrecisionModel(), 4326); // 使用 WGS 84，SRID 4326

        // 创建 FeatureCollection 对象
        FeatureCollection featureCollection = new FeatureCollection();

        // 绘制公里网
        for (double x = minX; x <= 10000; x += scale)
        {
            LineString lineString = geometryFactory.CreateLineString(new Coordinate[]
            {
                new Coordinate(x, minY),
                new Coordinate(x, minY + 10000)
            });
            Feature feature = new Feature(lineString, new AttributesTable());
            feature.Attributes.Add("Label", x.ToString()); // 添加坐标标注
            featureCollection.Add(feature);
        }

        for (double y = minY; y <= 10000; y += scale)
        {
            LineString lineString = geometryFactory.CreateLineString(new Coordinate[]
            {
                new Coordinate(minX, y),
                new Coordinate(minX + 10000, y)
            });
            Feature feature = new Feature(lineString, new AttributesTable());
            feature.Attributes.Add("Label", y.ToString()); // 添加坐标标注
            featureCollection.Add(feature);
        }

        // 绘制图框
        LineString border = geometryFactory.CreateLineString(new Coordinate[]
        {
            new Coordinate(minX, minY),
            new Coordinate(minX + 10000, minY),
            new Coordinate(minX + 10000, minY + 10000),
            new Coordinate(minX, minY + 10000),
            new Coordinate(minX, minY)
        });
        Feature borderFeature = new Feature(border, new AttributesTable());
        featureCollection.Add(borderFeature);

        // 保存为 shp 文件
        string shpPath = "output3.shp";
        string shxPath = "output3.shx";
        ShapefileDataWriter writer = new ShapefileDataWriter(shpPath, geometryFactory);
        writer.Header = new DbaseFileHeader();
        writer.Write(featureCollection);
        //writer.Close(); // 这一行可以删除，因为 ShapefileDataWriter 不需要手动关闭

        Console.WriteLine("Shapefile saved successfully!");
    }
}
