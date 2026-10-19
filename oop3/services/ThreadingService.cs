using System.Threading;

namespace oop3.services
{
    internal class ThreadingService
    {
   
        public static volatile int currentOptionIndex = 0;
        public static volatile bool IsRunning = true;

        public static Thread OptionThread = new Thread(() =>
        {
            while (IsRunning)
            {
                ConsoleControlsService.CurrentOption(
                    ConsoleControlsService.options,
                    currentOptionIndex,
                    ConsoleControlsService.prefix
                );

                
                Thread.Sleep(50);
            }
        })
        {
            IsBackground = true 
        };
    }
}