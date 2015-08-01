using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tibia_Bot_Project
{
    class KeyboardSimulator
    {
        private const uint WM_KEYDOWN = 0x100;
        private const uint WM_KEYUP = 0x101;
        private uint MANA_HK;
        private uint LHEAL_HK;
        private uint IHEAL_HK;

        private IntPtr handle;

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        public KeyboardSimulator(uint MANA_HK, uint LHEAL_HK, uint IHEAL_HK) {

            this.MANA_HK = MANA_HK;
            this.LHEAL_HK = LHEAL_HK;
            this.IHEAL_HK = IHEAL_HK;

            Console.WriteLine("Mana hotkey is: " + MANA_HK);

            Process tibia = Process.GetProcessesByName("Tibia").FirstOrDefault();
            handle = tibia.MainWindowHandle;


            if (tibia == null)
            {
                Console.WriteLine("Could not find a Tibia client!");
                return;
            }            
        }

        public void useLightHeal()
        {
            PostMessage(handle, WM_KEYDOWN, ((IntPtr)LHEAL_HK), (IntPtr)0);
            PostMessage(handle, WM_KEYUP, ((IntPtr)LHEAL_HK), (IntPtr)0);  
        }
        public void useManaPotion()
        {
            PostMessage(handle, WM_KEYDOWN, ((IntPtr)MANA_HK), (IntPtr)0);
            PostMessage(handle, WM_KEYUP, ((IntPtr)MANA_HK), (IntPtr)0);  
        }
        public void useIntenseHeal()
        {
            PostMessage(handle, WM_KEYDOWN, ((IntPtr)IHEAL_HK), (IntPtr)0);
            PostMessage(handle, WM_KEYUP, ((IntPtr)IHEAL_HK), (IntPtr)0);  
        }
    }
}
