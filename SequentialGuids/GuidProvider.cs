namespace Joufa.SequentialGuids
{
    public interface IGuidProvider
    {
        Guid GetGuid();
    }

    public static class GuidProviderFactory
    {
        public static IGuidProvider GetSequentialGuidService => new SequentialGuidService();
        public static IGuidProvider GetGuidService => new GuidProvider();
    }

    internal class GuidProvider : IGuidProvider
    {
        public Guid GetGuid() => Guid.NewGuid();
    }

    internal class SequentialGuidService : IGuidProvider
    {
        private Guid _currentGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");

        public Guid GetGuid()
        {
            byte[] bytes = _currentGuid.ToByteArray();
            bytes[15] += 1;
            _currentGuid = new Guid(bytes);
            return _currentGuid;
        }
    }
}
