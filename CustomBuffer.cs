using System;

namespace Semaphore
{
    public class CustomBuffer
    {
        int tail = 0;
        int head = 0;
        int size;

        public char[] Buffer { get; private set; }

        System.Threading.Semaphore empty;
        System.Threading.Semaphore full;
        System.Threading.Semaphore binary;

        public CustomBuffer(int size)
        {
            this.size = size;
            Buffer = new char[this.size];

            empty = new System.Threading.Semaphore(this.size, this.size);
            full = new System.Threading.Semaphore(0, this.size);
            binary = new System.Threading.Semaphore(1, 1);
        }

        public void Write(char item) // Producer
        {
            empty.WaitOne();
            binary.WaitOne();
            Buffer[head] = item;
            head = head++ % size;
            binary.Release();
            full.Release();
        }

        public (bool, char) Read(int id) // Consumer
        {
            bool isCharMatch = false;

            full.WaitOne();
            binary.WaitOne();

            var item = Buffer[tail];

            switch (id)
            {
                case 1:
                    isCharMatch = IsEnglishLetter(item);
                    break;
                case 2:
                    isCharMatch = Char.IsNumber(item);
                    break;
                case 3:
                    isCharMatch = !Char.IsLetter(item) && !Char.IsNumber(item);
                    break;
            }

            if (isCharMatch)
            {
                tail = tail++ % size;

                binary.Release();
                empty.Release();

                return (isCharMatch, item);
            }
            else
            {
                binary.Release();
                full.Release();
                return (isCharMatch, item);
            }
        }

        public bool IsEnglishLetter(char c)
            => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');

    }
}
