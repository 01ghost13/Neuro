using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neuro
{
    public partial class Result : Form
    {
        //Конструктор вывода результата
        public Result(Bitmap img,List<double> signal)
        {
            InitializeComponent();
            lblImg.Image = img; //Выставляем картинку-значение
            var max = double.NegativeInfinity;
            int maxIndex = 0;
            //Находим максимальное значение в сигнале
            for(var i = 0; i < signal.Count; ++i)
            {
                if(signal[i] > max)
                {
                    max = signal[i];
                    maxIndex = i;
                }
            }
            tbResult.Value = maxIndex;
        }
    }
}
