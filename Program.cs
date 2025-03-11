using System;
using System.Collections.Generic;

class Program
{
    // 父類別 Shape
    public abstract class Shape : IComparable<Shape>
    {
        public double area { get; set; }
        public double perimeter { get; set; }

        public abstract void CountArea();  // 算面積

        public int CompareTo(Shape? other)
        {
            if (other == null)
                throw new ArgumentNullException("傳入的形狀為null值");
            return this.area.CompareTo(other.area);
        }
    }

    // 三角形類別
    public class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
            CountArea();
        }

        public override void CountArea()
        {
            area = 0.5 * BaseLength * Height;
        }

        public void Display()
        {
            Console.WriteLine($"三角形 - 底: {BaseLength}, 高: {Height}, 面積: {area}");
        }
    }

    // 梯形類別
    public class Trapezoid : Shape
    {
        public double Base1 { get; set; }
        public double Base2 { get; set; }
        public double Height { get; set; }

        public Trapezoid(double base1, double base2, double height)
        {
            Base1 = base1;
            Base2 = base2;
            Height = height;
            CountArea();
        }

        public override void CountArea()
        {
            area = 0.5 * (Base1 + Base2) * Height;
        }

        public void Display()
        {
            Console.WriteLine($"梯形 - 上底: {Base1}, 下底: {Base2}, 高: {Height}, 面積: {area}");
        }
    }

    // 圓形類別
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
            CountArea();
        }

        public override void CountArea()
        {
            area = Math.PI * Math.Pow(Radius, 2);
        }

        public void Display()
        {
            Console.WriteLine($"圓形 - 半徑: {Radius}, 面積: {area:F2}");
        }
    }

    static void Main()
    {
        // 創建三個形狀
        Triangle triangle = new Triangle(10, 5);
        Trapezoid trapezoid = new Trapezoid(8, 5, 4);
        Circle circle = new Circle(7);

        // 放入 List 方便排序
        List<Shape> shapes = new List<Shape> { triangle, trapezoid, circle };

        // 排序 (CompareTo 由 Shape 類別提供)
        shapes.Sort();

        // 輸出排序結果
        Console.WriteLine("形狀面積由小到大排序：");
        foreach (var shape in shapes)
        {
            if (shape is Triangle)
                Console.WriteLine($"三角形 - 面積: {shape.area:F2}");
            else if (shape is Trapezoid)
                Console.WriteLine($"梯形 - 面積: {shape.area:F2}");
            else if (shape is Circle)
                Console.WriteLine($"圓形 - 面積: {shape.area:F2}");
        }
    }
}
