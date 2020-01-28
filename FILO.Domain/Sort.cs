using System;
using System.Collections.Generic;

namespace FILO.Domain
{
    public class Sort: ISortMultiple, ISortSingle
    {

        // Reorder the received string using a multi-facet for loops
        // 1st loop places non-alphanumeric as anchors, anchors stay in the same position and are not sorted
        // 2nd loop reverses the string and making sure that the "anchors" stays in place
        string ISortMultiple.SortString(string value)
        {
            try
            {
                char[] originals = value.ToCharArray();
                char[] sorted = new char[value.Length];

                Array.Clear(sorted, 0, sorted.Length);

                //Put anchors in
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetterOrDigit(originals[i]))
                    {
                        sorted[i] = originals[i];
                    }
                }

                int position = value.Length - 1;

                foreach (char letter in originals)
                {
                    if (char.IsLetterOrDigit(letter))
                    {
                        while (sorted[position] != 0 && position >= 0)
                        {
                            position--;
                        }

                        sorted[position] = letter;
                        position--;
                    }
                }

                return new string(sorted);

            }
            catch (Exception e)
            {
                //Add appropriate exception handling here
                //Should bubble up the error to the caller
            }

            return null;

        }


        // Reorder the received string using a single loop making sure that non-alphanumerics do not change position
        // in the reordering of the string
        string ISortSingle.SortString(string value)
        {
            try
            {
                char[] original = value.ToCharArray();

                int position = original.Length - 1;
                int index = 0;

                while (index < position)
                {
                    if (!char.IsLetterOrDigit(original[index]))
                        index += 1;
                    else if (!char.IsLetterOrDigit(original[position]))
                        position -= 1;
                    else
                    {
                        char letter = original[index];
                        original[index] = original[position];
                        original[position] = letter;

                        index += 1;
                        position -= 1;
                    }

                }

                return new string(original);

            }
            catch (Exception e)
            {
                //Add appropriate exception handling here
                //Should bubble up the error to the caller
            }

            return null;
         }

    }
}
