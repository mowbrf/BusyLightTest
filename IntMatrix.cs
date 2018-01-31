using System;

namespace BusyLightTest
{
    internal struct IntMatrix
    {
        int [][] m; 
        public IntMatrix(int[][] m)
        {
            this.m = m;
        }

        public int ElementAt(int i, int j)
        {
            return m[i][j];
        }

        /// <summary>
        /// Matrix multiply; no checks on sizes!
        /// </summary>
        public static IntMatrix operator *(IntMatrix m1, IntMatrix m2)
        {
            int[][] result = new int[m1.m.Length][];
            for (var i = 0; i < m1.m.Length; i++)
                result[i] = new int[m2.m[0].Length];

            for (int j = 0; j < m1.m.Length; j++)
            {
                for (int k = 0; k < m2.m[0].Length; k++)
                {
                    int acc = 0;
                    for (int i = 0; i < m1.m[0].Length; i++)
                    {
                        acc += m1.m[j][i] * m2.m[i][k];
                    }
                    result[j][k] = acc;
                }
            }

            return new IntMatrix(result);
        }

        void test()
        {
            IntMatrix v = new IntMatrix(new int[][]{
                new int[]{  1,  2, 3}
            });

            IntMatrix w = new IntMatrix(new int[][]{
                new int[]{  1 },
                new int[]{  1 },
                new int[]{  1 }
            });

            var r = v * w;
            Console.WriteLine(String.Format("({0})", r.ElementAt(0, 0)));

            IntMatrix m = new IntMatrix(new int[][]{
                new int[]{   0,  0, -1 },
                new int[]{  -1,  0,  0 },
                new int[]{   0, -1,  0 }
            });

            IntMatrix s = new IntMatrix(new int[][]{
                new int[]{  1 },
                new int[]{  0 },
                new int[]{  0 }
            });

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(String.Format("({0}, {1}, {2})", s.ElementAt(0, 0), s.ElementAt(1, 0), s.ElementAt(2, 0)));
                s = m * s;
            }

            Console.ReadLine();
        }
    }
}