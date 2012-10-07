using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace Common
{
    public class DebugMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageBuffer mb = request.CreateBufferedCopy(int.MaxValue);
            
            //MessageReader.Read(mb);

            request = mb.CreateMessage();
            return request;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            MessageBuffer mb = reply.CreateBufferedCopy(int.MaxValue);

            MessageReader.Read(mb);

            reply = mb.CreateMessage();
        }
    }
}