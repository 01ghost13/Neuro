using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neuro
{
    class NNet
    {
        public List<NCell> enterNeurons; //Слой входных нейронов
        public List<NCell> hiddenNeurons; //Скрытый слой
        public List<NCell> exitNeurons; //Слой выходных нейронов
        public List<double> afterHiddenNeurons; //Массив сигналов после прогона скрытым слоем
        /// <summary>
        /// Создает сеть с выбранной конфигурацией
        /// </summary>
        /// <param name="countOfHidden">Кол-во нейронов в спрятаном слое</param>
        /// <param name="countOfEnters">Кол-во нейронов в входном слое</param>
        /// <param name="countOfExits">Кол-во нейронов в выходном слое</param>
        public NNet(int countOfHidden, int countOfEnters, int countOfExits)
        {
            enterNeurons = new List<NCell>(countOfEnters);
            hiddenNeurons = new List<NCell>(countOfHidden);
            exitNeurons = new List<NCell>(countOfExits);
            //Заполняем массивы нейронами
            for(var i = 0; i < 3; ++i)
            {
                int length = 0;
                switch(i)
                {
                    case 0 :
                        length = countOfEnters;
                        break;
                    case 1:
                        length = countOfHidden;
                        break;
                    case 2:
                        length = countOfExits;
                        break;
                }
                for(var j = 0; j < length; j++)
                {
                    switch (i)
                    {
                        case 0:
                            enterNeurons.Add(new NCell(0, 1));
                            break;
                        case 1:
                            hiddenNeurons.Add(new NCell(1, countOfEnters));
                            break;
                        case 2:
                            exitNeurons.Add(new NCell(2, countOfHidden));
                            break;
                    }
                }
            }

        }
        /// <summary>
        /// Посылает сигнал нейронной сети
        /// </summary>
        /// <param name="signals">Набор сигналов</param>
        /// <returns>Выходной вектор НС</returns>
        public List<double> sendSignal(List<double> signals)
        {
            //Отправляем сигналы на вход
            var i = 0;
            var afterSignalNeurons = new List<double>();
            if (signals.Count != enterNeurons.Count)
                throw new Exception("Неверное кол-во сигналов для входного слоя нейроной сети");
            foreach(var neuron in enterNeurons)
            {//Добавляем вектор-сигнал на каждый вход
                var tmp = new List<double>();
                tmp.Add(signals[i++]);
                afterSignalNeurons.Add(neuron.getExitSignal(tmp));
            }
            //На скрытый слой
            afterHiddenNeurons = new List<double>();
            foreach (var neuron in hiddenNeurons)
            {
                afterHiddenNeurons.Add(neuron.getExitSignal(afterSignalNeurons));
            }
            //На выходной слой
            var res = new List<double>();
            foreach (var neuron in exitNeurons)
            {
                res.Add(neuron.getExitSignal(afterHiddenNeurons));
            }
            return res;
        }
        /// <summary>
        /// Сохраняет нейроны в текстовые файлы
        /// </summary>
        public void saveNet()
        {
            foreach(var neuron in hiddenNeurons)
            {
                neuron.saveCell();
            }
            foreach (var neuron in exitNeurons)
            {
                neuron.saveCell();
            }
        }
        /// <summary>
        /// Получить информацию о слое
        /// </summary>
        /// <param name="type">тип слоя</param>
        /// <returns>Список с информацией</returns>
        public List<string> getLayerInfo(int type)
        {
            var res = new List<string>();
            //Вытаскиваем нужный слой
            List<NCell> tmp = new List<NCell>();
            switch(type)
            {
                case 0:
                    tmp = enterNeurons;
                    break;
                case 1:
                    tmp = hiddenNeurons;
                    break;
                case 2:
                    tmp = exitNeurons;
                    break;
            }
            //Записываем данные
            foreach(var neuron in tmp)
            {
                res.Add(neuron.getInfo());
            }
            return res;
        }

    }
}
