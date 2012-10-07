using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Common
{
    public class DebugMessageDispatcher : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            MessageBuffer mb = request.CreateBufferedCopy(int.MaxValue);

            MessageReader.Read(mb);

            request = mb.CreateMessage();
            return request;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //MessageBuffer mb = reply.CreateBufferedCopy(int.MaxValue);

            //MessageReader.Read(mb);

            //reply = mb.CreateMessage();
        }
    }
}
