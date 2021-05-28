using System;
using System.Threading;
using System.Collections.Generic;


public class Event_loop
{
 
    private ManualResetEventSlim _messageEvent = new ManualResetEventSlim(false);
    private Queue<string> _messageQueue = new Queue<string>();

    public void Threadmain()
    {
        var a = new Thread(PumpMessages);
        a.Start();

        while (true)
        {
            var message = WaitMessage();
            WriteLine("Received message: " + message);
            if (message == "exit")
            {
                break;
            }
        }
    }

    private string WaitMessage()
    {
        _messageEvent.Wait();
        var message = _messageQueue.Dequeue();
        _messageEvent.Reset();
        return message;
    }

    private void PumpMessages()
    {
        while (true)
        {
            var word = ReadLine();
            _messageQueue.Enqueue(word);
            _messageEvent.Set();
            if (word == "exit")
            {
                break;
            }
        }
    }

    public virtual string ReadLine()
    {
        return Console.ReadLine();
    }

    public virtual void WriteLine(string strline)
    {
        Console.WriteLine(strline);
    }
}
