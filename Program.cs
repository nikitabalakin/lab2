using System.Diagnostics;


{
    #region Первое задание
    #region Генерация массива
    Random rng = new Random();//объявление рандома для дальнейшего использования 
    int[] mas = new int[10000];// создание массива в формате дабл, что-бы использовать дальше
    HashSet<int> known = new HashSet<int>();//Задаем ГЛОБАЛЬНЫЙ хешсет
    for (int i = 0; i < 10000; i++)//строки
    {
            int newElement;//делаем новую переменную в которой будут храниться значения
            newElement = rng.Next(10000);//заполняем его случайным элементом
            while (known.Contains(newElement))//если элемент уже есть пересоздаем его
            {
                newElement = rng.Next(10000);
            }
            known.Add(newElement);//если элемента нету добавляем его в хешсет
            mas[i] = newElement;//добавляем в массив
    }
    #endregion

    #region Сортировка пузырьком
    int[] masp = new int[mas.Length];
    mas.CopyTo(masp, 0);
    Stopwatch stopwatch = new Stopwatch();//объявления подсчета времени 
    stopwatch.Start();//начало подсчета времени
    int tempo;//использование временной переменной для сортировки
    for (int i = 0; i < masp.Length; i++)//сравнение первого элемента со вторым
    {
        for (int j = 0; j < masp.Length; j++)//второй элемент
        {
            if (masp[j] > masp[i])//если второй элемент больше первого
            {
                tempo = masp[j];
                masp[j] = masp[i];
                masp[i] = tempo;
            }
        }
    }
    stopwatch.Stop();//остановка подсчета времени
    TimeSpan tsp = stopwatch.Elapsed;//передача в переменную
    string elapsedtimep = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            tsp.Hours, tsp.Minutes, tsp.Seconds, tsp.Milliseconds);
    Console.WriteLine("Сортировка пузырьком");
    Console.WriteLine(elapsedtimep);//вывод затраченного времени
    #endregion

    #region Шейкерная сортировка
    int [] masshake = new int[mas.Length];//Создаем новый массив с прошлой длиной 
    mas.CopyTo (masshake, 0);//переносим в новый массив данные
    stopwatch.Reset();//сбрасываем время
    stopwatch.Start();//начинаем подсчет времени
    static void Swap(int[] masshake, int i, int j)//создаем функцию обмена
    {
        int temp = masshake[i];// помещаем во временную переменную
        masshake[i] = masshake[j];//меняем местами 
        masshake[j] = temp;// отдаём значение во временную переменную
    }
    int levo = 0;//задаем левый старт
    int pravo = masshake.Length - 1;//задаем правый старт
    while (levo < pravo)// если левый старт меньше правого запускаем цикл
    {
        for (int i = 0; i < pravo; i++)//пока i меньше правого старта
        {
            if (masshake[i] > masshake[i + 1])//пока i больше i+1 меняем местами
                Swap(masshake, i, i + 1);//используем функцию для обмена
        }
        pravo--;//делаем сдвиг
        for(int i = pravo; i > levo; i--)// пока i больше левого старта
        {
            if (masshake[i -1] > masshake[i])//если правый старт больше правого старта -1
            {
                Swap(masshake, i - 1, i);// то меняем их местами функцией
            }
        }
        levo++;//делаем сдвиг
    }
    stopwatch.Stop();//остановка подсчета времени
    TimeSpan tsp1 = stopwatch.Elapsed;//передача в переменную
    string elapsedtimep1 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            tsp1.Hours, tsp1.Minutes, tsp1.Seconds, tsp1.Milliseconds);
    Console.WriteLine("Сортировка перемешиванием");
    Console.WriteLine(elapsedtimep1);//вывод затраченного времени
    #endregion

    #region Сортировка расческой
    int[] masras = new int[mas.Length];//делаем новый массив
    mas.CopyTo(masras, 0);//копируем в него старый
    double dlina = masras.Length;//создаем размер массива
    bool state = true;// создаем перменную состояния
    stopwatch.Reset();//сбрасываем время
    stopwatch.Start();//начало подсчета времени
    while (dlina > 1 || state)// пока длина больше 1 или статус 1 работаем
    {
        dlina /= 1.247330950103979;// делим длину на фактор уменьшения
        if (dlina < 1) { dlina = 1; }//если длина меньше единциы, задаем её единицу
        int i = 0;//делаем переменную для дальнейшей сортировки
        state = false;//меняем статус на 0
        while (i + dlina < masras.Length)//пока i+длина меньше длина массива
        {
            int idlina = i + (int)dlina;//делаем новую переменную
            if (masras[i] > masras[idlina])//пока i больше idlina
            {
                int swap = masras[i];//временная переменная для обмена
                masras[i] = masras[idlina];//меняем местами переменные
                masras[idlina] = swap;//вовзращаем временную переменную
                state = true;//меняем статус на 1
            }
            i++;// делаем инкремент i
        }
    }
    stopwatch.Stop();//остановка подсчета времени
    TimeSpan tsp2 = stopwatch.Elapsed;//передача в переменную
    string elapsedtimep2 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            tsp2.Hours, tsp2.Minutes, tsp2.Seconds, tsp2.Milliseconds);
    Console.WriteLine("Сортировка расческой");
    Console.WriteLine(elapsedtimep2);//вывод затраченного времени
    #endregion

    #region Гномья сортировка
    int[] masgnom = new int[mas.Length];//делаем новый массив
    mas.CopyTo(masgnom, 0);//копируем в него старый
    stopwatch.Reset();//сбрасываем время
    stopwatch.Start();//начинаем запись времени
    static void Swapgnom(int[] masgnom, int i, int j)//создаем функцию обмена
    {
        int temp = masgnom[i];// помещаем во временную переменную
        masgnom[i] = masgnom[j];//меняем местами 
        masgnom[j] = temp;// отдаём значение во временную переменную
    }
    int ig = 1;//место с которого начинается цикл
    int jg = 2;//третий элемент цикла
    while (ig < masgnom.Length)// цикл действует пока первый элемент не достигнет размера массива
    {
        if (masgnom[ig - 1] < masgnom[ig])//если число в нужном месте ничего не меняем и делаем шаг вперед
        {
            ig = jg;
            jg += 1;
        }
        else
        {
            Swapgnom(masgnom, ig - 1, ig);//если число не в нужном месте используем функцию и меняем их местами
            ig -= 1;//шаг назад
            if (ig == 0)//если приходим в нулевой элемент массива едем вперёд
            {
                ig = jg;
                jg += 1;
            }
        }
    }
    stopwatch.Stop();
    TimeSpan tsp3 = stopwatch.Elapsed;//передача в переменную
    string elapsedtimep3 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            tsp3.Hours, tsp3.Minutes, tsp3.Seconds, tsp3.Milliseconds);
    Console.WriteLine("Гномья сортировка");
    Console.WriteLine(elapsedtimep3);//вывод затраченного времени
    #endregion

    #region Сортировка Шелла
    int[] masshell = new int[mas.Length];//делаем новый массив
    mas.CopyTo(masshell, 0);//копируем в него старый
    stopwatch.Reset();//сбрасываем время
    stopwatch.Start();//Начинаем запоминать время
    int jishell;// создаем переменную 
    int step = masshell.Length/2;//делаем первую область
    while (step > 0)//пока шаг больше нуля выполняем
    {
        for (int ishell = 0; ishell < (masshell.Length - step); ishell++)//запускаем цикл который действует пока шаг не дойдет до 0
        {
            jishell = ishell;//даём переменной значение нулевого индекса
            while ((jishell>= 0) && (masshell[jishell] > masshell[jishell + step]))//сравниваем два элемента на растроянии, в случае нужды меняем местами
            {
                int tmp = masshell[jishell];//даём временной переменной значение
                masshell[jishell] = masshell[jishell + step];//меняем переменную на шаг делённый на 2
                masshell[jishell + step] = tmp;//отдаем во временную переменную значение плюс шаг
                jishell -= step;//отнимаем шаг
            }
        }
        step = step / 2;// делим шаг еще на два
    }
    stopwatch.Stop();
    TimeSpan tsp4 = stopwatch.Elapsed;//передача в переменную
    string elapsedtimep4 = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            tsp4.Hours, tsp4.Minutes, tsp4.Seconds, tsp4.Milliseconds);
    Console.WriteLine("Сортировка Шелла");
    Console.WriteLine(elapsedtimep4);//вывод затраченного времени
    #endregion
    #endregion
}
