using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Models;

namespace WebApi.Utilities
{
    public static class ContentEncoder
    {
        private const int ChunkSize = 148; //160 - 12;

        public static IReadOnlyList<string> GeneratePlainText(string content, string sessionId)
        {
            var flags = new ContentFlags();

            flags.SetPlaintext();

            return GeneratePlaintextInternal(content, sessionId, flags);
        }

        public static IReadOnlyList<string> GeneratextMarkup(string content, string sessionId)
        {
            var flags = new ContentFlags();

            flags.SetMarkup();

            return GeneratePlaintextInternal(content, sessionId, flags);
        }

        private static IReadOnlyList<string> GeneratePlaintextInternal(string content, string sessionId, ContentFlags flags)
        {
            var contentChunks = Enumerable.Range(0, content.Length / ChunkSize).Select(i => content.Substring(i * ChunkSize, ChunkSize)).ToArray();

            var totalFrameString = contentChunks.Length.ToString("X2");

            

            return contentChunks.Select((t, i) => $"OK {sessionId}{i:X2}{totalFrameString}{flags.GetValue()} {t}").ToList();
        }
    }
}