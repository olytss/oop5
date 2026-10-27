using oop3.model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace oop3.services
{
    internal static class BinarySaveService
    {
       static public void SavePcToBinary(this PC pc, string filePath)
        {
            // Вимикаємо попередження про застарілий BinaryFormatter
                #pragma warning disable SYSLIB0011
            BinaryFormatter formatter = new BinaryFormatter();


            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(stream, pc);
                Console.WriteLine($"\n[Успіх] Об'єкт {pc.Name} серіалізовано у файл: {filePath}");
            }
        }
    }
}
