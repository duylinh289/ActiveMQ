using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace MQ
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection con = factory.CreateConnection("admin", "admin");
            con.Start();

            ISession session = con.CreateSession(AcknowledgementMode.AutoAcknowledge);
            ActiveMQQueue destination = new ActiveMQQueue("Test");
            IMessageProducer producer = session.CreateProducer(destination);
            for (int i = 0; i == 5; i++)
            {
                IMessage msg = new ActiveMQTextMessage("Hello this is message." + i);
                producer.Send(msg);
            }
            

            con.Close();
            session.Close();

        }
    }
}
