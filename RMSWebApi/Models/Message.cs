using System.Collections.Generic;

namespace RMSWebApi.Models
{
    public class Message
    {
        public class ResponseDTO
        {
            int _id;
            string _message;
            string _name;
            bool _valid;
            int _count;
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
            public string Message
            {
                get { return _message; }
                set { _message = value; }
            }
            public bool Valid
            {
                get { return _valid; }
                set { _valid = value; }
            }
            public int Count
            {
                get { return _count; }
                set { _count = value; }
            }
            public ResponseDTO(string defaultMessage)
            {
                Message = defaultMessage;
                Valid = false;
            }
            public ResponseDTO()
            {
                Valid = true;
            }
        }
        public class ListResponseDTO<DtoType> : ResponseDTO
        {
            public ListResponseDTO() : base()
            {
                Items = new List<DtoType>();
            }
            public ListResponseDTO(string defaultMessage) : base(defaultMessage)
            {
                Items = new List<DtoType>();
            }

            public List<DtoType> Items;
        }
        public class SingleItemResponseDTO<DtoType> : ResponseDTO where DtoType : new()
        {
            public SingleItemResponseDTO() : base()
            {
                Item = new DtoType();
            }
            public SingleItemResponseDTO(string defaultMessage) : base(defaultMessage)
            {
                Item = new DtoType();
            }
            public DtoType Item;
        }
    }
}
