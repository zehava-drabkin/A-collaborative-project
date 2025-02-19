using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command
{
    public class CommandBuilder
    {
        private readonly List<string> _commands = new();

        public CommandBuilder SetInput(string path)
        {
            _commands.Add($"-i \"{path}\"");
            return this;
        }

        public CommandBuilder ApplyOverlay(int x, int y)
        {
            _commands.Add($"-filter_complex \"overlay={x}:{y}\"");
            return this;
        }

        public CommandBuilder SetOutput(string path)
        {
            _commands.Add($"-frames:v 1 \"{path}\"");
            return this;
        }

        public string Build() => string.Join(" ", _commands);

    }
}
