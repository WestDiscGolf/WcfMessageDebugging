using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace Client
{
    public class DebugMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request = Intercept(request);
            return request;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            reply = Intercept(reply);
        }

        private Message Intercept(Message message)
        {
            // read the message into an XmlDocument as then you can work with the contents
            // Message is a forward reading class only so once read that's it.
            MemoryStream ms = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(ms);
            message.WriteMessage(writer);
            writer.Flush();
            ms.Position = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(ms);

            // read the contents of the message here

            // as the message is forward reading then we need to recreate it before moving on
            ms = new MemoryStream();
            xmlDoc.Save(ms);
            ms.Position = 0;
            XmlReader reader = XmlReader.Create(ms);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;
            return message;
        }
    }
}