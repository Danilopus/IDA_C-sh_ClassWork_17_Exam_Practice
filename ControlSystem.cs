using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IDA_C_sh_ClassWork_17_Exam_Practice
{
    internal class ControlSystem
    {
        public List<I_UAV> UAV_list = new List<I_UAV>();
        public void AddToControlSystem(I_UAV new_uav)
        {
            UAV_list.Add(new_uav);
        }
        public void RemoveFromControlSystem(I_UAV new_uav)
        {
            UAV_list.Remove(new_uav);
        }
        public void MoveToPoint(I_UAV uav_to_operate, Point3D point)
        {
            uav_to_operate.MoveToPoint(point);
        }
        public Dictionary <I_UAV, Point3D> MovementInfo()
        {
            Dictionary<I_UAV, Point3D> current_positions = new Dictionary<I_UAV, Point3D>();
            foreach (var uav in UAV_list)
                current_positions.Add(uav, uav.CurrentPosition);

            return current_positions;
        }
        public delegate Dictionary<I_UAV, Point3D> ControlSystemInfo();

        public void SaveUAVInfoToTextFile()
        {
            string file_name = "UAV_Info.txt";
            FileStream fs = new FileStream(file_name, FileMode.Create);
            StreamWriter streamWriter_1 = new StreamWriter(fs); 
            foreach (var uav in UAV_list)
                streamWriter_1.WriteLine(uav.ToString());
            streamWriter_1.Close();
        }
        public void SaveUAVInfoToJSONFile()
        {
            string file_name = "UAV_Info.json";
            string json_data = JsonSerializer.Serialize(UAV_list);
            FileStream fs = new FileStream(file_name, FileMode.Create);
            StreamWriter streamWriter_1 = new StreamWriter(fs);
            streamWriter_1.WriteLine(json_data);
            streamWriter_1.Close();
        }
        public void SaveUAVInfoToXMLFile()
        {
            string file_name = "UAV_Info.xml";
            XmlSerializer xmlSerializer_1 = new XmlSerializer(typeof(List<I_UAV>));
            FileStream fs = new FileStream(file_name, FileMode.Create);
            xmlSerializer_1.Serialize(fs, UAV_list);
            fs.Close();
        }

        public void SubscribeToMovementInfo(Subscriber subscriber)
        {
            ControlSystemInfo InfoSubscribe = MovementInfo;
            subscriber.GetInfoSubscribe(InfoSubscribe());
        }

    }
}
