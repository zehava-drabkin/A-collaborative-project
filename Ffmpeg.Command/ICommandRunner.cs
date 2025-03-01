using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ffmpeg.Command
{
    public interface ICommandRunner<T>
    {
        Task<Result> Run(T request);
    }
}
