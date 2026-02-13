using System.Collections.Generic;

namespace Instruments.Json
{
    public interface IJsonRepository<T>
    {
        T Read(string filePath);
        IList<T> ReadAll(string filePath);
        void Write(string filePath, T data);
        void WriteAll(string filePath, IList<T> data);
    }
}
