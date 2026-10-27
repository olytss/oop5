using oop3.model;
using oop3.services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace oop3.output_view_
{
    internal class outputClassConsole
    {
      static  public void displayPC() 
        {
            foreach (var pc in PcService.pcList) // колись я навчуся звертатися до листів по повній адресі 
            {
                Console.WriteLine($"PC ID: {pc.PcId}, Name: {pc.Name}, Screen Size: {pc.ScreenSize}, Cores Count: {pc.CoresCount}, Price: {pc.Price}, RAM: {pc.Ram}, OS: {pc.Windows}");
            }
        }
        public void getInfoById(int id)
        {
            Console.WriteLine("What pc would you like get information about?");
            int pcID = Convert.ToInt32(Console.ReadLine());
            PC wantedPC = PcService.pcList.ElementAtOrDefault(id) ?? null;
            if (wantedPC != null)
            {
                Console.WriteLine($"PC ID: {wantedPC.PcId}, Name: {wantedPC.Name}, Screen Size: {wantedPC.ScreenSize}, Cores Count: {wantedPC.CoresCount}, Price: {wantedPC.Price}, RAM: {wantedPC.Ram}, OS: {wantedPC.Windows}");
            }
            else
            {
                Console.WriteLine("PC not found.");
            }
        }
    }
}
