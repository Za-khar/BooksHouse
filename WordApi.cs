using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace BooksHouse
{
    class WordApi
    {
        private Word.Application wordApp = null;
        private Word.Document wordDoc = null;

        public WordApi()
        {
            try
            {
                wordApp = new Word.Application();
                wordDoc = wordApp.Documents.Add();
            }
            catch (Exception ex)
            {
                wordApp = null;
                wordDoc = null;
                MessageBox.Show("Помилка створення звіту", "Помилка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addParagraph(string text, int size = 14, int bold = -1)
        {
            Word.Paragraph newPar = wordDoc.Paragraphs.Add();
            newPar.Range.Font.Size = size;
            newPar.Range.Font.Name = "Times New Roman";

            if (bold != -1)
            {
                newPar.Range.Font.Bold = bold;
            }

            newPar.Range.Text = text;
            newPar.Range.InsertParagraphAfter();
        }

        public void saveDoc(string path)
        {
            try
            {
                wordApp.Visible = true;
                wordDoc.SaveAs2(path);

                MessageBox.Show($"Успішно створено звіт MS Word за посиланням {path}", "Успіх",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show($"Помилка створення документу!", "Помилка",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
