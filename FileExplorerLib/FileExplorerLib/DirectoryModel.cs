using System.Collections.Generic;
using System.Linq;

namespace FileExplorerLib
{
    /// <summary>
    /// Модель данных для директории
    /// </summary>
    public class DirectoryModel : BaseObjectModel
    {
        /// <summary>
        /// Поддиректории текущей папки
        /// </summary>
        public List<DirectoryModel> Directories { get; set; }
        /// <summary>
        /// Файлы текущей папки
        /// </summary>
        public List<FileModel> Files { get; set; }
        /// <summary>
        /// Модель данных для директории
        /// </summary>
        public DirectoryModel()
        {
            Directories = new List<DirectoryModel>();
            Files = new List<FileModel>();
        }
        /// <summary>
        /// Метод считает размер текущей директории
        /// </summary>
        /// <returns></returns>
        private long GetLengthAll()
        {
            long result = 0;
            result += Files.Sum(s => s.GetLength);
            result += Directories.Sum(s => s.GetLength);
            return result;
        }
        /// <summary>
        /// Размер текущей папки
        /// </summary>
        public long GetLength
        {
            get { return GetLengthAll(); }
        }
    }
}
