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

        


        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            var fiveFirstPersonsMessages = Messages
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .ToList();
            var fiveFirstPersons = Messages
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();



            Tuple<string, int>[] result = new Tuple<string, int>[5];

            int idx = 0;
            for (int i = 0; i < fiveFirstPersons.Count; i++)
            {
                if (fiveFirstPersons[i] != "Ali Heydari" && fiveFirstPersons[i] != "Sauleh Eetemadi")
                {
                    result[idx++] = new Tuple<string, int>(fiveFirstPersons[i], fiveFirstPersonsMessages[i]);
                }               
                if (idx >= 5)
                {
                    break;
                }
            }

            return result;
        }


        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            Tuple<string, int>[] result = new Tuple<string, int>[5];

            var fiveMostActive = Messages
                .Where(d => d.DateTime.Hour <= 4 && d.DateTime.Hour >= 0)
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .ToList();
            var fiveMostActiveCount = Messages
                .Where(d => d.DateTime.Hour <= 4 && d.DateTime.Hour >= 0)
                .GroupBy(d => d.Author)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Count())
                .ToList();

           
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new Tuple<string, int>(fiveMostActive[i], fiveMostActiveCount[i]);
            }

            return result;

        }

        public string StudentWithMostUnansweredQuestions()
        {
            Dictionary<MessageData, int> replyCounts = new Dictionary<MessageData, int>();
            QuestionCounter(replyCounts);

            int maxQuestionsCount = 0;
            string studentName = null;
            for (int i = 0; i < replyCounts.Count; i++)
            {
                if (replyCounts.Keys.Contains(Messages[i]))
                {
                    if (replyCounts[Messages[i]] > maxQuestionsCount)
                    {
                        maxQuestionsCount = replyCounts[Messages[i]];
                        studentName = Messages[i].Author;
                    }
                }
            }


            return studentName;
        }

        private void QuestionCounter(Dictionary<MessageData, int> replyCounts)
        {
            Dictionary<MessageData, int> replyCounter = new Dictionary<MessageData, int>();
            ReplyCounter(replyCounter);

            foreach (MessageData msg in Messages)
            {
                
                if ((msg.Content.Contains("?") || msg.Content.Contains("¿")) & replyCounter[msg] == 0)
                {
                    replyCounts[msg] = 0;
                    replyCounts[msg]++;
                }
            }
        }
    }
}