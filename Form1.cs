using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaphore
{
    public partial class Form1 : Form
    {
        char inputKey;
        bool isNew;
        bool firstStart;
        CustomBuffer Buffer;

        public Form1()
        {
            InitializeComponent();
            Buffer = new CustomBuffer(5);
        }

        void ThreadsStart()
        {
            Thread producer = new(Produce);
            Thread lettersConsumer = new(ConsumeLetters);
            Thread numbersConsumer = new(ConsumeNumbers);
            Thread symbolsConsumer = new(ConsumeSymbols);

            producer.Start();
            lettersConsumer.Start();
            numbersConsumer.Start();
            symbolsConsumer.Start();
        }

        void Produce()
        {
            while (true)
                if (isNew)
                {
                    isNew = false;
                    var item = inputKey;
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
    }
}
