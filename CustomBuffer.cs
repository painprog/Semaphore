using System;

namespace Semaphore
{
    public class CustomBuffer
    {
        int tail = 0;
        int head = 0;
        int size;

        public char[] Buffer { get; private set; }
        public string GetBuffer => Buffer.ToString();

        System.Threading.Semaphore empty;
        System.Threading.Semaphore full;
        System.Threading.Semaphore busy;

        public CustomBuffer(int size)
        {
            this.size = size;
            Buffer = new char[this.size];

            for (int i = 0; i < this.size; i++)
                Buffer[i] = ' ';

            empty = new System.Threading.Semaphore(this.size, this.size);
            full = new System.Threading.Semaphore(0, this.size);
            busy = new System.Threading.Semaphore(1, 1);
        }

        public void Write(char item) // Producer
        {
            empty.WaitOne();
            busy.WaitOne();
            Buffer[head] = item;
            head = head++ % size;
            busy.Release();
            full.Release();
        }

        public (bool, char) Read(int id) // Consumer
        {
            bool isCharMatch = false;

            full.WaitOne();
            busy.WaitOne();

            var item = Buffer[tail];

            switch (id)
            {
                case 1:
                    isCharMatch = Char.IsLetter(item);
                    break;
                case 2:
                    isCharMatch = Char.IsNumber(item);
                    break;
                case 3:
                    isCharMatch = Char.IsSymbol(item);
                    break;
            }

            if (isCharMatch)
            {
                tail = tail++ % size;

                busy.Release();
                empty.Release();

                return (isCharMatch, item);
            }
            else
            {
                busy.Release();
                full.Release();
                return (isCharMatch, item);
            }
        }

    }
}
