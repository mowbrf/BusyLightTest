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
            IntMatrix progressionMatrix = new IntMatrix(new int[][]{
                new int[]{   0, -1,  0 },
                new int[]{   0,  0, -1 },
                new int[]{  -1,  0,  0 }
            });

            IntMatrix deltaVector = new IntMatrix(new int[][]{
                new int[]{  0 },
                new int[]{  1 },
                new int[]{  0 }
            });

            int time = 10;
            int R = 100;
            int G = 0;
            int B = 0;

            while(true)
            {
                Console.WriteLine(String.Format("delta: ({0}, {1}, {2})", deltaVector.ElementAt(0, 0), deltaVector.ElementAt(1, 0), deltaVector.ElementAt(2, 0)));
                Fade(ref R, ref G, ref B, deltaVector.ElementAt(0,0), deltaVector.ElementAt(1,0), deltaVector.ElementAt(2,0), time);
                deltaVector = progressionMatrix * deltaVector;
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
            Console.WriteLine(String.Format("RGB: ({0},{1},{2})", R, G, B));
        }
    }
}
