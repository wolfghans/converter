namespace PhysicValuesLib.Values;

public class Temperature : IValue
{
    private double Value { get; set; }
    private string? From { get; set; }
    private string? To { get; set; }

    private string _valueName = "Температура";

    private List<string> _measureList = new List<string>()
    {
        "Градусы Кельвина",
        "Градусы Цельсия",
        "Градусы Фаренгейта"
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
            case "Градусы Кельвина":
                break;
            case "Градусы Цельсия":
                Value -= 273.15;
                break;
            case "Градусы Фаренгейта":
                Value -= 255.37;
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
            case "Градусы Кельвина":
                break;
            case "Градусы Цельсия":
                Value += 273.15 ;
                break;
            case "Градусы Фаренгейта":
                Value += 255.37;
                break;
        }
    }

    public string GetValueName()
    {
        return _valueName;
    }
}
