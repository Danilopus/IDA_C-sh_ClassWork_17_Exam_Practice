using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDA_C_sh_ClassWork_17_Exam_Practice
{
    internal class Subscriber
    {
        public Dictionary<I_UAV, Point3D> UAV_Info;
        public void GetInfoSubscribe(Dictionary<I_UAV, Point3D> Info_from_ControlSystem)
        {
            UAV_Info = Info_from_ControlSystem;
        }
    }
}
