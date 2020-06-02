using System;

namespace _2DForms
{
    class Program
    {
        static void Main(string[] args)
        {
            void Form(IForm2D form)
            {
                Console.WriteLine(form.ToString());
                Console.WriteLine($"The area of the form {form.Area()}.");
                Console.WriteLine($"The perimeter of the form {form.Perimeter()}.\n");
            }

            Circle circle1 = new Circle(5, "circle1");
            Form(circle1);

            Square square1 = new Square(3, "square1");
            Form(square1);
        }
    }
}
