namespace PhysicValuesLib.Values;

public class Weight : IValue
{
    private double Value { get; set; }
    private string? From { get; set; }
    private string? To { get; set; }

    private string _valueName = "Вес";

    private List<string> _measureList = new List<string>()
    {
        "Граммы",
        "Килограммы",
        "Тонны",
        "Милиграммы"
    };

    /// <summary>
    /// Метод возвращает конвертированное значение
    /// </summary>
    /// <returns></returns>
    public double GetConvertedValue(double value, string from, string to)
    {
        Value = value;
        From = from;
        To = to;

        ToSi();
        ToRequired();
        return Value;
    }

    /// <summary>
    /// Метод возвращает список единиц измерения
    /// </summary>
    /// <returns></returns>
    public List<string> GetMeasureList()
    {
        return _measureList;
    }

    /// <summary>
    /// Метод конвертирует в нужные единицы измерения
    /// </summary>
    public void ToRequired()
    {
        switch (To)
        {
            case "Киллограммы":
                break;
            case "Граммы":
                Value *= 1000;
                break;
            case "Тонны":
                Value /= 1000;
                break;
            case "Милиграммы":
                Value *= 1000000;
                break;
        }
    }

    /// <summary>
    /// Метод переводит в систему СИ
    /// </summary>
    public void ToSi()
    {
        switch (From)
        {
            case "Киллограммы":
                break;
            case "Граммы":
                Value /= 1000;
                break;
            case "Тонны":
                Value *= 1000;
                break;
            case "Милиграммы":
                Value /= 1000000;
                break;
        }
    }

    public string GetValueName()
    {
        return _valueName;
    }
}
