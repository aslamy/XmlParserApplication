using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLParserApplication.Models
{
    public class XmlParser<TEntity>
    {
        public TEntity Parse(string path)
        {
            return Deserialize(path);
        }

        public Task<TEntity> ParseAsync(string path)
        {
            return Task.Run(() => { return Deserialize(path); });
        }

        private TEntity Deserialize(string path)
        {
            var xDocument = XDocument.Load(path);
            var serializer = new XmlSerializer(typeof(TEntity));
            return (TEntity) serializer.Deserialize(xDocument.CreateReader());
        }
    }
}