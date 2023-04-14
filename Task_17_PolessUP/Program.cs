using System.Security.Cryptography;

string text = "a1b2c3";
Console.WriteLine("Ввод: " + text);
string[] group = RegisterGroup(text);
Console.WriteLine("Вывод: " + PrintArray(group));

Console.ReadLine();

string PrintArray(string[] group)
{
    string buffer = "";
    buffer += "[";
    for (int i = 0; i < group.Length - 1; i++)
    {
       buffer += $"\"{group[i]}\" ";
    }
    buffer += $"\"{group[^1]}\"]";
    return buffer;
}

string[] RegisterGroup(string text)
{
    List<string> group = new List<string>();
    text.ToLower();
    string[] textmass = new string[text.Length];
    for (int i = 0; i < textmass.Length; i++)
    {
        textmass[i] = Convert.ToString(text[i]);
    }

    bool check = true;
    int x = 0;
    while (check)
    {
        string binary = Convert.ToString(x, 2);
        x++;
        BinaryCompletion(ref binary, textmass);

        for (int index = 0; index < textmass.Length; index++)
        {
            if (binary[index] == '1')
                textmass[index] = textmass[index].ToUpper();

            else if (binary[index] == '0')
                textmass[index] = textmass[index].ToLower();
        }

        MassToString(textmass, out string newtext);
        group.Add(newtext);
        check = CheckOneCount(binary, textmass);
    }
        
    return group.ToArray().Distinct().ToArray();
}

void BinaryCompletion(ref string binary, string[] textmass)
{
    int binarycount = binary.Length;
    int textmasscount = textmass.Length;
    while (binarycount < textmasscount)
    {
        string temp = binary;
        binary = "0" + temp;
        binarycount++;
    }
}

void MassToString(string[] textmass, out string newtext)
{
    newtext = "";
    for (int i = 0; i < textmass.Length; i++)
    {
        newtext += textmass[i];
    }
}

bool CheckOneCount(string binary, string[] textmass)
{
    int onecount = 0;
    for (int i = 0; i < binary.Length; i++)
    {
        if (binary[i] == '1')
        {
            onecount++;
        }
    }
    if (onecount == textmass.Length)
    {
        return false;
    }
    return true;
}

