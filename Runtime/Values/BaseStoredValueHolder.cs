using System;
using System.Threading;
using System.Threading.Tasks;

namespace Raccoons.Storage.Values
{
    public abstract class BaseStoredValueHolder<TValue> : IValueHolder<TValue>
    {
        public string Key { get; }
        public IStorageChannel StorageChannel { get; }

        public event EventHandler<ValueChangedData<TValue>> OnValueChanged;

        protected BaseStoredValueHolder(string key, IStorageChannel storageChannel)
        {
            Key = key;
            StorageChannel = storageChannel;
        }

        public virtual ValueChangedData<TValue> NotifyValueChange(TValue newValue, TValue oldValue)
        {
            ValueChangedData<TValue> eventData = new ValueChangedData<TValue>(newValue, oldValue);
            OnValueChanged?.Invoke(this, eventData);
            return eventData;
        }
        public TValue GetValue()
        {
            return GetValue(StorageChannel, Key);
        }

        protected abstract TValue GetValue(IStorageChannel storageChannel, string key);

        public ValueChangedData<TValue> SetValue(TValue value)
        {
            TValue oldValue = default;
            if (StorageChannel.Exists(Key))
            {
                oldValue = GetValue(StorageChannel, Key);
            }
            SetValue(StorageChannel, Key, value);
            return NotifyValueChange(value, oldValue);
        }

        protected abstract void SetValue(IStorageChannel storageChannel, string key, TValue value);

        public Task<TValue> GetValueAsync(CancellationToken cancellationToken = default)
        {
            return GetValueAsync(StorageChannel, Key, cancellationToken);
        }

        protected abstract Task<TValue> GetValueAsync(IStorageChannel storageChannel, string key, CancellationToken cancellationToken);

        public async Task<ValueChangedData<TValue>> SetValueAsync(TValue value, CancellationToken cancellationToken = default)
        {
            TValue oldValue = default;
            if (await StorageChannel.ExistsAsync(Key, cancellationToken))
            {
                oldValue = GetValue(StorageChannel, Key);
            }
            await SetValueAsync(StorageChannel, Key, value, cancellationToken);
            return NotifyValueChange(value, oldValue);
        }

        protected abstract Task SetValueAsync(IStorageChannel storageChannel, string key, TValue value, CancellationToken cancellationToken);
    }
}