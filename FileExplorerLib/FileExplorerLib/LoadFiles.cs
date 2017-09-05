using System;
using System.IO;

namespace FileExplorerLib
{
    /// <summary>
    /// Класс для получения файлов
    /// </summary>
    public class LoadFiles
    {
        /// <summary>
        /// Получить коллекцию файлов и папок для определенной директории
        /// </summary>
        /// <param name="path">директория</param>
        /// <returns></returns>
        public DirectoryModel Get(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            return GetFileDir(root);
        }
        /// <summary>
        /// Рекурсивный метод для поиска файлов
        /// </summary>
        /// <param name="path">директория</param>
        /// <returns></returns>
        private DirectoryModel GetFileDir(DirectoryInfo path)
        {
            DirectoryModel result = new DirectoryModel();
            result.Name = path.Name;
            result.FullName = path.FullName;
            result.CreateTime = path.CreationTime;
            FileInfo[] files = null;
            try
            {
                files = path.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException error)
            {
                // Доступ запрещен
                result.IsAccess = false;
                result.Message = error.Message;
            }
            catch (System.IO.DirectoryNotFoundException error)
            {
                // Директория не найдена.
                result.IsExistence = false;
                result.Message = error.Message;
            }
            if (files != null)
            {
                // Проходим по всем файлам текущей директории
                foreach (FileInfo file in files)
                {
                    result.Files.Add(new FileModel()
                    {
                        Name = file.Name,
                        Extension = file.Extension,
                        CreateTime = file.CreationTime,
                        SetLength = file.Length,
                        FullName = file.FullName
                    });
                }
                // Проходим по всем директориям в текущем каталоге                
                foreach (var dirInfo in path.GetDirectories())
                {
                    var newDir = GetFileDir(dirInfo);
                    // Рекурсивный заход в поддиректорию
                    result.Directories.Add(newDir);
                }
            }
            return result;
        }
    }
}
