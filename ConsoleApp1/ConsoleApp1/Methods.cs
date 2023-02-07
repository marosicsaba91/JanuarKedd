
double a = Math.Pow(2,6);   // Hatvány
double aa = Math.Sqrt(9);   // Négyzetgyök

float number = 12.544f;
float b = Math.Abs(number); // Abszolut érték
float c = Math.Sign(number);   // Előjel függvény

float d = Math.Max(7, 4); // A nagyobbik
float e = Math.Min(7, 4); // A kisebbik

double f = Math.Ceiling(45.045);  // Plafon
double g = Math.Floor(467.75);    // Padló
double h = Math.Round(33.6);      // Kerekítés


// ----------------------------------------

float a1 = Abs(-13.5f);
float a2 = Sign(-44);

MyMethod(10);
MyMethod(15);
MyMethod(6);

// ----------------------------------------

float Abs(float num)
{
    if (num < 0)
    {
        num = -num;
    }

    return num;
}

float Max(float a, float b)
{
    float result;

    if (a < b)
    {
        result = b;
    }
    else
    {
        result = a;
    }

    return result;
}

float Sign(float num) 
{
    if (num < 0)
    {
        return -1;
    }

    return 1;
}

// Method
void MyMethod(int n) 
{
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine(i);
    }
}