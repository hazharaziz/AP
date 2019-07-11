using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Logger
{
    public class XmlLogFormatter : ILogFormatter
    {
        private XmlLogFormatter() { }

        private static XmlLogFormatter _Instance;

        public static XmlLogFormatter Instance => _Instance ?? (_Instance = new XmlLogFormatter());

        public string Header => "<LogEntries>";

        public string Footer => "</LogEntries>";

        public string FileExtention => "xml";

        public string Format(LogEntry entry)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LogEntry));
            StringBuilder sbLogString = new StringBuilder();
            using (StringWriter stream = new StringWriter(sbLogString))
            using (var writer = XmlWriter.Create(stream, XmlSettings))
                serializer.Serialize(writer, entry, XmlNamespace);

            return sbLogString.ToString();
        }

        protected XmlSerializerNamespaces XmlNamespace { get; }
            = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        protected XmlWriterSettings XmlSettings { get;  } 
            = new XmlWriterSettings() { OmitXmlDeclaration = true };
    }
}