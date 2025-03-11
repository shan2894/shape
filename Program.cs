namespace program
{
    using System;
    using System.Collections.Generic;
    using shape;

    class Program
    {
        static void Main()
        {
            // 創建三個形狀
            Triangle triangle = new Triangle(10, 5);  // 面積 = 25
            Trapezoid trapezoid = new Trapezoid(8, 5, 4); // 面積 = 26
            Circle circle = new Circle(7); // 面積 ≈ 153.94

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
}
