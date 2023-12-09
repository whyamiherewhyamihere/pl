int n = 5;
int[,] matrix = new int[n, n];
Random random = new Random();
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    { 
        matrix[i, j] = random.Next(-7, 7);
    }
}

for(int row = 0; row < n; row++)
{
    for (int col = 0; col < n; col++)
    {
        Console.Write(String.Format("{0,3}", matrix[row, col]));
    }
    Console.WriteLine();
}

for (int row = 0; row < n; row++)
{
    bool foundNegative = false;
    int mul = 1;
    for (int col = 0; col < n; col++)
    {
        mul *= matrix[row, col];
        if (matrix[row, col] < 0)
        {
            foundNegative = true;
            break;
        }
    }
    if (foundNegative)
    {
        continue;
    }
    Console.WriteLine("Произведение строки " + row + " = " + mul);
}

int? maxSum = null;
for(int row = 0; row < n; row++)
{
    int diagSum = 0;
    for(int col = 0; col < n - row; col++)
    {
        diagSum += matrix[row + col, col];
    }
    if (maxSum == null || diagSum > maxSum)
    {
        maxSum = diagSum;
    }
}
for(int col = 0; col < n; col++)
{
    int diagSum = 0;
    for(int row = 0; row < n - col; row++)
    {
        diagSum += matrix[row, col + row];
    }
    if (maxSum == null || diagSum > maxSum)
    {
        maxSum = diagSum;
    }
}
Console.WriteLine("Максимальная диагональ: " + maxSum); 