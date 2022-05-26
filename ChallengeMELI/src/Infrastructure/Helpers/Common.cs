using System.Text.Json;

namespace Challenge.MELI.Helpers
{
    public static class Common
    {
        public static byte[] ToByteCache<T>(T data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data);
        }

        public static T FromByteCache<T>(byte[] data)
        {
            var response = JsonSerializer.Deserialize<T>(data);
            return response;
        }
    }
}
