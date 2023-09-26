using System.Diagnostics;

namespace day13
{
    public class Packet 
    {
        private int _value = -1;
        private List<Packet> _children = new List<Packet>();

        public Packet() { }

        public Packet (int value)
        {
            _value = value;
        }

        public Packet(List<Packet> children)
        {
            _children = children;
        }

        public Packet Parent { get; set; } = null;

        public void AddValue(int value)
        {
            if (_children.Count == 0 && _value > -1)
            {
                _children.Add(new Packet(_value));
                _value = -1;
            }

            if ( _children.Count != 0 )
            {
                _children.Add(new Packet(value));
                return;
            }

            _value = value;
        }

        public void AddChild(Packet child)
        {
            if (_value != -1)
            {
                _children.Add(new Packet(_value));
                _value = -1;
            }

            _children.Add(child);
        }

        private void ConvertToListPacket()
        {
            var value = new Packet(_value);
            _children.Add(value);
            _value = -1;
        }


        public Size CompareSize(Packet other)
        {
            
            if (_children.Count ==0 && other._children.Count == 0)
            {
                if (_value < other._value) return Size.Smaller;
                if (_value == other._value) return Size.Equal;
                return Size.Bigger;
            };

            if (_children.Count == 0 && _value != -1 && other._children.Count != 0)
            {
                ConvertToListPacket();
            }

            if (_children.Count != 0 && other._children.Count == 0 && other._value != -1)
            {
                other.ConvertToListPacket();
            }

            int counts = Math.Max(_children.Count, other._children.Count);

            for (int i = 0; i< counts; i++)
            {
                if (i== _children.Count) return Size.Smaller;
                if (i == other._children.Count) return Size.Bigger;

                var res = _children[i].CompareSize(other._children[i]);

                if (res != Size.Equal) return res;
            }

            return Size.Equal;
        }

        public bool IsBigger(Packet comparison)
        {
            return CompareSize(comparison) == Size.Bigger;
        }


        public override bool Equals(object? obj)
        {
            return obj is Packet node &&
                   _value == node._value &&
                   _children.SequenceEqual(node._children);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _children);
        }
    }

}