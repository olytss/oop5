using ConsoleApp3;
using oop3.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop3.model
{
    public class PC
    {
        
       
            public static List<PC> pcList = new List<PC>(PcService.InitializePc());
            public int PcId{ get ; set; }
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Enter value");
                    }
                    else
                    {
                        _name = value;
                    }
                }
            }
            private string _screenSize;
            public string ScreenSize
            {
                get
                {
                    return _screenSize;
                }
                set
                {
                    _screenSize = value;
                }
            }

            private int _coresCount;
            public int CoresCount
            {
                get
                {
                    return _coresCount;
                }
                set
                {
                    if (value < 1 || value > 96)
                    {
                        Console.WriteLine("Invalid cores");
                    }
                    else
                    {
                        _coresCount = value;
                    }
                }
            }
            private int _price;

            public int Ram
            {
                get; set;
            }

            public string Windows
            {
                get;

            }

            public int Price
            {
                get
                {
                    return _price;
                }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("price invalid");
                    }
                    else
                    {
                        _price = value;
                    }
                }
            }
            public PC(string name, string screenSize, int coresCount, int price, int ram, string windows, int id)
            {
                Name = name;
                ScreenSize = screenSize;
                CoresCount = coresCount;
                Price = price;
                Ram = ram;
                Windows = windows;
                PcId = id;

            }
            public PC()
            {

            }
            public PC(string name, string screenSize, int coresCount)
            {
                Name = name;
                ScreenSize = screenSize;
                CoresCount = coresCount;
            }

            static public void ToString(PC pc)
            {
                Console.WriteLine($"Manufacturer:{pc.Name}\n Screen Size: {pc.ScreenSize} \n Cores: {pc.CoresCount} \n Price {pc.Price}₴");
            }
        }
    }
