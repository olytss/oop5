using oop3.interfaces;
using oop3.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop3.services
{
    public class PcService: IPcRepository
    {
        static public void UpdatePrice()
        {
            int price = PC.pcList[1].Price;
            ChangePrice(ref price);
            PC.pcList[1].Price = price;
        }
        static public void ChangePrice(ref int price)
        {
            price = 9999999;

        }
        static public PC pcWithoutPrice(string name, string screensize, int corescount)
        {
            PC pc = new PC(name, screensize, corescount);
            return pc;
        }
        static public PC dumbPcWithNothingInIt()
        {
            PC pc = new PC();
            return pc;
        }
        static public List<PC> InitializePc()
        {
            List<PC> pcList = new List<PC>();
            PC pc1 = new PC("ASUS", "15,6'", 16, 200000, 8, "windows 7", 1);
            PC pc2 = new PC("DELL", "23,8'", 2, 10, 10, "windows 7", 2);
            PC pc3 = new PC("ASUS", "23,8'", 8, 54300, 12, "windows 7", 3);
            PC pc4 = new PC("Xiaomi", "15,6'", 1, 1, 2, "windows 7", 4);
            PC pc5 = new PC("Apple", "15,6'", 24, 52000, 500, "MacOS Monterey", 5);
            pcList.Add(pc1);
            pcList.Add(pc2);
            pcList.Add(pc3);
            pcList.Add(pc4);
            pcList.Add(pc5);

            return pcList;

        }
        public IEnumerable<PC> pcList = new List<PC>
        {



        };

         IEnumerable<PC> IPcRepository.pcList
        {
            get
            {
                return new List<PC>
                {
                    new PC("ASUS", "15,6'", 16, 200000, 8, "windows 7", 1 ),
                    new PC("DELL", "23,8'", 2, 10, 10, "windows 7", 2),
                    new PC("ASUS", "23,8'", 8, 54300, 12, "windows 7", 3),
                    new PC("Xiaomi", "15,6'", 1, 1, 2, "windows 7", 4),
                    new PC("Apple", "15,6'", 24, 52000, 500, "MacOS Monterey", 5),

                };
            }
            set;
        }
       public PC getPcById(int PCid, IEnumerable<PC> pcList, out string message)
        {
            PC foundPC = pcList.FirstOrDefault(pc => pc.PcId == PCid); //lamba func

            message = foundPC == null ? "Pc not found" : ""; // ternary operator
            return foundPC; 
        }
       
    }
}
