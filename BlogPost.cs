using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace RichBoxAdvanceLecture
{
    public class BlogPost
    {
        string _subjectline;
        string _bodyText;
        Color _subjectColor;
        DateTime _timeStamp; 

        public BlogPost(string subjectline, string bodyText, Color userColor)
        {
            _subjectline = subjectline;
            _bodyText = bodyText;
            _subjectColor = userColor; 
            _timeStamp = DateTime.Now; 
        }

        public string Subjectline { get => _subjectline; set => _subjectline = value; }
        public string BodyText { get => _bodyText; set => _bodyText = value; }

        public Run HeaderFormatted(string subjectline)
        {
            Run headerRun = new Run(subjectline+ "\n");
            headerRun.Foreground = new SolidColorBrush(_subjectColor);
            headerRun.FontSize = 24;
            headerRun.FontStyle = FontStyles.Normal;

            return headerRun;
        }
        public Run Bodyformatted(string bodyText)
        {
            Run runNewBody = new Run(bodyText);
            runNewBody.FontSize = 12;
            return runNewBody;
        }
        public Paragraph BlogPostFormatted()
        {
            Paragraph newParagraph = new Paragraph();

            //CREATE A RUN 
            string subjectLine = _subjectline;
            string bodyText = _bodyText;

            //GET THE FLOW DOCUMENT 
            //CREATE A PARAGRAPH 

            Run header = HeaderFormatted(subjectLine);
            Run body = Bodyformatted(bodyText);


            //ADD TO PARAGRAPH 

            newParagraph.Inlines.Add(header);
            newParagraph.Inlines.Add("\n");
            newParagraph.Inlines.Add(body);

            // SUBJECT LINE , NEW LINE , BODY TEXT 

            return newParagraph;
        }
        
        public override string ToString()
        {
            return _timeStamp.ToShortTimeString() + " "+  _subjectline;
        }
    }
}
