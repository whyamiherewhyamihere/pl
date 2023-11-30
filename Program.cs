int n = 5;
float[] array = new float[n];
Random random = new Random();
for (int i = 0; i < n; i++) // Заполним массив случайными числами
{
    array[i] = (float)(random.NextDouble() * 5 - 2.5);
}

Console.WriteLine(string.Join(", ", array));

float sumOdd = 0;
for (int i = 0; i < n; i += 2) // Посчитаем сумму нечетных элементов
{
    sumOdd += array[i];
}

Console.WriteLine("Сумма нечетных: " + sumOdd);

int indexFirstNegative = -1;
for (int i = 0; i < n; i++) // Найдем индекс первого отрицательного
{
    if (array[i] < 0)
    {
        indexFirstNegative = i;
        break;
    }
}

int indexLastNegative = -1;
for(int i = n - 1; i >= 0; i--) // Найдем индекс последнего отрицательного
{
    if (array[i] < 0)
    {
        indexLastNegative = i;
        break;
    }
}
float sumBetween = 0;

for(int i = indexFirstNegative + 1; i < indexLastNegative; i++)
{
    sumBetween += array[i];
}

Console.WriteLine("Сумма чисел между первым и последним отрицательным элементом: " + sumBetween);

int j = 0;
for(int i = 0; i<n; i++)
{
    if (Math.Abs(array[i]) <= 1)
    {
        array[j] = array[i];
        j++;
    }
}
for(; j < n; j++)
{
    array[j] = 0;
}

Console.WriteLine("Массив после сжатия: " + string.Join(", ", array));