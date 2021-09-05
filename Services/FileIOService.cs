using csharp_todoapp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_todoapp.Services
{
    class FileIOService
    {
        // куда сохранять файлы
        private readonly string PATH;

        // для получения данных из конструктора класса в переменную PATH
        public FileIOService(string path)
        {
            PATH = path;
        }

        // метод считывающий данные с диска
        public BindingList<TodoModel> LoadData()
        {
            // проверка сущ-т ли файл
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }

            // если есть - чтение из файла OpenText и десериализация наружу
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }

        }

        // метод сохраняющий данные с диска
        public void SaveData(BindingList<TodoModel> todoDataList)
        {
            // using нужен для вызова метода dispose у объекта writer
            // метода dispose нужен для освобождения ресурсов, который исп-ся для записи данных в файл
            using (StreamWriter writer = File.CreateText(PATH))
            {
                // сериализация джсона todoDataList в строку output
                string output = JsonConvert.SerializeObject(todoDataList);
                // строку записываем в файл
                writer.Write(output);
            }
        }
    }
}
