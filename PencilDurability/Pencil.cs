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

    }
}
