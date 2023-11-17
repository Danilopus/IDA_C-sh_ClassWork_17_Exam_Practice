using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_17_Exam_Practice
{
    internal interface I_UAV
    {
        string Model { get; set; }
        double Weight { get; set; }
        double MaxSpeed { get; set; }
        Point3D CurrentPosition { get; set; }
        void MoveToPoint(Point3D point);
        
        event Action<Point3D> Move_event;
    }
}
