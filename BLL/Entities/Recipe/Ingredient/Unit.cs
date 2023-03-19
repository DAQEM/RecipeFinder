namespace BLL.Entities.Recipe.Ingredient;

public enum Unit
{
    Milliliter = 0,
    Deciliter = 1,
    Liter = 2,
    Milligram = 3,
    Gram = 4,
    Kilogram = 5,
    Teaspoon = 6,
    Tablespoon = 7,
    FluidOunce = 8,
    Cup = 9,
    Pint = 10,
    Quart = 11,
    Gallon = 12,
    Pound = 13,
    Ounce = 14,
    Pinch = 15
}

public static class UnitExtensions
{
    public static string GetUnitAbbreviation(Unit unit)
    {
        return unit switch
        {
            Unit.Milliliter => "ml",
            Unit.Deciliter => "dl",
            Unit.Liter => "l",
            Unit.Milligram => "mg",
            Unit.Gram => "g",
            Unit.Kilogram => "kg",
            Unit.Teaspoon => "tsp",
            Unit.Tablespoon => "tbsp",
            Unit.FluidOunce => "fl oz",
            Unit.Cup => "cup",
            Unit.Pint => "pt",
            Unit.Quart => "qt",
            Unit.Gallon => "gal",
            Unit.Pound => "lb",
            Unit.Ounce => "oz",
            Unit.Pinch => "pinch",
            _ => unit.ToString()
        };
    }
} 