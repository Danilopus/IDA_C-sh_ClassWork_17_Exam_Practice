// ClassWork template 1.2 // date: 29.09.2023

using IDA_C_sh_ClassWork_17_Exam_Practice;
using Service;
using System;
using System.Linq.Expressions;
using System.Text;



// ClassWork 17 : [Exam Practice] 17.11.2023 --------------------------------

namespace IDA_C_sh_ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Task_1();
            // Task_2();
            // Task_3();


            Console.ReadKey();

        }

        public static void Task_1() 
        {
            MultyRotorUAV multyRotorUAV_1 = new MultyRotorUAV();
            ReactiveUAV reactiveUAV_1 = new ReactiveUAV();
            PlanerUAV planerUAV_1 = new PlanerUAV();

            ControlSystem controlSystem_1 = new ControlSystem();

            controlSystem_1.AddToControlSystem(multyRotorUAV_1);
            controlSystem_1.AddToControlSystem(reactiveUAV_1);
            controlSystem_1.AddToControlSystem(planerUAV_1);

            Subscriber subscriber_1 = new Subscriber();


            // Проверим местоположение всех БПЛА на момент старта
            Console.WriteLine("Положения БПЛА на старте");
            foreach (var item in controlSystem_1.MovementInfo())
                Console.WriteLine(item.Key.Model + " in " + item.Value);
            
            
            
            // Отправим все БПЛА в точку (100, 100, 100)            
            Point3D point3D_new = new Point3D(100,100, 100);
            Console.WriteLine($"\n\nОтправляем все БПЛА в точку {point3D_new}");
            controlSystem_1.MoveToPoint(multyRotorUAV_1, point3D_new);
            controlSystem_1.MoveToPoint(reactiveUAV_1, point3D_new);
            controlSystem_1.MoveToPoint(planerUAV_1, point3D_new);

            // Определим местоположение всех БПЛА после перемещения
            Console.WriteLine("\n\nПоложения БПЛА после перемещения в точку (100, 100, 100)");
            foreach (var item in controlSystem_1.MovementInfo())
                Console.WriteLine(item.Key.Model + " in " + item.Value);

            // Запишем текущие данные о БПЛА в файлы JSON и XML
            controlSystem_1.SaveUAVInfoToJSONFile();
            // controlSystem_1.SaveUAVInfoToXMLFile();

            // Подписчик запрашивает данные о положении БПЛА
            controlSystem_1.SubscribeToMovementInfo(subscriber_1);
            Console.WriteLine("\n\nПодписчик запрашивает данные о положении БПЛА");
            foreach (var item in subscriber_1.UAV_Info)
                Console.WriteLine(item.Key.Model + " in " + item.Value);


        }
        public static void Task_2() { }
        public static void Task_3() { }

    } // class Programm
}// namespace

