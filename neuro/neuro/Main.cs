using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace neuro
{
    public partial class Main : Form
    {
        NNet _layerNet;//Сеть
        Bitmap curImg;//Картинка с цифрой
        public Main()
        {
            InitializeComponent();
            //Создание сети
            _layerNet = new NNet(31, 900, 10);
            //Загрузка картинок
            FileInfo[] cDirs = new DirectoryInfo(@".\nums").GetFiles();
            foreach(var img in cDirs)
            {
                lbPics.Items.Add(img.Name);
            }
        }

        //Отображает таблицу нейронов выбраного слоя
        private void showNeurons(object sender, EventArgs e)
        {
            lbSinapses.Clear();
            var strings = new List<string>();
            if(rbEnter.Checked)
            {//Выбраны входные нейроны
                strings = _layerNet.getLayerInfo(0);
            }
            else if(rbHidden.Checked)
            {//Выбраны скрытые нейроны
                strings = _layerNet.getLayerInfo(1);
            }
            else if(rbExit.Checked)
            {//Выбраны выходные нейроны
                strings = _layerNet.getLayerInfo(2);
            }
            for (var i = 0; i < strings.Count; ++i)
            {
                lbSinapses.Items.Add(strings[i]);
            }
        }

        //Переключает картинки
        private void lbPics_SelectedIndexChanged(object sender, EventArgs e)
        {
            curImg = new Bitmap(@".\nums\" + (string)lbPics.Items[lbPics.SelectedIndex]);
            lblPicture.Image = curImg;
        }

        //Передает сети сигнал на обработку
        private void btnParse_Click(object sender, EventArgs e)
        {
            //Создаем вектор сигналов
            var signal = convertToSignal(curImg);
            var result = _layerNet.sendSignal(signal);
            var resWindow = new Result(curImg, result);
            resWindow.Show();
        }
        /// <summary>
        /// Обучает нейронную сеть по выборке в папке nums
        /// </summary>
        private void learn(object sender, EventArgs e)
        {

            double nu = 0.9, Emax = 0.05, Ecur = double.PositiveInfinity;
            while(Emax < Ecur)
            {
                Ecur = 0D;
                for(var k = 0; k < lbPics.Items.Count; k++)
                { 
                    //Вводится очередная обучающая пара
                    var signal = convertToSignal(new Bitmap(@".\nums\" + (string)lbPics.Items[k]));
                    var signalVector = Vector<double>.Build.Dense(signal.ToArray());
                    //Вычисляем результат сети:
                    var resultSignal = _layerNet.sendSignal(signal);

                    //Вычлиняем результирующее значение
                    int category;
                    if (!Int32.TryParse( Regex.Match((string)lbPics.Items[k], @"(?<=_)\d").Value, out category ))
                        throw new Exception("Ошибка парсинга результата");

                    //Переводим в сигнал
                    var trueSignal = new List<double>();
                    for(var i = 0; i < resultSignal.Count; ++i)
                    {
                        if (i == category)
                            trueSignal.Add(1.0);
                        else
                            trueSignal.Add(0.0);
                    }
                    //Проводим корректировку для каждого выхода
                    var o = Vector<double>.Build.Dense(_layerNet.afterHiddenNeurons.ToArray());//Вектор выходов нейронов после скр. слоя.
                    for (var i = 0; i < resultSignal.Count; ++i)
                    {
                        var W = Vector<double>.Build.Dense(_layerNet.exitNeurons[i]._sinapses.ToArray());//Вектор весов вых-ого нейрона i
                        var delta = (trueSignal[i] - resultSignal[i]) * resultSignal[i] * (1.0 - resultSignal[i]); //дельта-приближение
                        //Корректировка весов выходного слоя
                        W += nu * delta * o;
                        _layerNet.exitNeurons[i]._sinapses = W.ToList();
                        //корректировка весов скрытого слоя
                        for (var j = 0; j < _layerNet.hiddenNeurons.Count; ++j)
                        {
                            var w = Vector<double>.Build.Dense(_layerNet.hiddenNeurons[j]._sinapses.ToArray()); //массив весов j-го нейрона i-го входа
                            w += nu * delta * W[j] * o[j] * (1 - o[j]) * signalVector;
                            _layerNet.hiddenNeurons[j]._sinapses = w.ToList();
                        }
                    }
                    //Наращение ошибки
                    var errTmp = 0D;
                    for(var i = 0; i < trueSignal.Count; ++i)
                    {
                        errTmp += Math.Pow(trueSignal[i] - resultSignal[i], 2.0);
                    }
                    Ecur += 0.5 * errTmp;
                }
            }
        }
        /// <summary>
        /// Конвертирует картинку в сигнал
        /// </summary>
        /// <param name="img">Картинка</param>
        /// <returns>Сигнал этой картинки</returns>
        List<double> convertToSignal(Bitmap img)
        {
            var signal = new List<double>();
            for (var i = 0; i < img.Height; ++i)
            {
                for (var j = 0; j < img.Width; ++j)
                {
                    var clr = img.GetPixel(i, j);
                    signal.Add((765.0 - clr.R - clr.G - clr.B) / 765.0);
                }
            }
            return signal;
        }

        //Сохранение сети
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Сохраняем сеть
            _layerNet.saveNet();
        }
        
        //Отображение значений синапсов
        private void lbSinapses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSinapses.SelectedItems.Count != 0)
                rtbSinapses.Text = "" + lbSinapses.SelectedItems[0].Text;
        }
        
        //Обновление папки с картинками
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lbPics.Items.Clear();
            FileInfo[] cDirs = new DirectoryInfo(@".\nums").GetFiles();
            foreach (var img in cDirs)
            {
                lbPics.Items.Add(img.Name);
            }
        }
    }
}
