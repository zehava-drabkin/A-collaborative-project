using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        public CommandBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string AddPath(string name)
        {
            return $"{_configuration["Ffmpeg:inputsUrl"]}{name}";
        }

        public CommandBuilder SetInput(string name)
        {
            _commands.Add($"-i \"{AddPath(name)}\"");
            return this;
        }

        public CommandBuilder ApplyOverlay(int x, int y)
        {
            _commands.Add($"-filter_complex \"overlay={x}:{y}\"");
            return this;
        }

        public CommandBuilder SetOutput(string name)
        {
            _commands.Add($"-frames:v 1 \"{AddPath(name)}\"");
            return this;
        }

        public string Build() => string.Join(" ", _commands);

    }
}
