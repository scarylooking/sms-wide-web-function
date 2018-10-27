using System.Collections;

namespace WebApi.Models
{
    public class ContentFlags
    {
        private readonly BitArray _flags;

        public ContentFlags()
        {
            _flags = new BitArray(8); 
        }

        public void SetPlaintext()
        {
            _flags[0] = false;
        }

        public void SetMarkup()
        {
            _flags[0] = true;
        }

        public string GetValue()
        {
            var  array = new int[1];
            _flags.CopyTo(array, 0);
            return array[0].ToString("X2");
            
        }
    }
}