using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_convolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter X(n):\n");
            string input = Console.ReadLine();
            string[] _x = input.Split(',');
            int[] x = new int[_x.Length];
            for (int i = 0; i < _x.Length; i++)
            {
                Int32.TryParse(_x[i],out x[i]);
            }

            Console.WriteLine("\n\nEnter H(n):\n");
            string manipulater = Console.ReadLine();
            string[] _h = manipulater.Split(',');
            int[] h = new int[_h.Length];
            for (int i = 0; i < _h.Length; i++)
            {
                Int32.TryParse(_h[i], out h[i]);
            }

            int[] y = convolute(x, h);

            Console.WriteLine("\nSum of Y element: {0}", y.Sum());
            Console.Read();
        }

        public static int[] convolute(int[] x, int[] h)
        {
            int[] y = new int[x.Length + h.Length - 1];
            
            int[] negH = h.Reverse().ToArray();
            Console.Write("\n-H(n) = ");
            Console.WriteLine("[{0}]", string.Join(", ", negH));

            for (int i = 0; i < x.Length + h.Length - 1; i++)
            {
                int k = i;
                for (int j = h.Length - 1; j >= 0; j--)
                {
                    if (k >= 0 && k < x.Length)
                    {
                        y[i] += x[k] * negH[j];
                    }
                    k--;
                }
            }

            Console.Write("\n\nY(n) = ");
            Console.WriteLine("[{0}]", string.Join(", ", y));
            return y;
        }
    }
}
