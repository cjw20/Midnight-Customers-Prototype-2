[System.Serializable]
public class ExposedProperty
{
    // Fields
    public string PropertyName = "New String";
    public string PropertyValue = "New Value";

    public static ExposedProperty CreateInstance()
    {
        return new ExposedProperty();
    }
}