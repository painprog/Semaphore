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

        void Consume(ConsumeType consumeType, RichTextBox textBox)
        {
            while (true)
            {
                var result = Buffer.Read(consumeType);
                if (result.Item1)
                    Invoke(new Action(() => textBox.Text += result.Item2));
            }
        }

        void ConsumeLetters()
        {
            Consume(ConsumeType.EnglishLetters, englishLetters);
        }

        void ConsumeNumbers()
        {
            Consume(ConsumeType.Numbers, numbers);
        }

        void ConsumeSymbols()
        {
            Consume(ConsumeType.Symbols, symbols);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadsStart();
        }

        private void input_KeyPress(object sender, KeyPressEventArgs e)
        {
            inputChar = e.KeyChar;
            isNew = true;
        }
    }
}
