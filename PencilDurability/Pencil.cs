using System;
using System.Collections.Generic;
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
                bool degraded = DegradePoint(letter);
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

        public bool DegradePoint(char letter)
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

        public bool DegradeEraser(char letter)
        {
            bool completed = false;
            if(EraserDurability != 0)
            {
                completed = true;
            }

            return completed;
        }
    }
}
