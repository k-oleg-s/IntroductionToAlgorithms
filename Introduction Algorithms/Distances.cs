using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public  static  class Distances
{

    public static float PointDistance1(PointClassFl pointOne, PointClassFl pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return MathF.Sqrt((x * x) + (y * y));
    }

    public static float PointDistance2(PointStructFl pointOne, PointStructFl pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return MathF.Sqrt((x * x) + (y * y));
    }

    public static double PointDistance3(PointStructDbl pointOne, PointStructDbl pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        double z = (x * x) + (y * y);
        return Math.Sqrt(z);
    }

    public static float PointDistance4(PointStructFl pointOne, PointStructFl pointTwo)
    {
        float x = pointOne.X - pointTwo.X;
        float y = pointOne.Y - pointTwo.Y;
        return (x * x) + (y * y);
    }
}
