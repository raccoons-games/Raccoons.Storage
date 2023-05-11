using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Raccoons.Storage.Values
{
    public interface IValueHolder<TValue>
    {
        public event EventHandler<ValueChangedData<TValue>> OnValueChanged;
        public TValue GetValue();
        public ValueChangedData<TValue> SetValue(TValue value);
        public Task<TValue> GetValueAsync(CancellationToken cancellationToken = default);
        public Task<ValueChangedData<TValue>> SetValueAsync(TValue value, CancellationToken cancellationToken = default);
    }
}