using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            Dictionary<MessageData, int> replyCounts = new Dictionary<MessageData, int>();
            ReplyCounter(replyCounts);
            MessageData result = null;
            int max = replyCounts[Messages[0]];
            for (int i = 0; i < Messages.Count; i++)
            {
                if (replyCounts[Messages[i]] > max)
                {
                    max = replyCounts[Messages[i]];
                    result = Messages[i];
                }
            }
            return result;
        }

        private void ReplyCounter(Dictionary<MessageData, int> replyCounts)
        {
            foreach (MessageData msg in Messages)
            {
                replyCounts[msg] = 0;

                foreach (MessageData m in Messages)
                {
                    if (msg.Id == m.ReplyMessageId && m.ReplyMessageId != null)
                    {
                        replyCounts[msg]++;
                    }
                }
            }
        }

        //MessageData maxReply = Messages[0];
        //int max = (int)Messages[0].ReplyMessageId;

        //for (int i = 0; i < Messages.Count; i++)
        //{
        //    if ((int)Messages[i].ReplyMessageId > max)
        //    {
        //        max = (int)Messages[i].ReplyMessageId;
        //        maxReply = Messages[i];
        //    }
        //}

        //return maxReply;



        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            //Tuple<string, int>[] result = new Tuple<string, int>[5];

            //var authors = Messages.Where(d => d.Author != "Sauleh Eetemadi" || d.Author != "Ali Heydari")
            //    .Select(d => d.Author).Take(5).ToList();

            throw new NotImplementedException();


        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            throw new NotImplementedException();
        }

        public string StudentWithMostUnansweredQuestions()
        {
            throw new NotImplementedException();
        }
    }
}