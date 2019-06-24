using FVTC.LearningInnovations.App;
using System.IO;
using System.Threading.Tasks;

namespace Avana.Models
{
    public abstract class DeviceConfiguration : IModel
    {
        public async Task WriteToAsync(Stream stream)
        {
            using (var writer = new System.IO.StreamWriter(stream))
            {
                await WriteToAsync(writer);
            }
        }

        public void WriteTo(Stream stream)
        {
            using (var writer = new System.IO.StreamWriter(stream))
            {
                WriteTo(writer);
            }
        }

        public abstract Task WriteToAsync(System.IO.TextWriter writer);

        public void WriteTo(TextWriter writer)
        {
            Task.WaitAll(WriteToAsync(writer));
        }
    }
}