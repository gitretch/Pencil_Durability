using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PencilDurability
{
    public class Pencil
    {
        public Pencil(int pencilLength = 5, int pencilPointDurability = 20, int pencilEraserDurability = 20, string existingPaper = "")
        {
            if (pencilLength >= 0)
            {
                length = pencilLength;
            }
            else
            {
                length = 0;
            }

            if (pencilPointDurability > 0)
            {
                initialPointDurability = currentPointDurability = pencilPointDurability;
            }
            else
            {
                initialPointDurability = currentPointDurability = 1;
            }

            if (pencilEraserDurability >= 0)
            {
                eraserDurability = pencilEraserDurability;
            }
            else
            {
                eraserDurability = 0;
            }
            paper = existingPaper;
        }

        private int length;
        private int initialPointDurability;
        private int currentPointDurability;
        private int eraserDurability;
        private string paper;
        private int startingIndexLastErase = -1;

        public int Length
        {
            get
            {
                return length;
            }
        }
        public int PointDurability
        {
            get
            {
                return currentPointDurability;
            }
        }
        public int EraserDurability
        {
            get
            {
                return eraserDurability;
            }
        }
        public string Paper
        {
            get
            {
                return paper;
            }
        }

        public void Sharpen()
        {
            if (length > 0)
            {
                length--;
                currentPointDurability = initialPointDurability;
            }
        }

        public void Write(string newText)
        {
            char[] newTextArray = newText.ToCharArray();

            foreach (char letter in newTextArray)
            {
                bool degraded = _degradePoint(letter);
                if (degraded)
                {
                    paper += letter;
                }
                else
                {
                    paper += ' ';
                }
            }
        }

        private bool _degradePoint(char letter)
        {
            bool completed = false;
            if (currentPointDurability > 0)
            {
                if (char.IsUpper(letter))
                {
                    if (currentPointDurability > 1)
                    {
                        currentPointDurability -= 2;
                        completed = true;
                    }
                    else
                    {
                        currentPointDurability = 0;
                    }
                }
                else if (char.IsWhiteSpace(letter))
                {
                    completed = true;
                }
                else
                {
                    if (currentPointDurability > 0)
                    {
                        currentPointDurability--;
                        completed = true;
                    }
                }
            }
            return completed;
        }

        public void Erase(string wordToErase)
        {
            // LastIndexOf returns -1 if wordToErase not in string
            int startingPos = paper.LastIndexOf(wordToErase);
            if (startingPos != -1)
            {
                int endingPos = startingPos + wordToErase.Length - 1;
                char[] eraseArray = wordToErase.ToCharArray();
                char[] paperArray = paper.ToCharArray();
                Array.Reverse(eraseArray);

                for (int i = endingPos; i >= startingPos; i--)
                {
                    bool erased = _degradeEraser(paperArray[i]);
                    if (erased)
                    {
                        paperArray[i] = ' ';
                        startingIndexLastErase = i;
                    }
                }
                paper = new string(paperArray);
            }
        }

        private bool _degradeEraser(char letter)
        {
            bool completed = false;

            if (char.IsWhiteSpace(letter))
            {
                completed = true;
            }
            if (EraserDurability > 0)
            {
                eraserDurability--;
                completed = true;
            }
            return completed;
        }

        //public void Edit2(string replaceText)
        //{
        //    char[] replaceTextArray = replaceText.ToCharArray();
        //    char[] paperArray = paper.ToArray();

        //    if (startingIndexLastErase >= 0)
        //    {
        //        int curPaperIndex = startingIndexLastErase;

        //        for (int i = 0; i < replaceTextArray.Length; i++)
        //        {
        //            // will incrementing spot in paper array exceed length of paper array?
        //            if (curPaperIndex > paper.Length)
        //            {
        //                // y, write char
        //                Write(replaceTextArray[i].ToString());
        //            }
        //            else
        //            {
        //                // n, edit char
        //                // is paper array char white space?
        //                if (char.IsWhiteSpace(paperArray[curPaperIndex]))
        //                {
        //                    // y, write replacetext char
        //                    bool degraded = _degradePoint(replaceTextArray[i]);
        //                    if (degraded)
        //                    {
        //                        paperArray[curPaperIndex] = replaceTextArray[i];
        //                    }
        //                }
        //                else
        //                {
        //                    // n, put @
        //                    Write("@");
        //                    //paperArray[curPaperIndex] = '@';

        //                }
        //                curPaperIndex++;
        //            }
        //            startingIndexLastErase = -1;
        //        }
        //    }
        //    paper = new string(paperArray);
        //}

        public void Edit(string replaceText)
        {
            char[] replaceTextArray = replaceText.ToCharArray();
            char[] paperArray = paper.ToArray();
            string appendString = "";

            if (startingIndexLastErase >= 0)
            {
                int curPaperIndex = startingIndexLastErase;

                for (int i = 0; i < replaceTextArray.Length; i++)
                {
                    //will incrementing spot in paper array exceed length of paper array ?
                    if (curPaperIndex > paper.Length -1)
                    {
                        // y, append char
                        appendString += replaceTextArray[i].ToString();
                    }
                    else
                    {
                        // n, edit char
                        var charToUse = replaceTextArray[i];
                        // is paper array char not white space?
                        if (!char.IsWhiteSpace(paperArray[curPaperIndex]))
                        {
                            charToUse = '@';
                        }
                        bool degraded = _degradePoint(charToUse);
                        if (degraded)
                        {
                            paperArray[curPaperIndex] = charToUse;
                        } 
                        curPaperIndex++;
                    }
                    startingIndexLastErase = -1;
                } 
            }
            paper = new string(paperArray) + appendString;
        }
    }
}
