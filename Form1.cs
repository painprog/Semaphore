using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Semaphore
{
    public partial class Form1 : Form
    {
        char inputChar;
        bool isNew;
        bool isFirstStart;
        CustomBuffer Buffer;

        public Form1()
        {
            InitializeComponent();
            Buffer = new CustomBuffer(5);
        }

        void ThreadsStart()
        {
            new List<Thread>
            {
                new(Produce),
                new(ConsumeLetters),
                new(ConsumeNumbers),
                new(ConsumeSymbols)
            }
            .ForEach(x => x.Start());
        }

        void Produce()
        {
            while (true)
                if (isNew)
                {
                    isNew = false;
                    var item = inputChar;
                    if (!char.IsControl(item))
                        Buffer.Write(item);
                }
        }

        void Consume(int id, RichTextBox textBox)
        {
            while (true)
            {
                var result = Buffer.Read(id);
                if (result.Item1)
                    Invoke(new Action(() => textBox.Text += result.Item2));
            }
        }

        void ConsumeLetters()
        {
            Consume(1, englishLetters);
        }

        void ConsumeNumbers()
        {
            Consume(2, numbers);
        }

        void ConsumeSymbols()
        {
            Consume(3, symbols);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isFirstStart = true;
        }

        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            inputChar = key;
            isNew = true;

            if (isFirstStart)
            {
                isFirstStart = false;
                ThreadsStart();
            }
        }
    }
}
