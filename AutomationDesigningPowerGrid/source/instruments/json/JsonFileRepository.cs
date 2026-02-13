using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Instruments.Json
{
    public class JsonFileRepository<T> : IJsonRepository<T>
    {

        private readonly JsonSerializerOptions _options;

        public JsonFileRepository()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
        }

        public T Read(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            string json = File.ReadAllText(filePath);
            T data = JsonSerializer.Deserialize<T>(json, _options);

            if (data == null)
                throw new InvalidOperationException("Не удалось десериализовать JSON в объект.");

            return data;
        }

        public IList<T> ReadAll(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            string json = File.ReadAllText(filePath);
            IList<T> data = JsonSerializer.Deserialize<IList<T>>(json, _options);

            if (data == null)
                throw new InvalidOperationException("Не удалось десериализовать JSON в список объектов.");

            return data;
        }

        public void Write(string filePath, T data)
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, json);
        }

        public void WriteAll(string filePath, IList<T> data)
        {
            string json = JsonSerializer.Serialize(data, _options);
            File.WriteAllText(filePath, json);
        }
    }
}
