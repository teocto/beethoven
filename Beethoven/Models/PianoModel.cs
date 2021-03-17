using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beethoven.Models
{
    public class PianoModel
    {
        public int Number { get; set; }

        public int Divider { get; set; }

        public float Size { get; set; }

        /// <summary>
        /// Нотный стан
        /// </summary>
        public string Stave { get; set; }

        public bool Success { get; set; }


        public bool Check(PianoModel piano)
        {
            var success = true;
            piano.Size = (float)piano.Number/piano.Divider;
            try
            {
                var notes = piano.Stave.Split('|');
                foreach (var note in notes)
                {
                    var sizes = note.Split(' ');
                    float totalSize = 0;
                    foreach (var size in sizes)
                    {
                        if (!String.IsNullOrEmpty(size)) totalSize += (float)1 / Convert.ToInt32(size);
                    }
                    if (totalSize != piano.Size)
                    {
                        success = false;
                    }
                }
            }
            catch(Exception ex)
            {
                success = false;
            }
            piano.Success = success;
            return success ;
        }
    }
}
