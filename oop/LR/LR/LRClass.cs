using System;
using System.IO;

namespace LR
{
    class LRClass
    {
        private int[] data;
        private int[] L, R;
        private string filename;

        public LRClass(string filename)
        {
            this.filename = filename;
        }

        public void ShowResults()
        {
            for (int i = 1; i < data.Length - 1; i++)
                if (data[i] == L[i] && L[i] == R[i])
                    Console.WriteLine(data[i]);
        }

        public void ProcessData()
        {
            L = new int[data.Length];
            R = new int[data.Length];

            int maxim = data[0];

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > maxim)
                    maxim = data[i];

                L[i] = maxim;
            }

            int minim = data[data.Length - 1];

            for (int j = data.Length - 1; j >= 0; j--)
            {
                if (data[j] < minim)
                    minim = data[j];

                R[j] = minim;
            }
        }

        public void ReadData()
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                string[] tokens;
                char[] seps = { ' ', ',', ';' };

                line = sr.ReadLine();
                tokens = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);

                data = new int[tokens.Length];

                int i = 0;

                foreach (var item in tokens)
                    data[i++] = int.Parse(item);
            }
        }
    }
}
