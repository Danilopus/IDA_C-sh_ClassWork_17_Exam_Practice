using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_17_Exam_Practice
{
    internal class MultyRotorUAV : I_UAV
    {
        public string Model { get; set; } = "MultyRotorUAV";
        public double Weight { get; set; } = 10; // kg
        public double MaxSpeed { get; set; } = 100; // km/h
        public Point3D CurrentPosition { get; set; } = new Point3D();

        public void MoveToPoint(Point3D point)
        {
            Move_event(point);
            CurrentPosition = point;
        }
        public event Action<Point3D> Move_event;
        void Move_event_handler(Point3D point)
        {
            Console.WriteLine($"Info through event: UAV {Model} moving to {point}");
        }
        public MultyRotorUAV()
        {
            Move_event = Move_event_handler;
        }
    }
}
