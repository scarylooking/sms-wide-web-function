using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.Utilities
{
    public static class ContentEncoder
    {
        private const int ChunkSize = 148; //160 - 12;


        public static IReadOnlyList<string> GeneratePlainText(string content, string sessionId)
        {
            var contentChunks = Enumerable.Range(0, content.Length / ChunkSize).Select(i => content.Substring(i * ChunkSize, ChunkSize));
            var content = new List<string>();

            var totalFrames = System.Text.Encoding.UTF8.GetString(Convert.ToByte(content.Length));

            for (var i = 0; i < contentChunks.Length; i++) {
            
                var currentFrame = System.Text.Encoding.UTF8.GetString(Convert.ToByte(i));
                
                content.Add($"OK {sessionId}{currentFrame}{totalFrames} {contentChunks}")





            }

            return new List<string>();









        }
    }
}
