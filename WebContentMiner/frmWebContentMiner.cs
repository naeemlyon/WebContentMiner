using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace WebContentMiner
{
    public partial class frm_WebContentMiner : Form
    {
        const String App_Title = "Web Content Miner (naeem@email.com)";
        const String LastValueFile =  "C:\\Last_Value.txt";
        
        public frm_WebContentMiner()
        {
            InitializeComponent();
            tbx_Display.Text = Populate_All_Home_Pages();
            int i = 0;
            for (i = 0; i < lvw_Authors.Items.Count; i++)
            {
                cbo_From.Items.Add(i.ToString());
                cbo_To.Items.Add(i.ToString());
            }
            What_was_Latest_Value();
            this.Text = App_Title;
        }


        private void What_was_Latest_Value()
        {   
            int Last_Value = 0;
            try
            {
                StreamReader SR = File.OpenText(LastValueFile);
                Last_Value = int.Parse(SR.ReadToEnd());
                SR.Close();
                SR.Dispose();
            }
            catch
            { }

            if (lvw_Authors.Items.Count <= Last_Value)
                Last_Value = 0;
            cbo_From.SelectedIndex = Last_Value;
            if ((Last_Value + 9) >= lvw_Authors.Items.Count)
                cbo_To.SelectedIndex = lvw_Authors.Items.Count - 1;
            else
                cbo_To.SelectedIndex = Last_Value + 9;
        }


        private void btn_Start_Click(object sender, EventArgs e)
        {
            String[] Arr = Application.StartupPath.Split("\\".ToCharArray());
            this.Text = Arr[Arr.Length - 1].ToString() + " (" + cbo_From.Text + " - " + cbo_To.Text + ") " + App_Title;
            File.Delete(LastValueFile);
            File.AppendAllText(LastValueFile, (int.Parse(cbo_To.Text) + 1).ToString());
            //------------------------            
            
            String Link = String.Empty;
            String AuthorName = String.Empty; 
            String Root_Path = tbx_Root_Path.Text;
            int i = 0;            
            String Pth = String.Empty;
            int From = int.Parse(cbo_From.Text);
            int To = int.Parse(cbo_To.Text);

            for (i = From; i <= To; i++)
            {
                AuthorName = lvw_Authors.Items[i].Text;
                Link = lvw_Authors.Items[i].SubItems[1].Text;             
                Pth = Root_Path + "\\" + AuthorName;
                Directory.CreateDirectory(Pth);
                tbx_Display.Text = i.ToString() + ": " + AuthorName;
                Start_Fetcher(Link, Pth);
                tbx_Display.Refresh();

            }
            tbx_Display.Text = "Processing completed...";
        }

        #region 
        private void Start_Fetcher(String URL, String Path)
        {
            // collect all of the link found on this Author's HomePage
            Hashtable HomePage_All_URLS = Mine_Out_HyperLink(URL);
            String WebPageData = String.Empty;
            int i = 1;

            // Fech out all of the web page data..                                    
            IDictionaryEnumerator link = HomePage_All_URLS.GetEnumerator();
            while (link.MoveNext())
            {
                try
                {   
                    WebPageData = Fetch_WebPage_Data(link.Key.ToString()) + Environment.NewLine;
                    File.AppendAllText(Path + "\\" + i.ToString() + ".htm", WebPageData);
                    i++;
                }
                catch
                {
                    // do nothing... or try to debug out the reason of failure...
                }
            }                
                
        }
        #endregion


        #region Fetch WebPage Data
        private String Fetch_WebPage_Data(String URL)
        {
            String Result = String.Empty;

            if (URL.Trim().Length < 2) return Result;

            if (Uri.IsWellFormedUriString(URL, UriKind.Absolute) == false) return Result;

            // cv found
            if (URL.ToLower().Contains(".pdf") == true)
                return Read_PDF(URL);

            try
            {
                WebResponse objResponse;
                WebRequest objRequest = System.Net.HttpWebRequest.Create(URL);
                objResponse = objRequest.GetResponse();

                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    Result = sr.ReadToEnd();
                    // Close and clean up the StreamReader
                    sr.Close();
                }

                // meta http-equiv=\"Refresh\" page is being refreshed. grab the new link from it..    
                Result = Result.ToLower();
                if ((Result.Contains("meta") == true) && (Result.Contains("http-equiv") == true) && (Result.Contains("refresh") == true))
                {
                    Result = Result.Substring(Result.LastIndexOf("url=") + 4);
                    Result = Result.Replace("\">", "");
                    Result += Fetch_WebPage_Data(Result.Trim());
                }

            }
            catch
            {
                return Result;
            }




            return Result;
        }
        #endregion
        
        #region Mine_Out_HyperLink(String link)
        private Hashtable Mine_Out_HyperLink(String link)
        {
            Hashtable Ret = new Hashtable();
            if (Uri.IsWellFormedUriString(link, UriKind.Absolute) == false) return Ret;
            Ret.Add(link, "Author Personal Web Page"); // first entry is Author's main personal web page..
            String LinkName = String.Empty;
            String HREF = String.Empty;

            WebBrowser web = new WebBrowser();
            web.NewWindow += new CancelEventHandler(web_NewWindow);
            web.Navigate(link);

            //wait for the browser object to load the page
            while (web.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }

            for (int i = 0; i < web.Document.Links.Count; i++)
            {
                if ((web.Document.Links[i].GetAttribute("href") != null))
                {
                    HREF = web.Document.Links[i].GetAttribute("href").ToString();
                    if (Ret.Contains(HREF) == false)
                    {
                        LinkName = web.Document.Links[i].InnerText;
                        if ((String.IsNullOrEmpty(LinkName) == true) || (String.IsNullOrEmpty(HREF) == true))
                        { } // do nothing..

                        else if ((HREF.Contains(".ps") == true) ||
                            (HREF.Contains(".doc") == true) ||
                            (HREF.Contains(".docx") == true) ||
                            (HREF.Contains(".xls") == true) ||
                            (HREF.Contains(".xlsx") == true)
                            )
                        { } // Do Nothing. We did not process these MIME

                        // whether it contains cv link then must include it.
                        else if ((HREF.Contains(".pdf") == true) &&
                                 ((LinkName.ToLower().Contains("cv") == true) ||
                                  (LinkName.ToLower().Contains("curriculum") == true) ||
                                  (LinkName.ToLower().Contains("vitae") == true))
                                 )
                        {
                            Ret.Add(HREF, LinkName);
                        }

                        // discard all other pdf link 
                        else if ((HREF.Contains(".pdf") == true))
                        { }

                        else
                        {
                            Ret.Add(HREF, LinkName);
                        }
                    }
                }
            }
            return Ret;
        }


        void web_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region Read_PDF(String link)
        private String Read_PDF(String link)
        {
            // link = "H:\\a.pdf";
            PdfReader reader2 = new PdfReader((string)link);
            String strText = String.Empty;
            for (int page = 1; page <= reader2.NumberOfPages; page++)
            {
                iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                PdfReader reader = new PdfReader(link);
                String S = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, page, its);
                S = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(S)));
                strText += S;
                reader.Close();
            }
            return strText;
        }
        #endregion



        private String Populate_All_Home_Pages()
        {
            String Line = String.Empty;                        
            Hashtable H = new Hashtable();
            String Pth = String.Empty;
            ListViewItem L;
            StreamReader SR = File.OpenText(Application.StartupPath + "\\HomePages.txt");
            while (!SR.EndOfStream) 
            {
                Line = SR.ReadLine();
                String[] Arr = Line.Split("\t".ToCharArray());
                if ( String.IsNullOrEmpty(Arr[1]) == false) 
                {
                 if  (H.Contains(Arr[0]) == false)
                 {
                    H.Add(Arr[0], Arr[1]);
                    L= lvw_Authors.Items.Add(Arr[0].Trim());
                    L.SubItems.Add(Arr[1]);                   
                 }
                }
            }
            SR.Close();
            SR.Dispose();
            return  lvw_Authors.Items.Count.ToString() + " Authors with Homepages laoded...";
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            What_was_Latest_Value();
        }


        
    }
}
