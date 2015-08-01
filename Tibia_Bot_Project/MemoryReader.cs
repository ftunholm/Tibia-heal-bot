using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading.Tasks;
using System.Timers;


namespace Tibia_Bot_Project
{
    class MemoryReader
    {
        private Timer timer;
        private LogiXBot lb;
        private KeyboardSimulator keyboardSimulator;  
        private const int PROCESS_WM_READ = 0x0010;

        private Int32 baseAddress;

        private int currentHp;
        private int maxHp;
        private int currentMana;
        private int maxMana;
        private int xor;

        private int maxHpValue;
        private int maxManaValue;
        private int manaValue;
        private int hpValue;

        private Int32 currentHpAddr = 0x6D2030;
        private Int32 maxHpAddr = 0x6D2024;
        private Int32 currentManaAddr = 0x5346A8;
        private Int32 maxManaAddr = 0x53467C;
        private Int32 xorAddr = 0x534678;

        private double manaPercentInput;
        private double hpPercentLightHealInput;
        private double hpPercentIntenseHealInput;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess,
          int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        public MemoryReader(KeyboardSimulator keyboardSimulator, LogiXBot lb, double manaPercentInput, double hpPercentLightHealInput, double hpPercentIntenseHealInput)
        {
            this.lb = lb;
            this.manaPercentInput = manaPercentInput;
            this.hpPercentLightHealInput = hpPercentLightHealInput;
            this.hpPercentIntenseHealInput = hpPercentIntenseHealInput;

            timer = new Timer();
            timer.Interval = 300;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
            timer.Start();
            this.keyboardSimulator = keyboardSimulator;

            readValuesFromMemory();
        }

        private void readValuesFromMemory()
        {
            Process tibia = Process.GetProcessesByName("Tibia").FirstOrDefault();
            baseAddress = tibia.MainModule.BaseAddress.ToInt32();
            IntPtr handle = OpenProcess(PROCESS_WM_READ, false, tibia.Id);

            int bytesRead = 0;
            byte[] buffer = new byte[4];


            ReadProcessMemory((int)handle, xorAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            xor = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, currentHpAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            currentHp = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, currentManaAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            currentMana = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, maxHpAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            maxHp = BitConverter.ToInt32(buffer, 0);

            ReadProcessMemory((int)handle, maxManaAddr + baseAddress, buffer, buffer.Length, ref bytesRead);
            maxMana = BitConverter.ToInt32(buffer, 0);

            hpValue = currentHp ^ xor;
            manaValue = currentMana ^ xor;
            maxHpValue = maxHp ^ xor;
            maxManaValue = maxMana ^ xor;

            bool isExhausted = false;

            if (((double)(int)manaValue / (int)maxManaValue) < manaPercentInput)
            {
                keyboardSimulator.useManaPotion();
                isExhausted = true;
            }
            if (((double)(int)hpValue / (int)maxHpValue) < hpPercentIntenseHealInput)
            {
                keyboardSimulator.useIntenseHeal();
                isExhausted = true;
            }
            if (((double)(int)hpValue / (int)maxHpValue) < hpPercentLightHealInput)
            {
                keyboardSimulator.useLightHeal();
                isExhausted = true;
            }
            if (isExhausted)
            {
                System.Threading.Thread.Sleep(800);
            }

        }

        private void TimerTick(object sender, EventArgs e)
        {
            readValuesFromMemory();
            updateStats();
        }

        private void updateStats()
        {

            if (lb.InvokeRequired)
            {
                lb.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() {
                    lb.setManaText("Mana: " + manaValue + "/" + maxManaValue);
                    lb.setHpText("Hp: " + hpValue + "/" + maxHpValue); ;
                });
            }
            else
            {
                lb.setManaText("Mana: " + manaValue + "/" + maxManaValue);
                lb.setHpText("Hp: " + hpValue + "/" + maxHpValue); ;                
            }
        }

    }
}
