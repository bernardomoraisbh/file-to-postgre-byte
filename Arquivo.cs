using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseSaveFile
{
    [Table("FILE_TEST")]
    class Arquivo
    {
        [Key]
        public long Id { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }

        public byte[] FileData { get; set; }
    }
}
