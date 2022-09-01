using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Introduction_Algorithms;

namespace Introduction_Algorithms;

public class UnitTest1
{



    PointClassFl[] pointsOneC = new PointClassFl[10];
    PointClassFl[] pointsTwoC = new PointClassFl[10];


    PointStructFl[] pointsOneS = new PointStructFl[10];
    PointStructFl[] pointsTwoS = new PointStructFl[10];


    PointStructDbl[] pointsOneSD = new PointStructDbl[10];
    PointStructDbl[] pointsTwoSD = new PointStructDbl[10];



    public UnitTest1()
    {
        Random rnd = new Random();
        for (int i = 0; i < pointsOneC.Length; i++)
        {
            pointsOneC[i] = new PointClassFl();
            pointsOneC[i].X = rnd.Next(100);
            pointsOneC[i].Y = rnd.Next(100);
            pointsTwoC[i] = new PointClassFl();
            pointsTwoC[i].X = rnd.Next(100);
            pointsTwoC[i].Y = rnd.Next(100);
        }


        for (int i = 0; i < pointsOneS.Length; i++)
        {
            pointsOneS[i].X = rnd.Next(100);
            pointsOneS[i].Y = rnd.Next(100);
            pointsTwoS[i].X = rnd.Next(100);
            pointsTwoS[i].Y = rnd.Next(100);
        }



        for (int i = 0; i < pointsOneS.Length; i++)
        {
            pointsOneSD[i].X = rnd.Next(100);
            pointsOneSD[i].Y = rnd.Next(100);
            pointsTwoSD[i].X = rnd.Next(100);
            pointsTwoSD[i].Y = rnd.Next(100);
        }


    }


    //метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).




    [Benchmark(Description = "point distance 1")]
    public void test1()
    {
        for (int i = 0; i < pointsOneC.Length; i += 2)
        {
            float r = Distances.PointDistance1(pointsOneC[i], pointsTwoC[i]);
        }
    }




    //метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).

    [Benchmark(Description = "point distance 2")]
    public void test2()
    {
        for (int i = 0; i < pointsOneS.Length; i += 2)
        {
            float r = Distances.PointDistance2(pointsOneS[i], pointsTwoS[i]);
        }
    }





    //метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).


    [Benchmark(Description = "point distance 3")]
    public void test3()
    {
        for (int i = 0; i < pointsOneS.Length; i += 2)
        {
            double r = Distances.PointDistance3(pointsOneSD[i], pointsTwoSD[i]);
        }
    }




    //Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float)

    [Benchmark(Description = "point distance 4")]
    public void test4()
    {
        for (int i = 0; i < pointsOneS.Length; i += 2)
        {
            float r = Distances.PointDistance4(pointsOneS[i], pointsTwoS[i]);
        }
    }

}
