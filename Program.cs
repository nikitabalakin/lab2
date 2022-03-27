using System.Collections.Generic;
using System.Diagnostics;
#region Первое задание
/*
{
    
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
    
}
*/
#endregion

#region второе задание

namespace program//Пространство имён
{
    internal class Program//класс программы
    {
        enum Nav_state//перечисление состояний
        {
            state_base,//базовое
            state_sorted_up,//сортировка по возрастанию
            state_sorted_down,//по убыванию
            state_sorted_return,//возвращение текста
            state_sorted_work,//рабочее состояние
            state_sorted_replace,//замена
            state_sorted_count//подсчет
        }


        static void Main()//входная точка
        {
            Nav_state state = Nav_state.state_base;//задаём статус
            #region Получение строки, и ввод её в коллекцию.
            string? source_text = Console.ReadLine();//получение строки от пользователя
            while (source_text == "" || source_text == " ")//если ничего нету или там пробел просим ввести еще раз
            {
                Console.WriteLine("Текста не найдено, введите текст: ");
                source_text = Console.ReadLine();
            }
            Console.Clear();//очищаем консоль
            var not_sorted = new List<char>();//создаем коллекцию
            foreach (char str in source_text)//вводим по одному символу
            {
                not_sorted.Add(str);
            }
            #endregion

            #region Ввод в словарь и присвоение уникального индекса.
            Dictionary<int, char> dict = new();//словарь цифра буква
            int tmp_key = 0;//временные переменные для заполения
            int tmp_value = 0;
            for (int i = 0; i < not_sorted.Count; i++)//начинаем цикл по длине не сортированного листа
            {
                if (dict.ContainsValue(not_sorted[i]) == true)//если элемент уже существует
                {

                    tmp_value++;//увеличиваем значение на единицу

                }
                else//если элемента не существует
                {
                    dict.TryAdd(tmp_key, not_sorted[tmp_value]);//добавляем его в словарь
                    tmp_key++;//увеличиваем ключ на один
                    tmp_value++;//увеличиваем значение на один
                }
            }
            tmp_key = 0;//очищаем временные переменные
            tmp_value = 0;
            Dictionary<char, int> dict2 = new();//словарь буква цифра
            for (int i = 0; i < not_sorted.Count; i++)
            {
                if ((dict2.ContainsValue(not_sorted[i]) == true))//если буква уже содержится нечего не делаем
                {
                }
                else//если буквы нету добавляем её в словарь
                {
                    bool t = dict2.TryAdd(not_sorted[tmp_value], tmp_key);//если удалось добавить букву увеличиваем ключ на один
                    if (t == true)
                    {
                        tmp_key++;
                    }
                    tmp_value++;//увеличиваем значение
                }
            }

            #endregion

            #region Конвертация букв в индекс
            List<int> to_sorted = new List<int>();//лист для сортировок
            List<int> to_output = new List<int>();//лист для выводов
            for (int i = 0; i < not_sorted.Count; i++)//заполняем сортировочный лист
            {
                int value;
                dict2.TryGetValue(not_sorted[i], out value);//ловим значение из второго словаря
                to_sorted.Add(value);//добавляем его
            }
            #endregion

            while (true)//вечный цикл для меню 
            {
                switch (state)//говорим свичу ориентироваться на наш стейт
                {

                    case Nav_state.state_base://при базовом состоянии
                        Console.Clear();//очищаем консоль
                        Console.WriteLine($"Оригинал: {source_text}");//выводим оригинал
                        #region Конвертация индекса в буквы и его вывод
                        Console.Write("Текущее состояние: ");
                        to_output.Clear();//очищаем лист для вывода
                        for (int i = 0; i < to_sorted.Count; i++)//заполняем лист для вывода на основе, первого словаря.
                        {
                            char value;
                            dict.TryGetValue(to_sorted[i], out value);
                            to_output.Add(value);
                        }
                        foreach (char c in to_output)//выводим лист для вывода
                        {
                            Console.Write(c);
                        }
                        #endregion
                        Console.WriteLine("");
                        Console.WriteLine("Выберете нужную операцию.");
                        Console.WriteLine("1. Сортировка по возрастанию.");
                        Console.WriteLine("2. Сортировка по убыванию.");
                        Console.WriteLine("3. Подсчет количества символов в тексте");
                        Console.WriteLine("4. Заменя символов в тексте");
                        Console.WriteLine("5. Возвращение оригинального текста.");
                        var vibor = Console.ReadLine();//вводим для меню
                        if (vibor == "1") { state = Nav_state.state_sorted_up; }//на основе введдёного меняем состояние
                        else if (vibor == "2") { state = Nav_state.state_sorted_down; }
                        else if (vibor == "5") { state = Nav_state.state_sorted_return; }
                        else if (vibor == "4") { state = Nav_state.state_sorted_replace; }
                        else if (vibor == "3") { state = Nav_state.state_sorted_count; }
                        else { Console.WriteLine("Неверное значение, допустимы только 1,2,3,4"); }
                        break;//выходим отсюдаво
                        
                    case Nav_state.state_sorted_up://при сортировке на возрастание
                        Console.WriteLine("Сортировка по возрастанию");
                        to_sorted.Sort();//сортируем индексы
                        state = Nav_state.state_base;//меняем стейт на базовый
                        break;

                    case Nav_state.state_sorted_down://при сортировке на убывание
                        Console.WriteLine("Сортировка по Убыванию");
                        to_sorted.Sort();//сортируем индексы 
                        to_sorted.Reverse();//инвертируем
                        state = Nav_state.state_base;//меняем стейт на базовый
                        break;

                    case Nav_state.state_sorted_count://подсчет общего количества символов
                        Dictionary<char, int> result = new Dictionary<char, int>();//словарь для посчета кол-ва символов
                        for (int i = 0; i < not_sorted.Count; i++)
                        {
                            try//если работает вносим его
                            {
                                result[not_sorted[i]]++;
                            }
                            catch (KeyNotFoundException)//если ловим исключение добавляем единицу существующему значению
                            {
                                result.Add(not_sorted[i], 1);
                            }
                        }
                        foreach(var i in result)//выводим
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine($"Общее количество символов в тексте: {not_sorted.Count}");
                        Console.ReadLine();
                        state = Nav_state.state_base;//меняем стейт на базовый
                        break;

                    case Nav_state.state_sorted_replace://замена символов в тексте
                        char what;//что нужно менять
                        char to;// на что нужно изменить
                        Console.WriteLine("Введите какой символ нужно изменить");
                        what = Convert.ToChar(Console.ReadLine());
                        int what1; dict2.TryGetValue(what, out what1);//ловим индекс буквы
                        Console.WriteLine("Введите на какой символ нужно изменить");
                        to = Convert.ToChar(Console.ReadLine());
                        int to1; dict2.TryGetValue(to, out to1);//ловим индекс буквы
                        int count = 0;//счетчик
                        for (int i = 0; i < to_sorted.Count; i++)
                        {
                            int tmp = to_sorted[i];//проходимся по всему списку
                            if (tmp == what1)//увеличиваем счетчик на один если ловим истину
                            {
                                count++;
                            }
                        }
                        dict.Remove(what1);//удаляем в словаре цифра буква, индекс
                        dict.Add(what1, to);//вносим новый индекс и букву
                        dict2.Remove(what);//удаляем в словаре буква цифра, букву
                        dict2.Add(to, to1);//вносим новую букву и индекс
                        Console.WriteLine($"Было заменено: {count}");//выводим количество заменённых букв
                        Console.ReadLine();
                        state = Nav_state.state_base;//меняем стейт на базовый
                        break;

                    case Nav_state.state_sorted_return://возвращение оригинала
                        Console.WriteLine("Возврат оригинального текста");
                        to_sorted.Clear();//чистим массив для сортировки
                        dict.Clear();// чистим словари
                        dict2.Clear();
                        //Записываем словари заново.
                        #region Востановление словарей
                        tmp_key = 0;
                        tmp_value = 0;
                        for (int i = 0; i < not_sorted.Count; i++)//начинаем цикл по длине не сортированного листа
                        {
                            if (dict.ContainsValue(not_sorted[i]) == true)//если элемент уже существует
                            {

                                tmp_value++;//увеличиваем значение на единицу

                            }
                            else//если элемента не существует
                            {
                                dict.TryAdd(tmp_key, not_sorted[tmp_value]);//добавляем его в словарь
                                tmp_key++;//увеличиваем ключ на один
                                tmp_value++;//увеличиваем значение на один
                            }
                        }
                        tmp_key = 0;//обнулем временные переменные
                        tmp_value = 0;
                        for (int i = 0; i < not_sorted.Count; i++)
                        {
                            if ((dict2.ContainsValue(not_sorted[i]) == true))//при существовании ничего не делаем
                            {
                            }
                            else
                            {
                                bool t = dict2.TryAdd(not_sorted[tmp_value], tmp_key);//если удалось добавить
                                if (t == true)
                                {
                                    tmp_key++;//увеличиваем ключ на один
                                }
                                tmp_value++;// еще увечиваем ключ
                            }
                        }
                        #endregion
                        for (int i = 0; i < not_sorted.Count; i++)//создаем заново массив.
                        {
                            int value;
                            dict2.TryGetValue(not_sorted[i], out value);
                            to_sorted.Add(value);
                        }
                        state = Nav_state.state_base;//возврат к базовому стейту
                        break;
                }
            }
        }
    }
}

#endregion



