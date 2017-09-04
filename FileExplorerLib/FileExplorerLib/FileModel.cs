
namespace FileExplorerLib
{
    /// <summary>
    /// Модель данных для файла
    /// </summary>
    public class FileModel : BaseObjectModel
    {
        /// <summary>
        /// Расширение файла
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Получить размер файла
        /// </summary>
        public long GetLength
        {
            get
            {
                return base.Length;
            }
        }
        /// <summary>
        /// Установить размер файла
        /// </summary>
        public long SetLength
        {
            set
            {
                base.Length = value;
            }
        }
    }
}
