using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace RichBoxAdvanceLecture
{//EDNA LYNN LAXA 
 //MARCH 10, 2023 
 //CSI PROGRAMMING II 
 //RICHBOX ADVANCE LECTURE 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //1 , FLOW DOCUMENT 
        //2 , PARAGRAPH : Block Element
        //3 , RUN : Inline Element 

        FlowDocument fdDisplay = new FlowDocument();
        List<BlogPost> blogPosts = new List<BlogPost>();

        public MainWindow()
        {
            InitializeComponent();
            rtbDisplay.Document = fdDisplay;

        
            
        }
        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            //ADD TO FLOW DOCUMENT 

            string subjectLine = txtSubjectLine.Text;
            string bodyText = runBody.Text;
            Color userColor = UsersColor(); 

            BlogPost bp = new BlogPost(subjectLine, bodyText, userColor);
            blogPosts.Add(bp);
            DisplayBlogPosts(); // POST PREVIOUS ENTRY POSTS 

            fdDisplay.Blocks.Add(blogPosts[0].BlogPostFormatted());
        }
        public void DisplayBlogPosts()
        {

            lbBlogPost.Items.Clear(); 
            foreach (BlogPost item in blogPosts)
            {
                lbBlogPost.Items.Add(item); 
            }
        }
       
        public void LearningCode()
        {
            Paragraph para = new Paragraph();
            //CREATING A SENTENCE 

            Run run = new Run("Hello World");
            run.Background = new SolidColorBrush(Colors.MediumVioletRed);
            //CREATING A SENTENCE 
            //ADDING A SENTENCE TO OUR PARAGRAPH 
            //para.Background = new SolidColorBrush(Colors.DarkOrchid); 
            para.Inlines.Add(run);
            para.Inlines.Add(run);
            para.Inlines.Add("\n");
            para.Inlines.Add(new Run("this ran"));
            //ADDING THE PARAGRAPH TO OUR DOCUMENT 

            fdDisplay.Blocks.Add(para);
            //fdDisplay.Background = new SolidColorBrush(Colors.LavenderBlush);

            //ADD OUR DOCUMENT TO OUR RTB 
            /*rtbDisplay.Background = new SolidColorBrush(Color.FromRgb(200, 0, 188));*/ //Red, Green, Blue 

            rtbDisplay.Document = fdDisplay;
        }
        private void ExampleCode ()
        {
            //MANUALLY CREATED STRUCTURE FOR RTB 
            FlowDocument fdDisplay = new FlowDocument();

            Paragraph p = new Paragraph();
            Run r = new Run("Hello");
            r.FontWeight = FontWeights.Bold;
            r.Foreground = new SolidColorBrush(Colors.Black);
            r.FontSize = 22;
            

            p.Inlines.Add(r);
            fdDisplay.Blocks.Add(p);
            rtbDisplay.Document = fdDisplay;
        }

        private void lbBlogPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = lbBlogPost.SelectedIndex; 

            if(selected >= 0)
            {
                BlogPost bp = blogPosts[selected];
                UpdateRichTextBox(bp);
                //MessageBox.Show(blogPosts[selected].ToString());
            }

        }

        public void UpdateRichTextBox(BlogPost post)
        {
            fdDisplay.Blocks.Clear();
            fdDisplay.Blocks.Add(post.BlogPostFormatted());
        }
        public Color UsersColor()
        {
            byte r = byte.Parse(txtR.Text);
            byte g = byte.Parse(txtG.Text);
            byte b = byte.Parse(TxtB.Text);

            Color userColor = Color.FromRgb(r, g, b);

            return userColor; 
        }
    }
    //What's the difference between a paragraph and a run tag ( regarding space used )?
    //ANSWER: Paragrah = Block ; Run = Inline . 

    // What "Collection" does a Paragraph have that holds inlines?
    // ANSWER: TextBlock, Span & Element

    // What "Collection" does a FlowDocument have that holds blocks?
    //ANSWER: Gets the top level block elements. 

    // How do you connect a FlowDocument to a RichTextBox
    //ANSWER: rtbDisplay.Document = fdDisplay; - RICHTEXTBOX.DOCUMENT  = FLOWDOCUMENT 

    // How often does Will appear in the Rich Text Box with the following code?
    // Run name = new Run("Will");
    //What property is used to add Italics?
    //ANSWER:  Name.FontStyle 
    //What property is used to add bold?
    //ANSWER: Name.FontWeight = FontWeights.Bold

}
