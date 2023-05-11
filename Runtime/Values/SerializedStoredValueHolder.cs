using Raccoons.Serialization;
using Raccoons.Storage.Memory;
using System.Threading;
using System.Threading.Tasks;

namespace Raccoons.Storage.Values
{
    public class SerializedStoredValueHolder<TValue> : BaseStoredValueHolder<TValue>
    {
        public ISerializer Serializer { get; }

        public SerializedStoredValueHolder() : this("Value", new SingleDataMemoryStorageChannel(), new ConvertSerializer())
        {
        }

        public SerializedStoredValueHolder(string key, IStorageChannel storageChannel) : this(key, storageChannel, new ConvertSerializer())
        {
        }

        public SerializedStoredValueHolder(string key, IStorageChannel storageChannel, ISerializer serializer) : base(key, storageChannel)
        {
            Serializer = serializer;
        }

        protected override TValue GetValue(IStorageChannel storageChannel, string key)
        {
            string result = storageChannel.GetString(key);
            return Serializer.Deserialize<TValue>(result);
        }

        protected override async Task<TValue> GetValueAsync(IStorageChannel storageChannel, string key, CancellationToken cancellationToken)
        {
            string result = await storageChannel.GetStringAsync(key);
            return Serializer.Deserialize<TValue>(result);
        }

        protected override void SetValue(IStorageChannel storageChannel, string key, TValue value)
        {
            string serialized = Serializer.Serialize(value);
            storageChannel.SetString(key, serialized);
        }

        protected override Task SetValueAsync(IStorageChannel storageChannel, string key, TValue value, CancellationToken cancellationToken)
        {
            string serialized = Serializer.Serialize(value);
            return storageChannel.SetStringAsync(key, serialized, cancellationToken);
        }
    }
}