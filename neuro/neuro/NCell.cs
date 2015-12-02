using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace neuro
{
    class NCell
    {
        static int id = 0; //Общий индекс
        public int _id; //Индекс нейрона
        private int _type; //0 - входной синапс, 1 - скрытый, 2 - выходной
        public List<double> _sinapses;
        /// <summary>
        /// Сохранение нейрона
        /// </summary>
        public void saveCell()
        {
            using (StreamWriter sw = new StreamWriter(@".\cells\" + _id + ".txt"))
            {
                foreach (var sin in _sinapses)
                {
                    sw.WriteLine(sin);

                }
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип нейрона</param>
        /// <param name="cntSin">Кол-во синапсов</param>
        public NCell(int type,int cntSin)
        {
            _id = id++;
            _type = type;
            _sinapses = new List<double>();
            if(_type != 0)
            {
                //Загружаем файл
                try
                {
                    string line = "";
                    using (StreamReader sr = new StreamReader(@".\cells\"+_id+".txt"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            double tmp;
                            Double.TryParse(line, out tmp);
                            _sinapses.Add(tmp);
                        }
                    }
                }
                catch
                {//Файлов нет => Сеть пустая
                    _sinapses.Clear();
                    Random rnd = new Random(_id);
                    for(var i = 0; i < cntSin; ++i)
                    {
                        _sinapses.Add(rnd.NextDouble()/10.0);
                    }
                }
            }
            else
            {//Если нейрона входного типа вес равен 1
                _sinapses.Add(1.0);
            }
        }
        /// <summary>
        /// Функция активации
        /// </summary>
        /// <param name="x">значение сумматора</param>
        /// <returns>Значение функции активации</returns>
        double funcActivation(double x)
        {
            double res = 0;
            if (_type != 0)//Используется для всех кроме входного слоя
                res = 1 / (1 + Math.Pow(Math.E, -1 * x));
            else
                res = x;
            return res;
        }
        /// <summary>
        /// Расчитывает значение нейрона для текущих сигналов
        /// </summary>
        /// <param name="signals">Список сигналов</param>
        /// <returns>значение аксона</returns>
        public double getExitSignal(List<double> signals)
        {
            double res = 0;
            int i = 0;
            if (signals.Count != _sinapses.Count)
                throw new Exception("Неверное кол-во сигналов для нейрона " + _id);
            //Суммируем значения сигнала умноженное на его значение
            foreach(var sinaps in _sinapses)
            {
                res += sinaps * signals[i++]; 
            }

            return funcActivation(res);
        }
        /// <summary>
        /// Отображает информацию о синапсах
        /// </summary>
        /// <returns>Строка</returns>
        public string getInfo()
        {
            var res = "Neuron Id = " + _id + "\n"; ;
            for(var i = 0; i < _sinapses.Count; ++i)
            {
                res += ""+i+": " + _sinapses[i]+"\n";
            }
            return res;
        }
    }
}
