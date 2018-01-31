using System;
using System.Threading;
using Busylight;

namespace BusyLightTest
{
    class Program
    {
        static SDK sdk = new SDK();
        static void Main(string[] args)
        {
            int time = 10;
            int R = 100;
            int G = 0;
            int B = 0;

            while(true)
            {
                Fade(ref R, ref G, ref B, 0, 1, 0, time);
                Fade(ref R, ref G, ref B, -1, 0, 0, time);
                Fade(ref R, ref G, ref B, 0, 0, 1, time);
                Fade(ref R, ref G, ref B, 0, -1, 0, time);
                Fade(ref R, ref G, ref B, 1, 0, 0, time);
                Fade(ref R, ref G, ref B, 0, 0, -1, time);
            }
        }

        static void Fade(ref int R, ref int G, ref int B, int dR, int dG, int dB, int time)
        {
            for(int i = 0; i < 100; i++)
            {
                sdk.Light(R, G, B);
                R += dR;
                G += dG;
                B += dB;
                Thread.Sleep(time);
            }
            Console.WriteLine(String.Format("({0},{1},{2})", R, G, B));
        }
    }
}
