using System.IO;
using System.ServiceModel.Channels;
using System.Xml;

namespace Common
{
    class MessageReader
    {
        public static void Read(MessageBuffer mb)
        {
            MemoryStream stream = new MemoryStream();
            mb.WriteMessage(stream);
            stream.Position = 0;
            XmlDocument xdoc = new XmlDocument();
            xdoc.PreserveWhitespace = true;
            xdoc.Load(stream);
        }
    }
}