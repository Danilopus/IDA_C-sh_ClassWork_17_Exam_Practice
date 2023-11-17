using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_17_Exam_Practice
{
    public struct Point3D
    {
        double x;
        double y;
        double z;
        public Point3D (double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return $"point: {x}, {y}, {z}";
        }
    }
}
