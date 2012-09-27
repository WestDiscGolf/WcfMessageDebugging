using System;
using System.ServiceModel.Configuration;

namespace Client
{
    public class DebugMessageBehaviourElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new DebugMessageBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(DebugMessageBehavior);
            }
        }
    }
}
