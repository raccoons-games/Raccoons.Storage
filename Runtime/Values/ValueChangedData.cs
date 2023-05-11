namespace Raccoons.Storage.Values
{
    public class ValueChangedData<TValue>
    {
        public ValueChangedData(TValue newValue, TValue oldValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }

        public TValue NewValue { get; }
        public TValue OldValue { get; }
    }
}