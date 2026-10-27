using oop3.output_view_;
using System;
using System.Drawing;

namespace oop3.services
{
    public class ConsoleControlsService
    {
        public static string[] options = { "Display all PCs", "Get information about a specific PC", "Save to file" };
        public static string prefix = "> ";

        public static readonly object ConsoleLock = new object();
                
        public static void CurrentOption(string[] options, int selectedIndex, string prefix)
        {
            lock (ConsoleLock)
            {
              
                Console.SetCursorPosition(0, 10);

                string textToPrint = $"Current selection: {prefix}{options[selectedIndex]}";

               
                Console.Write(textToPrint.PadRight(Console.WindowWidth - 1));
            }
        }

        public static void DrawControls()
        {
            Console.CursorVisible = false; 

            Point[] positionsOfOptions = new Point[options.Length];
            int selectedIndex = 0;

           
            for (int i = 0; i < options.Length; i++)
            {
                positionsOfOptions[i] = new Point(0, Console.CursorTop);
                Console.WriteLine();
            }

           
            if (!ThreadingService.OptionThread.IsAlive)
            {
                ThreadingService.OptionThread.Start();
            }

            RenderMenu(positionsOfOptions, selectedIndex);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                
                        if (selectedIndex < 0)
                        {
                            selectedIndex = options.Length - 1; 
                        }
                  
                        ThreadingService.currentOptionIndex = selectedIndex;
                        RenderMenu(positionsOfOptions, selectedIndex);
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                 
                        if (selectedIndex >= options.Length)
                        {
                            selectedIndex = 0; 
                        }
                     
                        ThreadingService.currentOptionIndex = selectedIndex;
                        RenderMenu(positionsOfOptions, selectedIndex);
                        break;

                    case ConsoleKey.Enter:
                        
                        lock (ConsoleLock)
                        {
                            switch (selectedIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    var savedPcs = PcService.ReadFromFile();
                                    foreach (var pc in savedPcs)
                                    {
                                        Console.WriteLine($"Name: {pc.Name}, Screen Size: {pc.ScreenSize}, Cores Count: {pc.CoresCount}, Price: {pc.Price}, RAM: {pc.Ram}, Windows: {pc.Windows}, PC ID: {pc.PcId}");
                                    }
                                    break;
                                case 1:
                                    Console.Clear();
                                   
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("What pc would you like to save?");
                                    int pcIndex = int.Parse(Console.ReadLine());
                                    PcService.saveToFile(PcService.pcList.ElementAt(pcIndex-1));
                                    try
                                    {
                                        BinarySaveService.SavePcToBinary(PcService.pcList.ElementAt(pcIndex - 1), "C:\\Users\\artem\\source\\repos\\oop3\\oop3\\TextData\\test.bin");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Too old stuff!!");
                                    }
                                    Console.Clear();
                                    RenderMenu(positionsOfOptions, selectedIndex);
                                    break;
                            }
                        }
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);

           
            ThreadingService.IsRunning = false;
            Console.CursorVisible = true;
        }

      
        private static void RenderMenu(Point[] positions, int selectedIndex)
        {
            lock (ConsoleLock)
            {
                for (int i = 0; i < options.Length; i++)
                {
          
                    Console.SetCursorPosition(positions[i].X, positions[i].Y);

                    if (i == selectedIndex)
                    {
                   
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write($"{prefix}{options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
          
                        string blankPrefix = new string(' ', prefix.Length);
                        Console.Write($"{blankPrefix}{options[i]}");
                    }
                }
            }
        }
    }
}