using System;

namespace FileExplorerLib
{
    /// <summary>
    /// Базовый класс для моделей файлов и папок
    /// </summary>
    public abstract class BaseObjectModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// Размер в байтах
        /// </summary>
        protected long Length;
        /// <summary>
        /// Доступ
        /// </summary>
        public bool IsAccess { get; set; }
        /// <summary>
        /// Наличие 
        /// </summary>
        public bool IsExistence { get; set; }
        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Полный путь к файлу или директории
        /// </summary>
        public string FullName { get; set; }

        public BaseObjectModel()
        {
            IsAccess = true;
            IsExistence = true;           
            Message = string.Empty;
        }
    }
}
