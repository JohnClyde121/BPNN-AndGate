using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backprop;


namespace Solution_BPNN
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, 2, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[][] inputs = new double[][]
            {
        new double[] {0,0,0,0},
        new double[] {0,0,0,1},
        new double[] {0,0,1,0},
        new double[] {0,0,1,1},
        new double[] {0,1,0,0},
        new double[] {0,1,0,1},
        new double[] {0,1,1,0},
        new double[] {0,1,1,1},
        new double[] {1,0,0,0},
        new double[] {1,0,0,1},
        new double[] {1,0,1,0},
        new double[] {1,0,1,1},
        new double[] {1,1,0,0},
        new double[] {1,1,0,1},
        new double[] {1,1,1,0},
        new double[] {1,1,1,1}
            };

            double[] outputs = new double[]
            {
        0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1
            };

            int epochs = 500; // start with 500 epochs, you can adjust

            for (int a = 0; a < epochs; a++)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 4; j++)
                        nn.setInputs(j, inputs[i][j]);

                    nn.setDesiredOutput(0, outputs[i]);
                    nn.learn();
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            double[] inputValues = new double[4];
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };

            for (int i = 0; i < 4; i++)
            {
                if (!double.TryParse(boxes[i].Text, out inputValues[i]))
                {
                    MessageBox.Show($"Please enter a valid number for input {i + 1}");
                    return;
                }
                nn.setInputs(i, inputValues[i]);
            }

            nn.run();
            textBox5.Text = nn.getOuputData(0).ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

    }
}
