namespace Continental.API.Impl
{
    public readonly record struct ConvertableParameter<T>(string ParameterName, T Value) : IConvertableParameter<T>
    {
    }
}