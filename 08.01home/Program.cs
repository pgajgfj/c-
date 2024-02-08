using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08._01home
{
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double a, double b, double c)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }

        public override double GetArea()
        {
            double s = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
        }

        public override double GetPerimeter()
        {
            return sideA + sideB + sideC;
        }
    }

    class Square : GeometricFigure
    {
        private double side;

        public Square(double s)
        {
            side = s;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override double GetPerimeter()
        {
            return 4 * side;
        }
    }

    class Rectangle : GeometricFigure
    {
        private double length;
        private double width;

        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }

        public override double GetArea()
        {
            return length * width;
        }

        public override double GetPerimeter()
        {
            return 2 * (length + width);
        }
    }

    class Rhombus : GeometricFigure
    {
        private double side;
        private double height;

        public Rhombus(double s, double h)
        {
            side = s;
            height = h;
        }

        public override double GetArea()
        {
            return side * height;
        }

        public override double GetPerimeter()
        {
            return 4 * side;
        }
    }

    class Parallelogram : GeometricFigure
    {
        private double baseSide;
        private double side;
        private double height;

        public Parallelogram(double b, double s, double h)
        {
            baseSide = b;
            side = s;
            height = h;
        }

        public override double GetArea()
        {
            return baseSide * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (baseSide + side);
        }
    }

    class Trapezoid : GeometricFigure
    {
        private double base1;
        private double base2;
        private double side1;
        private double side2;
        private double height;

        public Trapezoid(double b1, double b2, double s1, double s2, double h)
        {
            base1 = b1;
            base2 = b2;
            side1 = s1;
            side2 = s2;
            height = h;
        }

        public override double GetArea()
        {
            return ((base1 + base2) / 2) * height;
        }

        public override double GetPerimeter()
        {
            return base1 + base2 + side1 + side2;
        }
    }

    class Circle : GeometricFigure
    {
        private double radius;

        public Circle(double r)
        {
            radius = r;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Ellipse : GeometricFigure
    {
        private double semiMajorAxis;
        private double semiMinorAxis;

        public Ellipse(double a, double b)
        {
            semiMajorAxis = a;
            semiMinorAxis = b;
        }

        public override double GetArea()
        {
            return Math.PI * semiMajorAxis * semiMinorAxis;
        }

        public override double GetPerimeter()
        {
            double a = semiMajorAxis;
            double b = semiMinorAxis;
            return 2 * Math.PI * Math.Sqrt((a * a + b * b) / 2);
        }
    }

    class CompoundFigure : GeometricFigure
    {
        private GeometricFigure[] figures;

        public CompoundFigure(params GeometricFigure[] figures)
        {
            this.figures = figures;
        }

        public override double GetArea()
        {
            double area = 0;
            foreach (var figure in figures)
            {
                area += figure.GetArea();
            }
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 0;
            foreach (var figure in figures)
            {
                perimeter += figure.GetPerimeter();
            }
            return perimeter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Square square = new Square(4);
            Rectangle rectangle = new Rectangle(3, 5);
            Rhombus rhombus = new Rhombus(4, 3);
            Parallelogram parallelogram = new Parallelogram(5, 4, 3);
            Trapezoid trapezoid = new Trapezoid(3, 6, 4, 4, 5);
            Circle circle = new Circle(4);
            Ellipse ellipse = new Ellipse(3, 2);

            CompoundFigure compoundFigure = new CompoundFigure(triangle, square, rectangle, rhombus, parallelogram, trapezoid, circle, ellipse);

            Console.WriteLine("Compound Figure Area: " + compoundFigure.GetArea());
            Console.WriteLine("Compound Figure Perimeter: " + compoundFigure.GetPerimeter());
        }
    }

}
