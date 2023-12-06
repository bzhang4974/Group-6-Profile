using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.DTO
{
    public class SFileDTO
    {
        public long? Id { get; set; }
        public string Code
        {
            get;
            set;
        }


        public long? DataID
        {
            get;
            set;
        }

        public string FileText
        {
            get;
            set;
        }


        public string FilePath
        {
            get;
            set;
        }

        public string FileType
        {
            get;
            set;
        }



        public long? FileSize
        {
            get;
            set;
        }
    }
}
